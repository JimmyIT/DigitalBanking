using FluentValidation;
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

namespace IFS.DB.Application.AccountApplications.CreateApplicationAcceptedNotification
{
    public interface ICreateAccountApplicationAcceptedNotificationValidator
    {
        ValidationResult Validate(CreateAccountApplicationAcceptedNotificationRequest accApp);
    }

    public class CreateAccountApplicationAcceptedNotificationValidator : FluentValidatorBase<CreateAccountApplicationAcceptedNotificationRequest>, ICreateAccountApplicationAcceptedNotificationValidator
    {
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public CreateAccountApplicationAcceptedNotificationValidator(IErrorMessageService errorMessageSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(errorMessageSvc)
        {
            _AccountApplicationRepo = accountApplicationRepo;
        }

        public new ValidationResult Validate(CreateAccountApplicationAcceptedNotificationRequest appNotification)
        {
            FvResult result = base.Validate(appNotification);
            return ConvertErrorFromFluentToOur(result);
        }

        protected override void BuildRules()
        {
            RuleFor(appNotification => appNotification.ApplicationId)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(appNotification => appNotification.ApplicationId)
                .Must((obj, id) => IsNewGuid(id))
                .WithCustomError(new NotExistedError());

            RuleFor(appNotification => appNotification.ClientNumber)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(appNotification => appNotification.PersonalInfo)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(appNotification => appNotification.Communication)
                .NotEmpty()
                .WithCustomError(new RequireError());

            RuleFor(appNotification => appNotification.Communication.Email)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(appNotification => appNotification.Communication != null && (appNotification.NotificationType == NotificationTypeEnum.Both || appNotification.NotificationType == NotificationTypeEnum.Email));

            RuleFor(accApp => accApp.Communication.MobilePhone)
                .NotEmpty()
                .WithCustomError(new RequireError())
                .When(appNotification => appNotification.Communication != null && (appNotification.NotificationType == NotificationTypeEnum.Both || appNotification.NotificationType == NotificationTypeEnum.SMS));
        }

        private bool IsNewGuid(Guid id)
        {
            AccountApplication entity = _AccountApplicationRepo.GetByIdAsync(id).GetAwaiter().GetResult();
            return entity == null;
        }
    }
}
