using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class XuserProfile
    {
        public string UniqueId { get; set; } = null!;
        public string? RequestReference { get; set; }
        public string? CustomersReference { get; set; }
        public string ClientNumber { get; set; } = null!;
        public int? NumberofAuthorisationAttempts { get; set; }
        public string Status { get; set; } = null!;
        public string LogonId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string InternalId { get; set; } = null!;
        public string? FullName { get; set; }
        public bool Administrator { get; set; }
        public bool IBankAdministrator { get; set; }
        public bool InternalUser { get; set; }
        public bool AccountManager { get; set; }
        public bool? PaymentsAllowed { get; set; }
        public bool? MultiCcyPaymentsAllowed { get; set; }
        public string? Team { get; set; }
        public bool OwnTeamOnly { get; set; }
        public DateTime? LastLoggedOn { get; set; }
        public string? MessageForUser { get; set; }
        public bool AccountLocked { get; set; }
        public int? LoginAttempts { get; set; }
        public string? LanguageCultureId { get; set; }
        public bool? ForceKeywordChange { get; set; }
        public bool? FirstTime { get; set; }
        public DateTime? SessionStarted { get; set; }
        public string? GroupId { get; set; }
        public bool? Active { get; set; }
        public string? AmendedBy { get; set; }
        public DateTime? AmendedOn { get; set; }
        public string? Email { get; set; }
        public bool? HasAcceptedTandC { get; set; }
        public bool? HasViewedSystemMsg { get; set; }
        public bool? HasBeenUpgraded { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? MobilePhoneNumberIdd { get; set; }
        public bool? AuthorisePaymentsInBulk { get; set; }
        public int NextKeywordNumberToAsk { get; set; }
        public bool? CanReleasePayments { get; set; }
        public bool? CanReleaseTransfers { get; set; }
        public bool? CanCreateCustomerTemplate { get; set; }
        public bool? CanSignOwnCustomerTemplate { get; set; }
        public bool AllowTransferToNonInternetEnableAccount { get; set; }
        public bool? CanUploadPaymentFiles { get; set; }
        public bool? HasLoadTouristCard { get; set; }
        public int? ResetAttempts { get; set; }

        public virtual IBankCustomer Logon { get; set; } = null!;
    }
}
