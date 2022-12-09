using IFS.DB.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Clients.CreateOnBoarding
{
    public class CreateOnBoardingClientRequest
    {
        public string EmailAddress { get; set; }
        public string ClientNumber { get; set; }
        public ClientTypeEnum ClientType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
    }

    public class PersonalInformation
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }

    }
}
