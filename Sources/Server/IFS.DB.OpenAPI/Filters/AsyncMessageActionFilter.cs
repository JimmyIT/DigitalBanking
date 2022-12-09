using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.OpenAPI.Message.Create;
using IFS.DB.Application.OpenAPI.Message.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Filters
{
    public class AsyncMessageActionFilter : IAsyncActionFilter
    {
        private readonly IErrorMessageService _ErrorMessageSvc;
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly ILogger<AsyncMessageActionFilter> _Logger;
        private readonly ICreateMessageHandler _CreateMessageHandler;
        private readonly IUpdateMessageHandler _UpdateMessageHandler;

        public AsyncMessageActionFilter(IErrorMessageService errorMessageSvc, 
            IDateTimeProvider dateTimeProvider,
            ILogger<AsyncMessageActionFilter> logger,
            ICreateMessageHandler createMessageHandler,
            IUpdateMessageHandler updateMessageHandler)
        {
            _ErrorMessageSvc = errorMessageSvc;
            _DateTimeProvider = dateTimeProvider;
            _Logger = logger;
            _CreateMessageHandler = createMessageHandler;
            _UpdateMessageHandler = updateMessageHandler;
        }

        /// <summary>
        /// This function is use to handle the action message both before and after executing
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            APIActionInfoAttribute actionInfo = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<APIActionInfoAttribute>().FirstOrDefault();
            if (actionInfo == null)
            {
                throw new Exception("Missing Action Info Attribute");
            }

            //Ignore message which HB call to get list queue to process
            if (actionInfo.MessageCode == APIMessageActionInfo.Message.GetByStatusAndDirection.Code)
            {
                ActionExecutedContext nextContext = await next();
                return;
            }

            // Insert to log API Message before execting    
            APIMessage apiMessage = new APIMessage()
            {
                MessageCode = actionInfo.MessageCode,
                Url = $"[{context.HttpContext.Request.Method}] : {context.HttpContext.Request.Path}",
                Status = (int)OpenAPIMessageStatusEnum.New,
                CreatedOn = _DateTimeProvider.Now()
            };

            //Get Header
            IHeaderDictionary apiHeaderObj = context.HttpContext.Request.Headers;
            if (apiHeaderObj != null)
            {
                apiMessage.Header = JsonConvert.SerializeObject(apiHeaderObj);
                apiMessage.IdempotencyKey = apiHeaderObj[APIConstant.Header.x_idempotency_key];
            }

            //Get Body
            foreach (ControllerParameterDescriptor param in context.ActionDescriptor.Parameters)
            {
                if (param.ParameterInfo.CustomAttributes.Any(
                    attr => attr.AttributeType == typeof(FromBodyAttribute))
                )
                {
                    var entity = context.ActionArguments[param.Name];
                    PropertyInfo clientNumberProp = entity.GetType().GetProperty("ClientNumber");
                    if (clientNumberProp != null)
                    {
                        apiMessage.ClientNumber = (string)clientNumberProp.GetValue(entity, null);
                    }
                    PropertyInfo accountNumberProp = entity.GetType().GetProperty("AccountNumber");
                    if (accountNumberProp != null)
                    {
                        apiMessage.AccountNumber = (string)accountNumberProp.GetValue(entity, null);
                    }

                    apiMessage.RequestMessage = JsonConvert.SerializeObject(entity);
                }
            }

            // Insert OpenAPIMessage to Db
            await _CreateMessageHandler.DoActionAsync(apiMessage);

            // next() calls the action method.
            ActionExecutedContext resultContext = await next();

            int? apiStatusCode = 0;
            if (resultContext.Exception == null)
            {
                apiStatusCode = (resultContext.Result as ObjectResult)?.StatusCode;
                
                if (resultContext.Result != null)
                {
                    switch (resultContext.Result)
                    {
                        case NoContentResult:
                            {
                                apiMessage.ResponseMessage = string.Empty;
                                apiMessage.Status = (int)OpenAPIMessageStatusEnum.Success;
                                break;
                            }

                        default:
                            {
                                switch (resultContext.Result)
                                {
                                    case Microsoft.AspNetCore.Mvc.FileContentResult:
                                        {
                                            apiMessage.Status = (int)OpenAPIMessageStatusEnum.Success;

                                            break;
                                        }

                                    default:
                                        {
                                            ObjectResult responseResult = (ObjectResult)resultContext.Result;
                                            PropertyInfo valueProp = responseResult.GetType().GetProperty("Value");

                                            if (valueProp != null)
                                                apiMessage.ResponseMessage = JsonConvert.SerializeObject(valueProp.GetValue(responseResult, null));

                                            if (apiStatusCode != null)
                                                switch ((HttpStatusCode)apiStatusCode)
                                                {
                                                    case HttpStatusCode.OK:
                                                    case HttpStatusCode.Created:
                                                        {
                                                            apiMessage.Status = (int)OpenAPIMessageStatusEnum.Success;
                                                            break;
                                                        }

                                                    default:
                                                        {
                                                            string jsonResponse = apiMessage.ResponseMessage;
                                                            var errorReultJToken = JToken.Parse(jsonResponse);
                                                            List<string> errorMsgs = new List<string>();
                                                            if (errorReultJToken is JArray)
                                                            {
                                                                Error[] errrors = JsonConvert.DeserializeObject<Error[]>(jsonResponse);
                                                                foreach (var error in errrors)
                                                                    errorMsgs.Add(error.Message);
                                                            }
                                                            else if (errorReultJToken is JObject)
                                                            {
                                                                Error error = JsonConvert.DeserializeObject<Error>(jsonResponse);
                                                                errorMsgs.Add(error.Message);
                                                            }
                                                            apiMessage.ErrorMessage = JsonConvert.SerializeObject(errorMsgs);
                                                            apiMessage.Status = (int)OpenAPIMessageStatusEnum.Failed;
                                                            break;
                                                        }
                                                }
                                            else
                                                apiMessage.Status = (int)OpenAPIMessageStatusEnum.Failed;

                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
            }
            else
            {
                Exception ex = resultContext.Exception;
                apiStatusCode = (int)HttpStatusCode.InternalServerError;
                string responseException = JsonConvert.SerializeObject(await _ErrorMessageSvc.CreateInternalServerErrorAsync(ex));
                apiMessage.Status = (int)OpenAPIMessageStatusEnum.Failed;
                apiMessage.ResponseMessage = responseException;
                apiMessage.ErrorMessage = ex.Message;
            }

            // Update OpenAPIMessage
            await _UpdateMessageHandler.DoAction(apiMessage);

            //Write Event Log
            _Logger.LogInformation($"{actionInfo.MessageCode} - {actionInfo.MessageDescription} - Http Code : {apiStatusCode}");
        }
    }
}

