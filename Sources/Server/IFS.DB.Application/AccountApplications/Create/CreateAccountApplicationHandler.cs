using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.Create
{
    public interface ICreateAccountApplicationHandler : IBaseHandler
    {
        Task<ActionResult<CreateAccountApplicationResponse>> DoActionAsync(CreateAccountApplicationRequest accApp);
    }

    public class CreateAccountApplicationHandler : BaseHandler, ICreateAccountApplicationHandler
    {
        private readonly ICreateAccountApplicationValidator _Validator;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;
        private readonly IDateTimeProvider _DateTimeProvider;

        public CreateAccountApplicationHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            ICreateAccountApplicationValidator validator,
            IAccountApplicationRepo accountApplicationRepo,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _AccountApplicationRepo = accountApplicationRepo;
            _DateTimeProvider = dateTimeProvider;
        }

        public async Task<ActionResult<CreateAccountApplicationResponse>> DoActionAsync(CreateAccountApplicationRequest accApp)
        {
            ActionResult<CreateAccountApplicationResponse> result = new ActionResult<CreateAccountApplicationResponse>()
            {
                Result = new CreateAccountApplicationResponse() { ApplicationId = accApp.ApplicationId }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(accApp);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Config Mapping
            CreateAccountApplicationRequest.ConfigMapping();

            //Map Model to Entity
            AccountApplication entity = accApp.Adapt<AccountApplication>();
            entity.ExpiryDate = _DateTimeProvider.Now();
            entity.ExistingAccountHolder = false;
            entity.DebitCardRequired = false;
            entity.CreditCardRequired = false;
            entity.OwnershipType = string.Empty;
            entity.NumberofSignatories = 0;

            await _AccountApplicationRepo.InsertAsync(entity);

            return result;
        }
    }
}
