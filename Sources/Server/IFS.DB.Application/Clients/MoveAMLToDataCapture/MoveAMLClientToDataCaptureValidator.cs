using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FvResult = FluentValidation.Results.ValidationResult;

namespace IFS.DB.Application.Clients.MoveAMLToDataCapture
{
    public interface IMoveAMLClientToDataCaptureValidator
    {
        ValidationResult Validate(MoveAMLClientToDataCaptureRequest client);
    }

    public class MoveAMLClientToDataCaptureValidator : FluentValidatorBase<MoveAMLClientToDataCaptureRequest>, IMoveAMLClientToDataCaptureValidator
    {
        public MoveAMLClientToDataCaptureValidator(IErrorMessageService errorMessageSvc)
            : base(errorMessageSvc)
        { 
        }

        public new ValidationResult Validate(MoveAMLClientToDataCaptureRequest client)
        {
            FvResult result = base.Validate(client);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(client => client.AmlRefId)
                .NotEmpty()
                .WithCustomError(new RequireError());
        }
    }
}
