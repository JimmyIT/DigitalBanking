using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class SiteParameter
    {
        public float Version { get; set; }
        public string ImportFileListLocation { get; set; } = null!;
        public string DateFormat { get; set; } = null!;
        public bool ShowAccountNumbers { get; set; }
        public string SiteIp { get; set; } = null!;
        public string? SiteCommonName { get; set; }
        public string IBankUrl { get; set; } = null!;
        public bool IssueCertificates { get; set; }
        public bool IBankCertificatesOnly { get; set; }
        public string? Caname { get; set; }
        public string? Cacountry { get; set; }
        public string? Castate { get; set; }
        public string? Calocality { get; set; }
        public string? CaorgUnit { get; set; }
        public string? CacommonName { get; set; }
        public string? DatabaseType { get; set; }
        public string? SwiftmessagesLocation { get; set; }
        public string? SwiftmessagesExtension { get; set; }
        public string? SystemKey { get; set; }
        public string? BankSwiftid { get; set; }
        public string? AdministratorEmail { get; set; }
        public bool? TimeOutPeriod { get; set; }
        public string? InternalEmailServer { get; set; }
        public string? ExternalEmailServer { get; set; }
        public bool ApplicationDebugging { get; set; }
        public string BanksHomePage { get; set; } = null!;
        public string? StatusMessagesLocation { get; set; }
        public bool AllowNonOat { get; set; }
        public bool KeywordPromptInternalUsers { get; set; }
        public string? IntradayImportFileListLocation { get; set; }
        public int? InternalCustomerTimeOut { get; set; }
        public int? ExternalCustomerTimeOut { get; set; }
        public bool? AllowDomesticPayments { get; set; }
        public bool SystemLocked { get; set; }
        public string? InternalUserClientId { get; set; }
        public string? BaseCurrency { get; set; }
        public string? DefaultEntityLimitsCurrency { get; set; }
        public string? EmailNotificationsAccountApplications { get; set; }
        public int? NumberofDaysHistory { get; set; }
        public string? Lang { get; set; }
        public bool RetainSystemLockOnImportFailure { get; set; }
        public string? BankValInternationalUserId { get; set; }
        public string? BankValInternationalPin { get; set; }
        public bool? BankValValidateAccountNumber { get; set; }
        public bool? BankValRetrieveBankDetails { get; set; }
        public string? BankValUkuserId { get; set; }
        public string? BankValUkpin { get; set; }
        public DateTime? AccountTransferCutOffTime { get; set; }
        public bool ShowUserList { get; set; }
    }
}
