using IFS.DB.Application.ChartOfAccounts.GetCurrenciesByOnlineCOA;
using IFS.DB.Application.ChartOfAccounts.GetOnlineAvailableByEntityType;
using IFS.DB.Application.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    [Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.ChartOfAccount}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.ChartOfAccounts}")]
    public class ChartOfAccountController : BaseOpenAPIController
    {
        private readonly IGetOnlineAvailableCOAByEntityTypeHandler _GetOnlineAvailableCOAByEntityTypeHandler;
        private readonly IGetOnlineCOAByEntityTypeIdForNewAppHandler _GetOnlineCOAByEntityTypeIdForNewAppHandler;
        private readonly IGetCurrenciesByOnlineCOAHandler _GetCurrenciesOnlAvailByCOAIDHandler;
        public ChartOfAccountController(IErrorMessageService errorMessageSvc, 
            IGetOnlineAvailableCOAByEntityTypeHandler getOnlineAvailableCOAByEntityTypeHandler,
            IGetOnlineCOAByEntityTypeIdForNewAppHandler getOnlineCOAByEntityTypeIdForNewAppHandler,
            IGetCurrenciesByOnlineCOAHandler getCurrenciesOnlAvailByCOAIDHandler)
            : base(errorMessageSvc)
        {
            _GetOnlineAvailableCOAByEntityTypeHandler = getOnlineAvailableCOAByEntityTypeHandler;
            _GetOnlineCOAByEntityTypeIdForNewAppHandler = getOnlineCOAByEntityTypeIdForNewAppHandler;
            _GetCurrenciesOnlAvailByCOAIDHandler = getCurrenciesOnlAvailByCOAIDHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.ChartOfAccount.GetOnlineAvailableByEntityType}")]
        [APIActionInfo(APIMessageActionInfo.ChartOfAccount.GetOnlineAvailableByEntityType.Code, APIMessageActionInfo.ChartOfAccount.GetOnlineAvailableByEntityType.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.ChartOfAccount.GetOnlineAvailableByEntityType.Description}", $"{APIMessageActionInfo.ChartOfAccount.GetOnlineAvailableByEntityType.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetOnlineAvailableCOAByEntityTypeResponse), Description = $"{APIConstant.Response.ChartOfAccount.OnlineAvailableRead}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.ChartOfAccount.OnlineAvailableError}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.ChartOfAccount.OnlineAvailableError}")]
        public async Task<IActionResult> GetOnlAvailByEntityTypeId(int entityTypeId)
        {
            DigiBankResult.ActionResult<IEnumerable<GetOnlineAvailableCOAByEntityTypeResponse>> result = await _GetOnlineAvailableCOAByEntityTypeHandler.DoActionAsync(entityTypeId);
            return await Ok200(result.Result);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp}")]
        [APIActionInfo(APIMessageActionInfo.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp.Code, APIMessageActionInfo.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp.Description}", $"{APIMessageActionInfo.ChartOfAccount.GetOnlineCOAByEntityTypeIdForNewApp.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetOnlineCOAByEntityTypeIdForNewAppResponse), Description = $"{APIConstant.Response.ChartOfAccount.OnlineAvailableRead}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.ChartOfAccount.OnlineAvailableError}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.ChartOfAccount.OnlineAvailableError}")]
        public async Task<IActionResult> GetOnlineCOAByEntityTypeIdForNewApp(int entityTypeId)
        {
            DigiBankResult.ActionResult<IEnumerable<GetOnlineCOAByEntityTypeIdForNewAppResponse>> result = await _GetOnlineCOAByEntityTypeIdForNewAppHandler.DoActionAsync(entityTypeId);
            return await Ok200(result.Result);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.ChartOfAccount.GetCurrenciesByOnlineCOA}")]
        [APIActionInfo(APIMessageActionInfo.ChartOfAccount.GetCurrenciesByOnlineCOA.Code, APIMessageActionInfo.ChartOfAccount.GetCurrenciesByOnlineCOA.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.ChartOfAccount.GetCurrenciesByOnlineCOA.Description}", $"{APIMessageActionInfo.ChartOfAccount.GetCurrenciesByOnlineCOA.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(GetCurrenciesByOnlineCOAResponse), Description = $"{APIConstant.Response.ChartOfAccount.CurrenciesOnlineAvailableRead}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.ChartOfAccount.CurrenciesOnlineAvailableError}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.ChartOfAccount.CurrenciesOnlineAvailableError}")]
        public async Task<IActionResult> GetCurrenciesByOnlineCOA(int chartOfAccountId)
        {
            DigiBankResult.ActionResult<IEnumerable<GetCurrenciesByOnlineCOAResponse>> result = await _GetCurrenciesOnlAvailByCOAIDHandler.DoActionAsync(chartOfAccountId);
            return await Ok200(result.Result);
        }
    }
}
