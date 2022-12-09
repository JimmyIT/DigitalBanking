using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
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

namespace IFS.DB.Application.Clients.CreateOnBoarding
{
    public interface ICreateOnBoardingClientValidator
    {
        ValidationResult Validate(CreateOnBoardingClientRequest client);
    }

    public class CreateOnBoardingClientValidator : FluentValidatorBase<CreateOnBoardingClientRequest>, ICreateOnBoardingClientValidator
    {
        private readonly IClientRepo _ClientRepo;

        public CreateOnBoardingClientValidator(IErrorMessageService errorMessageSvc,
            IClientRepo clientRepo)
            : base(errorMessageSvc)
        {
            _ClientRepo = clientRepo;
        }

        public new ValidationResult Validate(CreateOnBoardingClientRequest client)
        {
            FvResult result = base.Validate(client);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(client => client.ClientNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(client => client.ClientNumber)
                .Must((obj, clientNumber) => IsNewClientNumber(clientNumber))
                .WithCustomError(new ExistedError());
        }

        private bool IsNewClientNumber(string clientNumber)
        {
            Client entity = _ClientRepo.GetByClientNumberAsync(clientNumber).GetAwaiter().GetResult();
            return entity == null;
        }
    }
}
