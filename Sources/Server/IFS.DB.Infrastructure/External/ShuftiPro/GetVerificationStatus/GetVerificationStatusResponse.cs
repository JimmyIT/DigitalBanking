using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.ShuftiPro.GetVerificationStatus
{
    public class GetVerificationStatusResponse
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("proofs")]
        public ProofData Proofs { get; set; }
        [JsonProperty("verification_data")]
        public VerificationData? VerificationData { get; set; }
    }

    public class ProofData
    {
        [JsonProperty("document")]
        public ProofDetail Document { get; set; }
        [JsonProperty("address")]
        public ProofDetail Address { get; set; }
		[JsonProperty("face")]
        public ProofDetail Face { get; set; }
    }

    public class ProofDetail
    {
        [JsonProperty("proof")]
        public string Proof { get; set; }
    }

    public class VerificationData
    {
        [JsonProperty("document")]
        public DocumentInfo Document { get; set; }
        [JsonProperty("address")]
        public AddressInfo Address { get; set; }
    }

    public class NameInfo
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }

    public class DocumentInfo
    {
        [JsonProperty("name")]
        public NameInfo Name { get; set; }
        [JsonProperty("dob")]
        public DateTime? DateOfBirth { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("expiry_date")]
        public DateTime? ExpiryDate { get; set; }
        [JsonProperty("document_number")]
        public string DocumentNumber { get; set; }
        [JsonProperty("selected_type")]
        public string[] SelectedType { get; set; }
        [JsonProperty("supported_types")]
        public string[] SupportedTypes { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class AddressInfo
    {
        [JsonProperty("name")]
        public NameInfo Name { get; set; }
        [JsonProperty("full_address")]
        public string FullAddress { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("selected_type")]
        public string[] SelectedType { get; set; }
        [JsonProperty("supported_types")]
        public string[] SupportedTypes { get; set; }
    }
}
