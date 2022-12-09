using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Constants
{
    public struct EmailTemplateConst
    {
        private const string Route = "VM";

        #region A Values
        public const string ApplicationAccepted = $"{Route}\\ApplicationAcceptedEmail.vm";
        #endregion A Values

        #region R Values
        public const string RegisterKYCOnboarding = $"{Route}\\RegisterKYCOnboardingEmail.vm";
        public const string RegisterOnboarding = $"{Route}\\RegisterOnboardingEmail.vm";
        #endregion R Values

        #region T Values
        public const string ThankYouRegisterOnboarding = $"{Route}\\ThankYouRegisterOnboardingEmail.vm";
        #endregion T Values
    }
}