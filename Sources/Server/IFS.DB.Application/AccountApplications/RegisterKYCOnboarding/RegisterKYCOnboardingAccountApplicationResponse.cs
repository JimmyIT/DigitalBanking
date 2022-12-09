using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.AccountApplications.RegisterKYCOnboarding
{
    public class RegisterKYCOnboardingAccountApplicationResponse
    {
        public string LinkId { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid SessionId { get; set; }
        public string RegisterURL { get; set; }
    }
}
