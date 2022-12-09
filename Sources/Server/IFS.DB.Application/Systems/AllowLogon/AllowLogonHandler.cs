using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Systems.AllowLogon
{
    public interface IAllowLogonHandler : IBaseHandler
    {
        Task<ActionResult<bool>> DoActionAsync();
    }

    public class AllowLogonHandler : BaseHandler, IAllowLogonHandler
    {
        private readonly IBlockedIPRepo _BlockedIPRepo;
        private readonly IParameterService _ParameterSvc;
        private readonly IIPAddressProvider _IPAddressProvider;

        public AllowLogonHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IBlockedIPRepo blockedIPRepo,
            IParameterService parameterSvc,
            IIPAddressProvider iPAddressProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _BlockedIPRepo = blockedIPRepo;
            _ParameterSvc = parameterSvc;
            _IPAddressProvider = iPAddressProvider;
        }

        public async Task<ActionResult<bool>> DoActionAsync()
        {
            ActionResult<bool> result = new ActionResult<bool>()
            {
                Result = false
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            string ip = _IPAddressProvider.GetClientIPAddress();

            //Check Restrict LogonId and in list permitted
            if (await _ParameterSvc.GetRestrictLogonAsync())
            {
                if (!(await _ParameterSvc.GetPermittedIPsAsync()).ToUpper().Contains(ip.ToUpper()))
                {
                    IList<Error> errors = new List<Error>();
                    errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.LogonRestricted));
                    result.Validation = new ValidationResult(errors);
                    return result;
                }
            }
            //Check block IP
            else if ((await _BlockedIPRepo.GetByIPAsync(ip)) != null)
            {
                IList<Error> errors = new List<Error>();
                errors.Add(await _ErrorMessageSvc.CreateAsync(ErrorMessageCode.IPBlocked));
                result.Validation = new ValidationResult(errors);
                return result;
            }

            result.Result = true;

            return result;
        }
    }
}
