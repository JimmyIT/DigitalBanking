using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Currencies.GetAll;
using IFS.DB.Application.Currencies.GetAML;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Currency}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Currency}")]
    public class CurrencyController : BaseOpenAPIController
    {
        private readonly IGetAllCurrenciesHandler _GetAllCurrenciesHandler;
        private readonly IGetAMLCurrenciesHandler _GetAMLCurrenciesHandler;

        public CurrencyController(IErrorMessageService errorMessageSvc, 
            IGetAllCurrenciesHandler getAllCurrenciesHandler,
            IGetAMLCurrenciesHandler getAMLCurrenciesHandler)
            : base(errorMessageSvc)
        {
            _GetAllCurrenciesHandler = getAllCurrenciesHandler;
            _GetAMLCurrenciesHandler = getAMLCurrenciesHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Currency.GetAll}")]
        [APIActionInfo(APIMessageActionInfo.Currency.GetAll.Code, APIMessageActionInfo.Currency.GetAll.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Currency.GetAll.Description}", $"{APIMessageActionInfo.Currency.GetAll.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAllCurrenciesResponse>), Description = $"{APIConstant.Response.Currency.Read}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Currency.Error}")]
        public async Task<IActionResult> GetAll()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAllCurrenciesResponse>> result = await _GetAllCurrenciesHandler.DoActionAsync();
            return await Ok200(result.Result);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Currency.GetAML}")]
        [APIActionInfo(APIMessageActionInfo.Currency.GetAML.Code, APIMessageActionInfo.Currency.GetAML.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Currency.GetAML.Description}", $"{APIMessageActionInfo.Currency.GetAML.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAMLCurrenciesResponse>), Description = $"{APIConstant.Response.Currency.ReadAML}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Currency.ErrorAML}")]
        public async Task<IActionResult> GetAML()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAMLCurrenciesResponse>> result = await _GetAMLCurrenciesHandler.DoActionAsync();
            return await Ok200(result.Result);
        }
    }
}
