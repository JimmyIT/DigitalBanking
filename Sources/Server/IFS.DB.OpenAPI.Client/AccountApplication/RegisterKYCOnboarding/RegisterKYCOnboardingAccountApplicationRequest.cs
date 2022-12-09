using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.RegisterKYCOnboarding
{
    public class RegisterKYCOnboardingAccountApplicationRequest
    {
        public string LinkId { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BackCallBackURL { get; set; }
        public string SubmitCallBackURL { get; set; }
        public string AddDocReqs { get; set; }
        public int? RequestId { get; set; }
        public bool? AutoApproved { get; set; }
        public string CompanyCode { get; set; }
    }
}
