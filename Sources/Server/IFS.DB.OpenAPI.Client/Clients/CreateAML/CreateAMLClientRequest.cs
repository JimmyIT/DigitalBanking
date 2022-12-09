using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Client.Clients.CreateAML
{
    public class CreateAMLClientRequest
    {
        public string EmailAddress { get; set; }
        public int EntityType { get; set; }
        public string DataItemID { get; set; }
        public DateTime DateSubmitted { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
        public Address AddressDetail { get; set; }
        public SourceOfIncome SourceOfIncome { get; set; }
        public ContributionDetail ContributionDetail { get; set; }
    }

    public class PersonalInformation
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobilePhone { get; set; }
        public string TelephoneNumber { get; set; }
        public string Passport { get; set; }
        public string CountryOfPassport { get; set; }
        public string BusinessType { get; set; }
        public string LinkedInProfile { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }

    public class SourceOfIncome
    {
        public EmploymentStatusEnum EmploymentStatus { get; set; }
        public string Occupation { get; set; }
        public Employer EmploymentDetail { get; set; }
    }

    public class Employer
    {
        public string Name { get; set; }
        public string NatureOfBusiness { get; set; }
        public Address AddressDetail { get; set; }
    }

    public class ContributionDetail
    {
        public string LinkedInProfile { get; set; }
        public string Currency { get; set; }
        public decimal? Amount { get; set; }
        public string WalletAddress { get; set; }
    }
}
