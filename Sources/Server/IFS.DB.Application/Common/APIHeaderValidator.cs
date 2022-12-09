using FluentValidation;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.API;
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

namespace IFS.DB.Application.Common
{
    public interface IAPIHeaderValidator
    {
        ValidationResult Validate(APIHeader header);

        IAPIHeaderValidator AddIdempotencyKey();
    }

    public class APIHeaderValidator : FluentValidatorBase<APIHeader>, IAPIHeaderValidator
    {
        private readonly IOpenAPIRepo _OpenAPIRepo;

        public APIHeaderValidator(IErrorMessageService errorMessageSvc,
            IOpenAPIRepo openAPIRepo)
            : base(errorMessageSvc)
        {
            _OpenAPIRepo = openAPIRepo;
        }

        public new ValidationResult Validate(APIHeader header)
        {
            FvResult result = base.Validate(header);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
        }

        public IAPIHeaderValidator AddIdempotencyKey()
        {
            RuleFor(header => header.IdempotencyKey)
                .NotEmpty()
                .WithCustomError(new MissingHeaderError());

            RuleFor(header => header.IdempotencyKey)
                .Must((obj, IdempotencyKey) => IsNewIdempotencyKey(IdempotencyKey))
                .WithCustomError(new ExistedError());

            return this;
        }

        private bool IsNewIdempotencyKey(string idempotencyKey)
        {
            IEnumerable<OpenApiMessage> lst = _OpenAPIRepo.GetMessageByIdempotencyKeyAsync(idempotencyKey).GetAwaiter().GetResult();
            return lst.Count() < 2;
        }
    }


}
