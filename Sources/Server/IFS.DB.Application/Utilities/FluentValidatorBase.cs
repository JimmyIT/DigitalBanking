using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Results;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Utilities
{
    public class FluentValidatorBase<T> : AbstractValidator<T>
    {
        protected readonly IErrorMessageService _ErrorMessageSvc;

        public FluentValidatorBase(IErrorMessageService errorMessageSvc)
        {
            _ErrorMessageSvc = errorMessageSvc;

            CascadeMode = CascadeMode.StopOnFirstFailure;
            BuildRules();
        }

        /// <summary>
        /// Subclass must override this method
        /// </summary>
        protected virtual void BuildRules()
        {
            throw new NotImplementedException();
        }

        protected Domain.Results.ValidationResult ConvertErrorFromFluentToOur(ValidationResult validationResult)
        {
            IList<Error> errors = validationResult.Errors
                .Select(vf => new Error() { Code = vf.ErrorCode, Message = vf.ErrorMessage })
                .ToList();

            return new Domain.Results.ValidationResult(errors);
        }
    }

    public static class FluentValidationExtensions
    {
        /// <summary>
        /// New Placeholders: {ValidValues}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="exceptValues"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TEnum> IsInEnumExcept<T, TEnum>(this IRuleBuilder<T, TEnum> ruleBuilder, params TEnum[] exceptValues)
        {
            IEnumerable<string> validValues = EnumHelper.GetEnumValues<TEnum>()
                .Except(exceptValues.Select(x => x.ToString()));

            return ruleBuilder
                .IsInEnum()
                .Must((rootObject, propValue, context) =>
                {
                    context.MessageFormatter.AppendArgument("ValidValues", string.Join(", ", validValues));

                    return propValue != null && !exceptValues.Contains(propValue);
                })
                .WithMessage("{PropertyName} must be following [{ValidValues}]. You entered: '{PropertyValue}'");
        }

        public static IRuleBuilderOptions<T, TProperty> WithCustomError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Error error)
        {
            if (!string.IsNullOrWhiteSpace(error.Code))
            {
                rule.WithErrorCode(error.Code);
            }

            if (!string.IsNullOrWhiteSpace(error.Message))
            {
                rule.WithMessage(error.Message);
            }

            return rule;
        }
    }
}
