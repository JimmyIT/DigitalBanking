using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.AccountApplication.UpdateOnboarding
{
    public class UpdateOnboardingAccountApplicationRequest
    {
        public Guid ApplicationId { get; set; }
        public int EntityType { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
        public Address Address { get; set; }
        public Address PreviousAddress { get; set; }
        public Communication Communication { get; set; }
        public SourceOfIncome SourceOfIncome { get; set; }
        public List<Document> DocumentFiles { get; set; }
        public AccountDetail AccountDetail { get; set; }
        public ContributionDetail ContributionDetail { get; set; }
    }

    public class PersonalInformation
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FormerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string BusinessType { get; set; }
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

    public class Communication
    {
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string LinkedInProfile { get; set; }
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

    public class Document
    {
        public string DocumentCode { get; set; }
        public string ProofCode { get; set; }
        public string FileName { get; set; }
        public string Reference { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool VerifiedByShuftiPro { get; set; }
        public string HexadecimalFormat { get; set; }
    }

    public class AccountDetail
    {
        public int COA { get; set; }
        public string Currency { get; set; }
        public LinkedAccount LinkedAccount { get; set; }
    }

    public class LinkedAccount
    {
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string InitialDeposit { get; set; }
    }

    public class ContributionDetail
    {
        public string Currency { get; set; }
        public decimal? Amount { get; set; }
        public string WalletAddress { get; set; }
    }
}
