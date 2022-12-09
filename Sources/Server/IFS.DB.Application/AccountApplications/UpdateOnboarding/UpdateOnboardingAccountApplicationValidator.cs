using FluentValidation;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.AccountApplications.UpdateOnboarding
{
    public interface IUpdateOnboardingAccountApplicationValidator
    {
        ValidationResult Validate(UpdateOnboardingAccountApplicationRequest accApp);
    }

    public class UpdateOnboardingAccountApplicationValidator : FluentValidatorBase<UpdateOnboardingAccountApplicationRequest>, IUpdateOnboardingAccountApplicationValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IParameterService _ParameterSvc;

        private OnboardingProductionEnum _OnboardingProduction;

        public UpdateOnboardingAccountApplicationValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo,
            IParameterService parameterSvc)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
            _ParameterSvc = parameterSvc;

            _OnboardingProduction = _ParameterSvc.GetOnboardingProductionAsync().GetAwaiter().GetResult();
        }

        public new ValidationResult Validate(UpdateOnboardingAccountApplicationRequest accApp)
        {
            FvResult result = base.Validate(accApp);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(accApp => accApp.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.ApplicationId)
                .Must((obj, id) => IsExistGuid(id))
                .WithCustomError(new NotExistedError());

            RuleFor(accApp => accApp.EntityType)
                .NotEmpty()
                .WithCustomError(new RequireError());

            //Personal Info
            RuleFor(accApp => accApp.PersonalInfo)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.PersonalInfo.Title)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PersonalInfo != null);

            RuleFor(accApp => accApp.PersonalInfo.FirstName)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PersonalInfo != null);

            RuleFor(accApp => accApp.PersonalInfo.LastName)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PersonalInfo != null);

            RuleFor(accApp => accApp.PersonalInfo.Gender)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PersonalInfo != null);

            RuleFor(accApp => accApp.PersonalInfo.DateOfBirth)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PersonalInfo != null);

            RuleFor(accApp => accApp.PersonalInfo.Nationality)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PersonalInfo != null);

            //Address
            RuleFor(accApp => accApp.Address)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.Address)
                .SetValidator(new AddressValidator(_ErrorMessageSvc))
                .WithCustomError(new RequireError())
                .When(accApp => accApp.Address != null);

            //Previous Address
            RuleFor(accApp => accApp.PreviousAddress)
                .SetValidator(new AddressValidator(_ErrorMessageSvc))
                .WithCustomError(new RequireError())
                .When(accApp => accApp.PreviousAddress != null);

            //Communication
            RuleFor(accApp => accApp.Communication)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.Communication.Email)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.Communication != null);

            //Source of Income
            RuleFor(accApp => accApp.SourceOfIncome)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(accApp => accApp.SourceOfIncome.EmploymentStatus)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null);

            RuleFor(accApp => accApp.SourceOfIncome.Occupation)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null && accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.FullTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.PartTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.SelfEmployed);

            RuleFor(accApp => accApp.SourceOfIncome.EmploymentDetail.Name)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null && accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.FullTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.PartTime);

            RuleFor(accApp => accApp.SourceOfIncome.EmploymentDetail.AddressDetail.AddressLine1)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null && accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.FullTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.PartTime);

            RuleFor(accApp => accApp.SourceOfIncome.EmploymentDetail.AddressDetail.City)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null && accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.FullTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.PartTime);

            RuleFor(accApp => accApp.SourceOfIncome.EmploymentDetail.AddressDetail.Country)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null && accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.FullTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.PartTime);

            RuleFor(accApp => accApp.SourceOfIncome.EmploymentDetail.NatureOfBusiness)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.SourceOfIncome != null && accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.FullTime || accApp.SourceOfIncome.EmploymentStatus == EmploymentStatusEnum.PartTime);

            //Document
            RuleForEach(accApp => accApp.DocumentFiles)
                .SetValidator(new DocumentValidator(_ErrorMessageSvc))
                .WithCustomError(new RequireError());

            //Contribution Detail 
            RuleFor(accApp => accApp.ContributionDetail)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => _OnboardingProduction == OnboardingProductionEnum.Tag);

            RuleFor(accApp => accApp.ContributionDetail.Amount)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.ContributionDetail != null && _OnboardingProduction == OnboardingProductionEnum.Tag);

            RuleFor(accApp => accApp.ContributionDetail.Currency)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.ContributionDetail != null && _OnboardingProduction == OnboardingProductionEnum.Tag);

            RuleFor(accApp => accApp.ContributionDetail.WalletAddress)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(accApp => accApp.ContributionDetail != null && _OnboardingProduction == OnboardingProductionEnum.Tag);
        }

        private bool IsExistGuid(Guid id)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            return entity != null;
        }
    }

    public class AddressValidator : FluentValidatorBase<Address>
    {
        public AddressValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(Address address)
        {
            FvResult result = base.Validate(address);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(address => address.AddressLine1)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(address => address.City)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(address => address.Country)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }

    public class DocumentValidator : FluentValidatorBase<Document>
    {
        public DocumentValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(Document document)
        {
            FvResult result = base.Validate(document);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(doc => doc.DocumentCode)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(doc => doc.FileName)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(doc => doc.Reference)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(doc => doc.ExpiryDate)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
