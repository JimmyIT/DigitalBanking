using IFS.DB.Application.Common.AMLtrac.Customers;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.AMLtrac.Customers.Import;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Results;
using IFS.MLTrac.OpenAPI.ClientConfig;
using IFS.MLTrac.OpenAPI.ClientConfig.Models.KYC.CreateEntityDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace IFS.DB.Infrastructure.External.AMLtrac.Customers.Import
{
    public class ImportCustomerService : BaseAMLtracOpenAPIService, IImportCustomerService
    {
        private readonly IImportCustomerValidator _Validator;

        public ImportCustomerService(IImportCustomerValidator validator,
            IParameterService parameterSvc)
            : base(parameterSvc)
        {
            _Validator = validator;
        }

        public async Task<ActionResult<ImportCustomerResponse>> DoActionAsync(ImportCustomerRequest customer)
        {
            ActionResult<ImportCustomerResponse> result = new ActionResult<ImportCustomerResponse>()
            {
                Result = new ImportCustomerResponse()
                {
                    EmailAddress = customer.EmailAddress,
                    DataItemID = customer.DataItemID
                }
            };

            //Validate
            ValidationResult valResult = _Validator.Validate(customer);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Create model to call AMLtrac API
            string hostId = await _ParameterSvc.GetAMLtracHostIdAsync();
            string branchCode = await _ParameterSvc.GetAMLtracBranchCodeAsync();

            CreateEntityRequest amlCus = ConvertToAmlCustomer(customer, hostId, branchCode);

            List<APIRequestHeader> lstRequestHeader = new List< APIRequestHeader>();
            lstRequestHeader.Add(new APIRequestHeader() { ParamKey = "WLScan", ParamValue = "true" });

            //Call AMLtracAPI
            string apiPath = OpenApiEndpoints.Ver1.AmlEntities.CreateNewEntity;
            ActionResult<CreateEntityResponse> responseObj = await POSTJsonWithHeaderAsync<CreateEntityResponse>(apiPath, JsonConvert.SerializeObject(amlCus), lstRequestHeader);
            if (!responseObj.IsNotError)
            {
                result.Validation = responseObj.Validation;
                return result;
            }

            result.Result.AMLtracRefId = responseObj.Result.EntityGuid.ToString();

            return result;
        }

        private string GetBusinessName(PersonalInformation personalInfo)
        {
            string title = string.Empty;

            string result = $"{title} {personalInfo.FirstName}"; 

            if (!string.IsNullOrEmpty(personalInfo.MiddleName))
            {
                result += $" {personalInfo.MiddleName.Substring(0, 1).ToUpper()}.";
            }

            result += $" {personalInfo.LastName}";

            return result;
        }

        private CreateEntityRequest ConvertToAmlCustomer(ImportCustomerRequest customer, string hostId, string branchCode)
        {
            CreateEntityRequest amlCus = new CreateEntityRequest();
            amlCus.BranchCode = branchCode;

            amlCus.HostSystems = new HostSystemsData()
            {
                LinkId = customer.DataItemID,
                HostSystemCode = hostId
            };

            amlCus.Email = customer.EmailAddress;
            amlCus.RelationshipStartDate = customer.DateSubmitted;
            amlCus.EntityType = customer.EntityType;

            amlCus.IndividualDetail = new IndividualDetailData()
            {
                FirstName = customer.PersonalInfo.FirstName,
                MiddleNames = customer.PersonalInfo.MiddleName,
                LastName = customer.PersonalInfo.LastName,
                Title = customer.PersonalInfo.Title,
                DOB = customer.PersonalInfo.DateOfBirth,
                Gender = customer.PersonalInfo.Gender,
                PassportNumber = customer.PersonalInfo.Passport,
                CitizenshipCountry = customer.PersonalInfo.CountryOfPassport
            };

            amlCus.ShortName = GetBusinessName(customer.PersonalInfo);
            amlCus.FullName = GetBusinessName(customer.PersonalInfo);
            amlCus.MobileNumber = customer.PersonalInfo.MobilePhone;
            amlCus.Telephone = customer.PersonalInfo.TelephoneNumber;
            amlCus.LinkedInProfile = customer.PersonalInfo.LinkedInProfile;

            amlCus.CompanyDetail = new CompanyDetailData()
            {
                BusinessType = customer.PersonalInfo.BusinessType,

            };

            //Set Address
            amlCus.CountryOfDomicile = customer.AddressDetail.Country;

            AddressDataModel addressModel = new AddressDataModel()
            {
                Type = "Primary",
                Line1 = customer.AddressDetail.AddressLine1,
                Line2 = customer.AddressDetail.AddressLine2,
                City = customer.AddressDetail.City,
                StateOrCounty = customer.AddressDetail.State,
                PostCode = customer.AddressDetail.PostCode,
                CountryCode = customer.AddressDetail.Country

            };

            amlCus.Addresses = new List<AddressDataModel>();
            amlCus.Addresses.Add(addressModel);

            //Set Source of Income
            if (customer.SourceOfIncome != null)
            {
                amlCus.IndividualDetail.OccupationCode = customer.SourceOfIncome.Occupation;
                amlCus.IndividualDetail.NatureOfBusiness = customer.SourceOfIncome.EmploymentDetail.NatureOfBusiness;

                amlCus.IndividualDetail.EmploymentDetail = new EmploymentDetailData()
                {
                    Status = (int)customer.SourceOfIncome.EmploymentStatus,
                    EmploymentAddress = new AddressDataModel()
                    {
                        Line1 = customer.SourceOfIncome.EmploymentDetail.AddressDetail.AddressLine1,
                        Line2 = customer.SourceOfIncome.EmploymentDetail.AddressDetail.AddressLine2,
                        City = customer.SourceOfIncome.EmploymentDetail.AddressDetail.City,
                        StateOrCounty = customer.SourceOfIncome.EmploymentDetail.AddressDetail.State,
                        PostCode = customer.SourceOfIncome.EmploymentDetail.AddressDetail.PostCode,
                        CountryCode = customer.SourceOfIncome.EmploymentDetail.AddressDetail.Country
                    },
                };
            }

            //Set Contribution Details
            if (customer.ContributionDetail != null)
            {
                amlCus.ContributionDetail = new ContributionDetails()
                {
                    Currency = customer.ContributionDetail.Currency,
                    Amount = customer.ContributionDetail.Amount,
                    WalletAddress = customer.ContributionDetail.WalletAddress
                };
            }

            return amlCus;
        }

    }
}
