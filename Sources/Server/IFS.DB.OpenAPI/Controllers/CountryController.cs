using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Countries.GetAll;
using IFS.DB.Application.Countries.GetAML;
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
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.Country}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.Country}")]
    public class CountryController : BaseOpenAPIController
    {
        private readonly IGetAllCountriesHandler _GetAllCountriesHandler;
        private readonly IGetAMLCountriesHandler _GetAMLCountriesHandler;

        public CountryController(IErrorMessageService errorMessageSvc,
            IGetAllCountriesHandler getAllCountriesHandler,
            IGetAMLCountriesHandler getAMLCountriesHandler)
            : base(errorMessageSvc)
        {
            _GetAllCountriesHandler = getAllCountriesHandler;
            _GetAMLCountriesHandler = getAMLCountriesHandler;            
        }

        [HttpGet]
        [Route($"{APIConstant.Route.Country.GetAll}")]
        [APIActionInfo(APIMessageActionInfo.Country.GetAll.Code, APIMessageActionInfo.Country.GetAll.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Country.GetAll.Description}", $"{APIMessageActionInfo.Country.GetAll.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAllCountriesResponse>), Description = $"{APIConstant.Response.Country.Read}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Country.Error}")]
        public async Task<IActionResult> GetAll()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAllCountriesResponse>> result = await _GetAllCountriesHandler.DoActionAsync();
            return await Ok200(result.Result);

        }

        [HttpGet]
        [Route($"{APIConstant.Route.Country.GetAML}")]
        [APIActionInfo(APIMessageActionInfo.Country.GetAML.Code, APIMessageActionInfo.Country.GetAML.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.Country.GetAML.Description}", $"{APIMessageActionInfo.Country.GetAML.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAMLCountriesResponse>), Description = $"{APIConstant.Response.Country.Read}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.Country.Error}")]
        public async Task<IActionResult> GetAML()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAMLCountriesResponse>> result = await _GetAMLCountriesHandler.DoActionAsync();
            return await Ok200(result.Result);

        }
    }
}
