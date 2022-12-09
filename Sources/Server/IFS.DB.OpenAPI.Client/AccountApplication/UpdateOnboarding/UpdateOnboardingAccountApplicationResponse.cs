using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.UpdateOnboarding
{
    public class UpdateOnboardingAccountApplicationResponse
    {
        public Guid ApplicationId { get; set; }
        public string EmailAddress { get; set; }
        public string Reference { get; set; }
    }
}
