using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SessionInformation
    {
        public string SessionId { get; set; } = null!;
        public string? InternalId { get; set; }
        public string LogonId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? ClientNumber { get; set; }
        public string? AccountNumber { get; set; }
        public string? PageInView { get; set; }
        public string? OrderBy { get; set; }
        public int? SelectedIndex { get; set; }
        public string? SortChecked { get; set; }
        public string? DateFormat { get; set; }
        public string? DateFormatChecked { get; set; }
        public DateTime? StatementFrom { get; set; }
        public DateTime? StatementTo { get; set; }
        public bool? ShowStatementBalances { get; set; }
        public string? Filter { get; set; }
        public string? DatesChecked { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public DateTime? SpecificDateValueFrom { get; set; }
        public DateTime? SpecificDateValueTo { get; set; }
        public string? FilterChecked { get; set; }
        public bool ShowMultipleNarratives { get; set; }
        public int? FilterColumn { get; set; }
        public int? SortColumn { get; set; }
        public string? FilterValue0 { get; set; }
        public string? FilterValue1 { get; set; }
        public string? FilterValue2 { get; set; }
        public string? FilterValue3 { get; set; }
        public string? FilterValue4 { get; set; }
        public string? FilterValue5 { get; set; }
        public string? FilterValue6 { get; set; }
        public string? DealNumber { get; set; }
        public int? StatementSelectedIndex { get; set; }
        public string? CollectionReference { get; set; }
        public string? ClientInView { get; set; }
        public string? Lcreference { get; set; }
        public string? DrawingReference { get; set; }
        public int? BranchSelectedIndex { get; set; }
        public int? SelectedIndex1 { get; set; }
        public int? SelectedIndex2 { get; set; }
        public int? SelectedIndex3 { get; set; }
        public int? SelectedIndex4 { get; set; }
        public int? SelectedIndex5 { get; set; }
        public int? SelectedIndex6 { get; set; }
        public int? SelectedIndex7 { get; set; }
        public int? SelectedIndex8 { get; set; }
        public int? SelectedIndex9 { get; set; }
        public int? SelectedIndex10 { get; set; }
        public int? SelectedIndex11 { get; set; }
        public int? SelectedIndex12 { get; set; }
        public int? SelectedIndex13 { get; set; }
        public int? SelectedIndex14 { get; set; }
        public int? SelectedIndex15 { get; set; }
        public int? SelectedIndex16 { get; set; }
        public int? SelectedIndex17 { get; set; }
        public int? SelectedIndex18 { get; set; }
        public int? SelectedIndex19 { get; set; }
        public int? SelectedIndex20 { get; set; }
        public string? ProductId { get; set; }
        public string? BeneficiaryReference { get; set; }
        public string? TransferReference { get; set; }
        public string? PaymentReference { get; set; }
        public string? UsersInternalId { get; set; }
        public DateTime? Expiry { get; set; }
        public string? NavigationBarCode { get; set; }
        public string Ip { get; set; } = null!;
        public int? LogonAttempt { get; set; }
        public string? UsersCulture { get; set; }
        public string? LogonQueryString { get; set; }
        public string? CardNumber { get; set; }
        public int? CardStatusCode { get; set; }
        public string? PaymentCardLast4Digits { get; set; }
        public string? HostedDataId { get; set; }
    }
}
