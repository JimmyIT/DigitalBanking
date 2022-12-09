using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.Attributes;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.SourcesOfIncome.BusinessTypes.GetAMLEmployerBusinessTypes;
using IFS.DB.Application.SourcesOfIncome.JobTypes.GetAll;
using IFS.DB.Application.SourcesOfIncome.OccupationTypes.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigiBankResult = IFS.DB.Application.Domain.Results;

namespace IFS.DB.OpenAPI.Controllers
{
    //[Authorize]
    [Route($"{APIConstant.DefaultRoute}/{APIConstant.Route.Controller.SourcesOfIncome}")]
    [ApiController]
    [OpenApiTag($"{APIConstant.Tag.SourcesOfIncome}")]
    public class SourcesOfIncomeController : BaseOpenAPIController
    {
        private readonly IGetAllJobTypesHandler _GetAllJobTypesHandler;
        private readonly IGetAllOccupationTypesHandler _GetAllOccupationTypesHandler;
        private readonly IGetAMLEmployerBusinessTypesHandler _GetAMLEmployerBusinessTypesHandler;
        public SourcesOfIncomeController(IErrorMessageService errorMessageSvc, 
            IGetAllJobTypesHandler getAllJobTypesHandler,
            IGetAllOccupationTypesHandler getAllOccupationTypesHandler,
            IGetAMLEmployerBusinessTypesHandler getAMLEmployerBusinessTypesHandler)
            : base(errorMessageSvc)
        {
            _GetAllJobTypesHandler = getAllJobTypesHandler;
            _GetAllOccupationTypesHandler = getAllOccupationTypesHandler;
            _GetAMLEmployerBusinessTypesHandler = getAMLEmployerBusinessTypesHandler;
        }

        [HttpGet]
        [Route($"{APIConstant.Route.SourcesOfIncome.GetAMLJobTypes}")]
        [APIActionInfo(APIMessageActionInfo.SourcesOfIncome.GetAMLJobTypes.Code, APIMessageActionInfo.SourcesOfIncome.GetAMLJobTypes.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SourcesOfIncome.GetAMLJobTypes.Description}", $"{APIMessageActionInfo.SourcesOfIncome.GetAMLJobTypes.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAllJobTypesResponse>), Description = $"{APIConstant.Response.SourcesOfIncome.ReadAMLJobTypes}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SourcesOfIncome.ErrorAMLJobTypes}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SourcesOfIncome.ErrorAMLJobTypes}")]
        public async Task<IActionResult> GetAMLJobTypes()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAllJobTypesResponse>> result = await _GetAllJobTypesHandler.DoActionAsync();
            return await Ok200(result.Result);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.SourcesOfIncome.GetAMLOccupationTypes}")]
        [APIActionInfo(APIMessageActionInfo.SourcesOfIncome.GetAMLOccupationTypes.Code, APIMessageActionInfo.SourcesOfIncome.GetAMLOccupationTypes.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SourcesOfIncome.GetAMLOccupationTypes.Description}", $"{APIMessageActionInfo.SourcesOfIncome.GetAMLOccupationTypes.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAllOccupationTypesResponse>), Description = $"{APIConstant.Response.SourcesOfIncome.ReadAMLOccupations}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SourcesOfIncome.ErrorAMLOccupations}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SourcesOfIncome.ErrorAMLOccupations}")]
        public async Task<IActionResult> GetAMLOccupationTypes()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAllOccupationTypesResponse>> result = await _GetAllOccupationTypesHandler.DoActionAsync();
            return await Ok200(result.Result);
        }

        [HttpGet]
        [Route($"{APIConstant.Route.SourcesOfIncome.GetAMLEmployerBusinessTypes}")]
        [APIActionInfo(APIMessageActionInfo.SourcesOfIncome.GetAMLEmployerBusinessTypes.Code, APIMessageActionInfo.SourcesOfIncome.GetAMLEmployerBusinessTypes.Description)]
        [OpenApiOperation($"{APIMessageActionInfo.SourcesOfIncome.GetAMLEmployerBusinessTypes.Description}", $"{APIMessageActionInfo.SourcesOfIncome.GetAMLEmployerBusinessTypes.Description}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<GetAMLEmployerBusinessTypesResponse>), Description = $"{APIConstant.Response.SourcesOfIncome.ReadAMLBusinessTypes}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, typeof(IList<Error>), Description = $"{APIConstant.Response.SourcesOfIncome.ErrorAMLBusinessTypes}")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(Error), Description = $"{APIConstant.Response.SourcesOfIncome.ErrorAMLBusinessTypes}")]
        public async Task<IActionResult> GetAMLEmployerBusinessTypes()
        {
            DigiBankResult.ActionResult<IEnumerable<GetAMLEmployerBusinessTypesResponse>> result = await _GetAMLEmployerBusinessTypesHandler.DoActionAsync();
            return await Ok200(result.Result);
        }
    }
}
