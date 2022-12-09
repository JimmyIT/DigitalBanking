using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.UpdateOnboarding
{
    public class UpdateOnboardingAccountApplicationResponse
    {
        public Guid ApplicationId { get; set; }
        public string EmailAddress { get; set; }
        public string Reference { get; set; }
    }
}
