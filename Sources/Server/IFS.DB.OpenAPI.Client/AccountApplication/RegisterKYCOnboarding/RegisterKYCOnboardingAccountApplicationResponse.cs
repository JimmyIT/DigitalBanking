using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.RegisterKYCOnboarding
{
    public class RegisterKYCOnboardingAccountApplicationResponse
    {
        public string LinkId { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid SessionId { get; set; }
        public string RegisterURL { get; set; }
    }
}
