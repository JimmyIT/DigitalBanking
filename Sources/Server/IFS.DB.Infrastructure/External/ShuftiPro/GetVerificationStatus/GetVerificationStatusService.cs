using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Common.ShuftiPro;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using IFS.DB.Infrastructure.External.ShuftiPro.GetVerificationURL;
using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain = IFS.DB.Application.Domain.ShuftiPro.GetVerificationStatus;

namespace IFS.DB.Infrastructure.External.ShuftiPro.GetVerificationStatus
{
    public class GetVerificationStatusService : BaseShuftiProAPIService, IGetVerificationStatusService
    {
		private string _SelfieCode = "SELFY";
		
        private readonly IGetVerificationStatusValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public GetVerificationStatusService(IParameterService parameterSvc,
            IGetVerificationStatusValidator validator,
            IAccountApplicationRepo accountApplicationRepo)
            : base(parameterSvc)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public async Task<ActionResult<Domain.GetVerificationStatusResponse>> DoActionAsync(string reference)
        {
            ActionResult<Domain.GetVerificationStatusResponse> result = new ActionResult<Domain.GetVerificationStatusResponse>()
            {
                Result = new Domain.GetVerificationStatusResponse() { }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(reference);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create model to call ShuftiPro
            Dictionary<string, string> requestBody = new Dictionary<string, string>();
            requestBody.Add("reference", reference);

            //Call ShuftiPro API
            string apiPath = ShuftiProAPIURLConst.GetVerificationStatus;

            ActionResult<GetVerificationStatusResponse> responseObj = await POSTJsonAsync<GetVerificationStatusResponse>(apiPath, requestBody);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            //Read Mapping File
            List<SupportTypeMapping> lstMapping = JsonConvert.DeserializeObject<List<SupportTypeMapping>>(EmbededResourceReader.GetResource("IFS.DB.Infrastructure.External.ShuftiPro.MappingSupportType.txt"));

            //Mapping Response Model
            GetVerificationStatusResponse shuftiProResponse = responseObj.Result;

            result.Result.Reference = shuftiProResponse.Reference;
            result.Result.Success = (shuftiProResponse.Event == "verification.accepted");

            if(!result.Result.Success)
            {
                //Get Account Application Info
                AccountApplication accAppEntity = await _AccountApplicationRepo.GetByShuftiProRefIdAsync(reference);
                if (accAppEntity != null)
                {
                    accAppEntity.ShuftiProRefId = string.Empty;
                    accAppEntity.ShuftiProVerificationUrl = string.Empty;
                    accAppEntity.ShuftiProUrlExpiryDate = null;

                    await _AccountApplicationRepo.UpdateAsync(accAppEntity);
                }

                return result;
            }   

            result.Result.DocumentFiles = new List<Domain.Document>();

            //Mapping Address File
            if (shuftiProResponse.VerificationData?.Address != null)
            {
                AddressInfo shuftiProAddress = shuftiProResponse.VerificationData.Address;

                //Mapping Personal Info
                result.Result.PersonalInfo = new Domain.PersonalInfo()
                {
                    FirstName = shuftiProAddress.Name?.FirstName,
                    MiddleName = shuftiProAddress.Name?.MiddleName,
                    LastName = shuftiProAddress.Name?.LastName,
                    FullName = shuftiProAddress.Name?.FullName
                };

                //Mapping Address
                string[]? splitAddress = shuftiProAddress.FullAddress?.Split(',');
                result.Result.Address = new Domain.Address()
                {
                    AddressLine1 = splitAddress?[0],
                    City = splitAddress?.Count() > 1 ? splitAddress[1] : string.Empty,
                    PostCode = splitAddress?.Count() > 2 ? splitAddress[2] : string.Empty,
                    Country = shuftiProAddress.Country,
                    FullAddress = shuftiProAddress.FullAddress
                };

                //Mapping Document File Upload
                result.Result.DocumentFiles.Add(new Domain.Document()
                {
                    FilePath = shuftiProResponse.Proofs.Address.Proof,
                    DocumentCode = lstMapping.FirstOrDefault(x => x.SupportType == shuftiProAddress.SelectedType[0]).DocumentCode
                });
            }

            //Mapping Document File
            if (shuftiProResponse.VerificationData?.Document != null)
            {
                DocumentInfo shuftiProDoc = shuftiProResponse.VerificationData.Document;

                //Mapping Personal Info
                result.Result.PersonalInfo = new Domain.PersonalInfo()
                {
                    FirstName = shuftiProDoc.Name?.FirstName,
                    MiddleName = shuftiProDoc.Name?.MiddleName,
                    LastName = shuftiProDoc.Name?.LastName,
                    FullName = shuftiProDoc.Name?.FullName,
                    DateOfBird = shuftiProDoc?.DateOfBirth,
                    Gender = shuftiProDoc?.Gender,
                    Country = shuftiProDoc?.Country
                };

                //Mapping Document File Upload
                result.Result.DocumentFiles.Add(new Domain.Document()
                {
                    FilePath = shuftiProResponse.Proofs.Document.Proof,
                    DocumentCode = lstMapping.FirstOrDefault(x => x.SupportType == shuftiProDoc.SelectedType[0]).DocumentCode,
                    DocumentNumber = shuftiProDoc.DocumentNumber,
                    ExpiryDate = shuftiProDoc.ExpiryDate
                });
            }
			
			//Mapping Face file
            if (shuftiProResponse.Proofs.Face != null)
            {
                result.Result.DocumentFiles.Add(new Domain.Document()
                {
                    FilePath = shuftiProResponse.Proofs.Face.Proof,
                    DocumentCode = _SelfieCode
                });
            }

            //Refill FirstName and LastName if empty
            if ((string.IsNullOrEmpty(result.Result.PersonalInfo.FirstName) || string.IsNullOrEmpty(result.Result.PersonalInfo.LastName)) && !string.IsNullOrEmpty(result.Result.PersonalInfo.FullName))
            {
                string[]? splitName = result.Result.PersonalInfo.FullName.Split(' ', 2);
                result.Result.PersonalInfo.FirstName = splitName?[0];
                result.Result.PersonalInfo.LastName = splitName?.Count() > 1 ? splitName[1] : string.Empty;
            }

            return result;
        }
    }
}
