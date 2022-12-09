using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Documents.GetShuftiProVerificationStatus
{
    public class GetShuftiProVerificationStatusResponse
    {
        public string Reference { get; set; }
        public bool Success { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public Address Address { get; set; }
        public List<Document> DocumentFiles { get; set; }
    }

    public class PersonalInfo
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }
    }

    public class Document
    {
        public string FilePath { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
