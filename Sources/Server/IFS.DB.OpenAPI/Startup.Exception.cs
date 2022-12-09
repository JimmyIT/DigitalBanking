using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.ErrorCodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace IFS.DB.OpenAPI
{
    public partial class Startup
    {
        public void SetExceptionError(IApplicationBuilder builder, bool isDevelop)
        {

            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                if (contextFeature != null)
                {
                    var ex = contextFeature?.Error;

                    //return error
                    var error = context.RequestServices.GetService<IErrorMessageService>();
                    Error errorDetail = await error.CreateInternalServerErrorAsync(isDevelop ? ex.Message : string.Empty);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetail));

                    //write log
                    var logger = context.RequestServices.GetService<ILogger<Startup>>();
                    logger.LogError($"Reference : {errorDetail.Reference} **** \r\n {ex.ToString()}");
                }
            });
        }
    }
}
