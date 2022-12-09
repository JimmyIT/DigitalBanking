using IFS.DB.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Constants;

namespace IFS.DB.Application.Customers.IdentifySSE
{
    public interface IIdentifySSECustomerHandler : IBaseHandler
    {
        Task<ActionResult<IdentifySSECustomerResponse>> DoActionAsync(IdentifySSECustomerRequest customer);
    }

    public class IdentifySSECustomerHandler : BaseHandler, IIdentifySSECustomerHandler
    {
        private readonly IIdentifySSECustomerValidator _Validator;
        private readonly ICustomerRepo _CustomerRepo;
        private readonly IUserProfileRepo _UserProfileRepo;
        private readonly ISplitAuthorityCodeRepo _SplitAuthorityCodeRepo;

        public IdentifySSECustomerHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator,
            IIdentifySSECustomerValidator validator,
            ICustomerRepo customerRepo,
            IUserProfileRepo userProfileRepo,
            ISplitAuthorityCodeRepo splitAuthorityCodeRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _CustomerRepo = customerRepo;
            _UserProfileRepo = userProfileRepo;
            _SplitAuthorityCodeRepo = splitAuthorityCodeRepo;
        }

        public async Task<ActionResult<IdentifySSECustomerResponse>> DoActionAsync(IdentifySSECustomerRequest customer)
        {
            ActionResult<IdentifySSECustomerResponse> result = new ActionResult<IdentifySSECustomerResponse>()
            {
                Result = new IdentifySSECustomerResponse() { InternalId = string.Empty }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(customer);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Get Data
            IBankCustomer entity = await _CustomerRepo.GetByLogonId(customer.LogonId);

            if (entity == null)
            {
                result.IsNotFound = true;

                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.LogonIdInvalid));
                result.Validation = new ValidationResult(errors);

                return result;
            }

            //Check Customer Client Type must SSE
            if (entity.ClientType != CustomerTypeConst.SSE)
            {
                result.IsNotFound = true;

                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.LogonIdInvalid));
                result.Validation = new ValidationResult(errors);

                return result;
            }

            //Check Customer Account Active 
            if (!entity.Activated.Value)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.CustomerAccountInActive));
                result.Validation = new ValidationResult(errors);

                return result;
            }

            //Get User Profile Info
            IList<UserProfile> lstUserProfile = await _UserProfileRepo.GetByLogonIdAsync(customer.LogonId);
            if (lstUserProfile == null || lstUserProfile.Count == 0)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.InternalServerError));
                result.Validation = new ValidationResult(errors);

                return result;
            }

            //Check Customer Account Locked 
            if (lstUserProfile[0].AccountLocked)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.CustomerAccountLocked));
                result.Validation = new ValidationResult(errors);

                return result;
            }

            result.Result.InternalId = lstUserProfile[0].InternalId.Trim();
            result.Result.PasswordLength = await _SplitAuthorityCodeRepo.GetPasswordLengthByInternalIdAsync(lstUserProfile[0].InternalId);

            return result;
        }
    }
}
