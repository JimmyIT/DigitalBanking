using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class IBankCustomer
    {
        public IBankCustomer()
        {
            UserProfiles = new HashSet<UserProfile>();
            XuserProfiles = new HashSet<XuserProfile>();
        }

        public string LogonId { get; set; } = null!;
        public string ClientNumber { get; set; } = null!;
        public string? ClientType { get; set; }
        public string Language { get; set; } = null!;
        public bool Internal { get; set; }
        public string HostBranchCustomer { get; set; } = null!;
        public bool? Activated { get; set; }
        public string? CountryCode { get; set; }
        public bool? BulkReleaseTransactions { get; set; }
        public int SignaturesRequiredForCancellation { get; set; }
        public bool? HasBeenUpgraded { get; set; }
        public bool? PaymentsInBulk { get; set; }
        public bool? CanUploadPaymentFiles { get; set; }
        public bool? PaymentFileCollection { get; set; }
        public string? PaymentFileCurrency { get; set; }
        public bool? IsTouristCard { get; set; }

        public virtual MseauthorityCode MseauthorityCode { get; set; } = null!;
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<XuserProfile> XuserProfiles { get; set; }
    }
}
