using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFS.DB.EF
{
    public partial class DigitalBankingDBContext : DbContext
    {
        public DigitalBankingDBContext()
        {
        }

        public DigitalBankingDBContext(DbContextOptions<DigitalBankingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountApplication> AccountApplications { get; set; } = null!;
        public virtual DbSet<AccountManager> AccountManagers { get; set; } = null!;
        public virtual DbSet<AccountProfile> AccountProfiles { get; set; } = null!;
        public virtual DbSet<ApiErrorResource> ApiErrorResources { get; set; } = null!;
        public virtual DbSet<Audit> Audits { get; set; } = null!;
        public virtual DbSet<AuthorityCode> AuthorityCodes { get; set; } = null!;
        public virtual DbSet<BankDetail> BankDetails { get; set; } = null!;
        public virtual DbSet<BatchHeader> BatchHeaders { get; set; } = null!;
        public virtual DbSet<BatchItem> BatchItems { get; set; } = null!;
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; } = null!;
        public virtual DbSet<BlockedIp> BlockedIps { get; set; } = null!;
        public virtual DbSet<ButtonControl> ButtonControls { get; set; } = null!;
        public virtual DbSet<CardDetail> CardDetails { get; set; } = null!;
        public virtual DbSet<CardHolder> CardHolders { get; set; } = null!;
        public virtual DbSet<CardHolderDetail> CardHolderDetails { get; set; } = null!;
        public virtual DbSet<CardOutgoing> CardOutgoings { get; set; } = null!;
        public virtual DbSet<Charge> Charges { get; set; } = null!;
        public virtual DbSet<ChargeDetail> ChargeDetails { get; set; } = null!;
        public virtual DbSet<ChargeHistory> ChargeHistories { get; set; } = null!;
        public virtual DbSet<ChargeHistoryByClient> ChargeHistoryByClients { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientAlias> ClientAliases { get; set; } = null!;
        public virtual DbSet<ClientSmsconfirmation> ClientSmsconfirmations { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Count> Counts { get; set; } = null!;
        public virtual DbSet<CountryCode> CountryCodes { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<CustomResponse> CustomResponses { get; set; } = null!;
        public virtual DbSet<CustomerParameter> CustomerParameters { get; set; } = null!;
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; } = null!;
        public virtual DbSet<CustomerTransfer> CustomerTransfers { get; set; } = null!;
        public virtual DbSet<DebugLog> DebugLogs { get; set; } = null!;
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; } = null!;
        public virtual DbSet<Fxdeal> Fxdeals { get; set; } = null!;
        public virtual DbSet<GlobalBeneficiary> GlobalBeneficiaries { get; set; } = null!;
        public virtual DbSet<Glossary> Glossaries { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Header> Headers { get; set; } = null!;
        public virtual DbSet<Help> Helps { get; set; } = null!;
        public virtual DbSet<HistoricalPayment> HistoricalPayments { get; set; } = null!;
        public virtual DbSet<HistoricalTransfer> HistoricalTransfers { get; set; } = null!;
        public virtual DbSet<Holiday> Holidays { get; set; } = null!;
        public virtual DbSet<Host> Hosts { get; set; } = null!;
        public virtual DbSet<HostSystemAccessDetail> HostSystemAccessDetails { get; set; } = null!;
        public virtual DbSet<IBankCustomer> IBankCustomers { get; set; } = null!;
        public virtual DbSet<IMailAttachment> IMailAttachments { get; set; } = null!;
        public virtual DbSet<IMailBox> IMailBoxes { get; set; } = null!;
        public virtual DbSet<ImportMetaDatum> ImportMetaData { get; set; } = null!;
        public virtual DbSet<ImportParameter> ImportParameters { get; set; } = null!;
        public virtual DbSet<ImportedBacspaymentFile> ImportedBacspaymentFiles { get; set; } = null!;
        public virtual DbSet<ItemHistoryAuditTrail> ItemHistoryAuditTrails { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<LanguageCulture> LanguageCultures { get; set; } = null!;
        public virtual DbSet<Lc> Lcs { get; set; } = null!;
        public virtual DbSet<Lcdrawing> Lcdrawings { get; set; } = null!;
        public virtual DbSet<Lcrequest> Lcrequests { get; set; } = null!;
        public virtual DbSet<Lddeal> Lddeals { get; set; } = null!;
        public virtual DbSet<LicenceDetail> LicenceDetails { get; set; } = null!;
        public virtual DbSet<Mandate> Mandates { get; set; } = null!;
        public virtual DbSet<MenuDefinition> MenuDefinitions { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; } = null!;
        public virtual DbSet<MenuPermissionType> MenuPermissionTypes { get; set; } = null!;
        public virtual DbSet<MenuStructure> MenuStructures { get; set; } = null!;
        public virtual DbSet<MenusResource> MenusResources { get; set; } = null!;
        public virtual DbSet<MenusStyle> MenusStyles { get; set; } = null!;
        public virtual DbSet<MerchantCharge> MerchantCharges { get; set; } = null!;
        public virtual DbSet<MerchantVoucherList> MerchantVoucherLists { get; set; } = null!;
        public virtual DbSet<MessageDefinition> MessageDefinitions { get; set; } = null!;
        public virtual DbSet<Meter> Meters { get; set; } = null!;
        public virtual DbSet<MeterUsageAuditTrail> MeterUsageAuditTrails { get; set; } = null!;
        public virtual DbSet<Movement> Movements { get; set; } = null!;
        public virtual DbSet<Mqmessage> Mqmessages { get; set; } = null!;
        public virtual DbSet<MqmessageHistory> MqmessageHistories { get; set; } = null!;
        public virtual DbSet<MqmessageQueue> MqmessageQueues { get; set; } = null!;
        public virtual DbSet<MquserActionLog> MquserActionLogs { get; set; } = null!;
        public virtual DbSet<MquserActionType> MquserActionTypes { get; set; } = null!;
        public virtual DbSet<MseauthorityCode> MseauthorityCodes { get; set; } = null!;
        public virtual DbSet<Nanpcode> Nanpcodes { get; set; } = null!;
        public virtual DbSet<NetworkOperator> NetworkOperators { get; set; } = null!;
        public virtual DbSet<OpenApiMessage> OpenApiMessages { get; set; } = null!;
        public virtual DbSet<OpenApiMessageCode> OpenApiMessageCodes { get; set; } = null!;
        public virtual DbSet<OpenApiRole> OpenApiRoles { get; set; } = null!;
        public virtual DbSet<OpenApiUser> OpenApiUsers { get; set; } = null!;
        public virtual DbSet<OpenApiUserRole> OpenApiUserRoles { get; set; } = null!;
        public virtual DbSet<OutboundSystemMessage> OutboundSystemMessages { get; set; } = null!;
        public virtual DbSet<Parameter> Parameters { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentTemplate> PaymentTemplates { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public virtual DbSet<ProductCode> ProductCodes { get; set; } = null!;
        public virtual DbSet<ReceiptAllocation> ReceiptAllocations { get; set; } = null!;
        public virtual DbSet<RedemptionCharge> RedemptionCharges { get; set; } = null!;
        public virtual DbSet<ReleasedBatchHeaderHistory> ReleasedBatchHeaderHistories { get; set; } = null!;
        public virtual DbSet<ReleasedBatchItemHistory> ReleasedBatchItemHistories { get; set; } = null!;
        public virtual DbSet<RepayReclaim> RepayReclaims { get; set; } = null!;
        public virtual DbSet<Sccgateway> Sccgateways { get; set; } = null!;
        public virtual DbSet<SecurityLog> SecurityLogs { get; set; } = null!;
        public virtual DbSet<SessionInformation> SessionInformations { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<SiteParameter> SiteParameters { get; set; } = null!;
        public virtual DbSet<SiteSpecificHtmlcode> SiteSpecificHtmlcodes { get; set; } = null!;
        public virtual DbSet<SiteSpecificHtmlvalue> SiteSpecificHtmlvalues { get; set; } = null!;
        public virtual DbSet<Smscdefinition> Smscdefinitions { get; set; } = null!;
        public virtual DbSet<Smscode> Smscodes { get; set; } = null!;
        public virtual DbSet<Smsincoming> Smsincomings { get; set; } = null!;
        public virtual DbSet<Smsoutgoing> Smsoutgoings { get; set; } = null!;
        public virtual DbSet<Smsparameter> Smsparameters { get; set; } = null!;
        public virtual DbSet<Smsresponse> Smsresponses { get; set; } = null!;
        public virtual DbSet<Smsrule> Smsrules { get; set; } = null!;
        public virtual DbSet<SmsshortCode> SmsshortCodes { get; set; } = null!;
        public virtual DbSet<SmssystemDefault> SmssystemDefaults { get; set; } = null!;
        public virtual DbSet<SmstrafficCount> SmstrafficCounts { get; set; } = null!;
        public virtual DbSet<SplitAuthorityCode> SplitAuthorityCodes { get; set; } = null!;
        public virtual DbSet<Statement> Statements { get; set; } = null!;
        public virtual DbSet<SwiftqueueDetail> SwiftqueueDetails { get; set; } = null!;
        public virtual DbSet<SwiftqueueHeader> SwiftqueueHeaders { get; set; } = null!;
        public virtual DbSet<SystemDate> SystemDates { get; set; } = null!;
        public virtual DbSet<TagDefinition> TagDefinitions { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TestMessage> TestMessages { get; set; } = null!;
        public virtual DbSet<TopUpConfirm> TopUpConfirms { get; set; } = null!;
        public virtual DbSet<TopUpConfirmResponse> TopUpConfirmResponses { get; set; } = null!;
        public virtual DbSet<TopUpPending> TopUpPendings { get; set; } = null!;
        public virtual DbSet<TopUpRequest> TopUpRequests { get; set; } = null!;
        public virtual DbSet<TopUpResponse> TopUpResponses { get; set; } = null!;
        public virtual DbSet<TransactionJournal> TransactionJournals { get; set; } = null!;
        public virtual DbSet<Transfer> Transfers { get; set; } = null!;
        public virtual DbSet<UILanguageResource> UILanguageResources { get; set; } = null!;
        public virtual DbSet<UIResource> UIResources { get; set; } = null!;
        public virtual DbSet<UnallocatedReceipt> UnallocatedReceipts { get; set; } = null!;
        public virtual DbSet<UpgradeHistory> UpgradeHistories { get; set; } = null!;
        public virtual DbSet<UserPreference> UserPreferences { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<UserRight> UserRights { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;
        public virtual DbSet<VoucherValue> VoucherValues { get; set; } = null!;
        public virtual DbSet<XauthorityCode> XauthorityCodes { get; set; } = null!;
        public virtual DbSet<Xbeneficiary> Xbeneficiaries { get; set; } = null!;
        public virtual DbSet<XgroupMember> XgroupMembers { get; set; } = null!;
        public virtual DbSet<XiMailBox> XiMailBoxes { get; set; } = null!;
        public virtual DbSet<Xlcrequest> Xlcrequests { get; set; } = null!;
        public virtual DbSet<XmseauthorityCode> XmseauthorityCodes { get; set; } = null!;
        public virtual DbSet<Xpayment> Xpayments { get; set; } = null!;
        public virtual DbSet<Xtransfer> Xtransfers { get; set; } = null!;
        public virtual DbSet<XuserProfile> XuserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQL2019;Database=DigitalBanking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .IsClustered(false);

                entity.HasIndex(e => e.ClientNumber, "IX_Accounts_ClientNumber")
                    .IsClustered();

                entity.HasIndex(e => e.VoucherId, "IX_Accounts_VoucherID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ActualBalance).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.AvailableBalance).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.AverageBalance).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.EarliestDate).HasColumnType("datetime");

                entity.Property(e => e.HighestCredit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.HighestDebit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.InterestCreditDate).HasColumnType("datetime");

                entity.Property(e => e.InterestCreditFrequency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestCreditFrequencyPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterestDebitDate).HasColumnType("datetime");

                entity.Property(e => e.InterestDebitFrequency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterestDebitFrequencyPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastBalance).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LastMovementDate).HasColumnType("datetime");

                entity.Property(e => e.LastStatement).HasColumnType("datetime");

                entity.Property(e => e.OpenDate).HasColumnType("datetime");

                entity.Property(e => e.OverdraftExpiry).HasColumnType("datetime");

                entity.Property(e => e.OverdraftLimit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OverdraftReview).HasColumnType("datetime");

                entity.Property(e => e.PermittedActions)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SodavailableBalance)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("SODAvailableBalance");

                entity.Property(e => e.SodcurrentBalance)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("SODCurrentBalance");

                entity.Property(e => e.StatementDue).HasColumnType("datetime");

                entity.Property(e => e.StatementFrequency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatementFrequencyPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_Accounts_FK1");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CurrencyCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Currencies_Accounts_FK1");
            });

            modelBuilder.Entity<AccountApplication>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.HasIndex(e => e.EmailAddress, "IDX_EmailAddress")
                    .IsUnique();

                entity.HasIndex(e => e.SessionId, "IDX_SessionID")
                    .IsUnique();

                entity.Property(e => e.UniqueId)
                    .ValueGeneratedNever()
                    .HasColumnName("UniqueID");

                entity.Property(e => e.AccountHolderFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountHolderLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountHolderMiddleInitial)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccountHolderSuffix)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccountHolderTitle)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccountType01)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType02)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType03)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType04)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType05)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType06)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType07)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType08)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType09)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalDocumentRequirement)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedAccounId8)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccounID8");

                entity.Property(e => e.AllocatedAccountId1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID1");

                entity.Property(e => e.AllocatedAccountId10)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID10");

                entity.Property(e => e.AllocatedAccountId2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID2");

                entity.Property(e => e.AllocatedAccountId3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID3");

                entity.Property(e => e.AllocatedAccountId4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID4");

                entity.Property(e => e.AllocatedAccountId5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID5");

                entity.Property(e => e.AllocatedAccountId6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID6");

                entity.Property(e => e.AllocatedAccountId7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID7");

                entity.Property(e => e.AllocatedAccountId9)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedAccountID9");

                entity.Property(e => e.AllocatedAccountType1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedAccountType2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedAccountType3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedAccountType4)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedAccountType5)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AllocatedClientID");

                entity.Property(e => e.AmltracRefId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AMLtracRefId");

                entity.Property(e => e.BackCallBackUrl)
                    .IsUnicode(false)
                    .HasColumnName("BackCallBackURL");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorporationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateSubmitted).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorDescription).IsUnicode(false);

                entity.Property(e => e.ExistingAccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ExistingAccountID");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.FaxCountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.FirstTimeKyc).HasColumnName("FirstTimeKYC");

                entity.Property(e => e.FundingAccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FundingAccountID");

                entity.Property(e => e.FundingAccountType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundingBankName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FundingBanksCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FundingBanksCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FundingBanksRoutingId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("FundingBanksRoutingID");

                entity.Property(e => e.FundingBanksState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FundingCreditCardExpiryDate1)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FundingCreditCardExpiryDate2)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FundingCreditCardNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FundingCreditCardNumber2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FundingCreditCardType1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundingCreditCardType2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundingMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhoneNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhoneNumberCountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.KycRefId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("KYCRefId");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.MailingAddressCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressCountry)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MailingAddressState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberofSignatories).HasDefaultValueSql("((1))");

                entity.Property(e => e.OwnershipType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IND')")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                    
                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);    

                entity.Property(e => e.Referer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecondSignatoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityInfo1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityInfo2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityInfo3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityInfo4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityInfo5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.ShuftiProRefId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShuftiProUrlExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ShuftiProURLExpiryDate");

                entity.Property(e => e.ShuftiProVerificationUrl)
                    .IsUnicode(false)
                    .HasColumnName("ShuftiProVerificationURL");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubmitCallBackUrl)
                    .IsUnicode(false)
                    .HasColumnName("SubmitCallBackURL");

                entity.Property(e => e.TermLength)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdSignatoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TokenCompanyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhoneNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhoneNumberCountryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<AccountManager>(entity =>
            {
                entity.HasKey(e => e.AccountManagerId)
                    .IsClustered(false);

                entity.Property(e => e.AccountManagerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountManagerID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TeamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.AccountManagers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Teams_AccountManagers_FK1");
            });

            modelBuilder.Entity<AccountProfile>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .IsClustered(false);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");
            });

            modelBuilder.Entity<ApiErrorResource>(entity =>
            {
                entity.HasKey(e => e.ResourceKey);

                entity.ToTable("APIErrorResources");

                entity.Property(e => e.ResourceKey)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.HasKey(e => e.TransactionUi)
                    .HasName("Audit_PK");

                entity.ToTable("Audit");

                entity.Property(e => e.TransactionUi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TransactionUI")
                    .IsFixedLength();

                entity.Property(e => e.AuditType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransactionDetails)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<AuthorityCode>(entity =>
            {
                entity.HasKey(e => e.InternalId)
                    .IsClustered(false);

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.Keyword1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Keyword9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIN");

                entity.HasOne(d => d.Internal)
                    .WithOne(p => p.AuthorityCode)
                    .HasForeignKey<AuthorityCode>(d => d.InternalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserProfiles_AuthorityCodes_FK1");
            });

            modelBuilder.Entity<BankDetail>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("BankDetails_PK");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.ClearingCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.BankDetail)
                    .HasForeignKey<BankDetail>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_BankDetails_FK1");
            });

            modelBuilder.Entity<BatchHeader>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ClientNumber, e.CustomerReference }, "IDX_BatchHeaders_CustomerReference_ClientNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Status, "IX_BatchHeaders_Status");

                entity.HasIndex(e => e.IBankReference, "IX_BatchHeaders_iBankReference")
                    .IsUnique();

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DebitAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebitAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultCreditNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.Property(e => e.LastProcessed).HasColumnType("datetime");

                entity.Property(e => e.LastProcessedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittedOn).HasColumnType("datetime");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BatchItem>(entity =>
            {
                entity.HasKey(e => e.BatchItemId)
                    .IsClustered(false);

                entity.Property(e => e.Beneficiary)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryReference)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreditAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreditNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CreditType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.BatchItems)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BatchItems_BatchHeaders");

                entity.HasOne(d => d.PaymentTemplate)
                    .WithMany(p => p.BatchItems)
                    .HasForeignKey(d => d.PaymentTemplateId)
                    .HasConstraintName("FK_BatchItems_PaymentTemplates");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.BatchItems)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_BatchItems_PaymentTypes");
            });

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.AvailableForPayments).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01")
                    .IsFixedLength();

                entity.Property(e => e.T210102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02")
                    .HasDefaultValueSql("('/NEW/')");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.X210101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("X21___01_01")
                    .IsFixedLength();

                entity.Property(e => e.X210102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("X21___01_02");

                entity.Property(e => e.X210103)
                    .HasColumnType("text")
                    .HasColumnName("X21___01_03");

                entity.Property(e => e.X790114)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_14");

                entity.Property(e => e.X790121)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_21");

                entity.Property(e => e.X790129)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_29");

                entity.Property(e => e.X790141)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_41");

                entity.Property(e => e.X790146)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_46");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01");

                entity.Property(e => e.Xx201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_Beneficiaries_FK1");
            });

            modelBuilder.Entity<BlockedIp>(entity =>
            {
                entity.HasKey(e => e.Ip)
                    .HasName("BlockedIPs_PK");

                entity.ToTable("BlockedIPs");

                entity.Property(e => e.Ip)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.BlockedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ButtonControl>(entity =>
            {
                entity.HasKey(e => e.ButtonControlId)
                    .HasName("ButtonControl_PK")
                    .IsClustered(false);

                entity.ToTable("ButtonControl");

                entity.Property(e => e.ButtonControlId).HasColumnName("ButtonControlID");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.Level1ItemId).HasColumnName("Level1ItemID");

                entity.Property(e => e.Level2ItemId).HasColumnName("Level2ItemID");

                entity.Property(e => e.Level3ItemId).HasColumnName("Level3ItemID");
            });

            modelBuilder.Entity<CardDetail>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.HasIndex(e => e.CardId, "IX_CardDetails_CardID")
                    .IsUnique();

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.AccountRecordId).HasColumnName("AccountRecordID");

                entity.Property(e => e.CardId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CardID");
            });

            modelBuilder.Entity<CardHolder>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.CardDetailsRecordId).HasColumnName("CardDetailsRecordID");

                entity.HasOne(d => d.CardDetailsRecord)
                    .WithMany(p => p.CardHolders)
                    .HasForeignKey(d => d.CardDetailsRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardHolders_CardDetails");
            });

            modelBuilder.Entity<CardHolderDetail>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.CardHoldersRecordId).HasColumnName("CardHoldersRecordID");

                entity.Property(e => e.HolderId).HasColumnName("HolderID");

                entity.Property(e => e.MobilePhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.CardHoldersRecord)
                    .WithMany(p => p.CardHolderDetails)
                    .HasForeignKey(d => d.CardHoldersRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardHolderDetails_CardHolders");
            });

            modelBuilder.Entity<CardOutgoing>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("CardOutgoing");

                entity.Property(e => e.MessageId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("MessageID");

                entity.Property(e => e.CardId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CardID");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FunctionId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("FunctionID")
                    .IsFixedLength();

                entity.Property(e => e.OutParameter1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OutParameter2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OutParameter3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OutParameter4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OutParameter5)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SettlementCurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransactionDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.HasKey(e => e.Smscode)
                    .HasName("Charges_PK");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.Property(e => e.BalancingAccount)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChargeCr).HasColumnName("ChargeCR");

                entity.Property(e => e.ChargeDr).HasColumnName("ChargeDR");

                entity.Property(e => e.ChargeId).HasColumnName("ChargeID");

                entity.HasOne(d => d.ChargeNavigation)
                    .WithMany(p => p.Charges)
                    .HasForeignKey(d => d.ChargeId)
                    .HasConstraintName("ChargeDetails_Charges_FK1");
            });

            modelBuilder.Entity<ChargeDetail>(entity =>
            {
                entity.HasKey(e => e.ChargeId)
                    .HasName("ChargeDetails_PK");

                entity.Property(e => e.ChargeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ChargeID");

                entity.Property(e => e.ChargeAmount).HasColumnType("money");

                entity.Property(e => e.ChargePercent).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.MaxAmount).HasColumnType("money");

                entity.Property(e => e.MinAmount).HasColumnType("money");

                entity.Property(e => e.TotalCharged).HasColumnType("money");
            });

            modelBuilder.Entity<ChargeHistory>(entity =>
            {
                entity.HasKey(e => new { e.Smscode, e.Period })
                    .HasName("ChargeHistory_PK");

                entity.ToTable("ChargeHistory");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.Property(e => e.TotalCharged).HasColumnType("money");

                entity.HasOne(d => d.SmscodeNavigation)
                    .WithMany(p => p.ChargeHistories)
                    .HasForeignKey(d => d.Smscode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Charges_ChargeHistory_FK");
            });

            modelBuilder.Entity<ChargeHistoryByClient>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Smscode, e.Period })
                    .HasName("ChargeHistoryByClient_PK");

                entity.ToTable("ChargeHistoryByClient");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.Property(e => e.TotalCharged).HasColumnType("money");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ChargeHistoryByClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_ChargeHistoryByClient_FK");

                entity.HasOne(d => d.SmscodeNavigation)
                    .WithMany(p => p.ChargeHistoryByClients)
                    .HasForeignKey(d => d.Smscode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Charges_ChargeHistoryByClient_FK");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientNumber)
                    .HasName("Clients_PK")
                    .IsClustered(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountManagerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountManagerID");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientTown)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddressCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IntroducerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IntroducerID");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mneumonic)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneOperator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PINCode");

                entity.Property(e => e.RegistrationType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('P')")
                    .IsFixedLength();

                entity.Property(e => e.ScccardNo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("SCCCardNo");

                entity.Property(e => e.Sccexpiry)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SCCExpiry");

                entity.Property(e => e.SeeNameOnIncomingMsg).HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowNameToReceiver).HasDefaultValueSql("((1))");

                entity.Property(e => e.SignUpDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TopUpConfirmDirectory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TopUpRequestDirectory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TopUpResponseDirectory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.AccountManager)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AccountManagerId)
                    .HasConstraintName("AccountManagers_Clients_FK1");
            });

            modelBuilder.Entity<ClientAlias>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Alias })
                    .HasName("ClientAlias_PK")
                    .IsClustered(false);

                entity.ToTable("ClientAlias");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.Alias)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneNo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientAliases)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_ClientAlias_FK1");
            });

            modelBuilder.Entity<ClientSmsconfirmation>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Smscode })
                    .HasName("ClientSMSConfirmations_PK");

                entity.ToTable("ClientSMSConfirmations");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSmsconfirmations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_ClientSMSConfirmations_FK1");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasKey(e => e.OurRef)
                    .IsClustered(false);

                entity.Property(e => e.OurRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscountDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountInterest).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DraweeCharge1Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DraweeCharge1Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DraweeCharge2Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DraweeCharge2Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DraweeCharge3Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DraweeCharge3Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DraweeCharge4Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DraweeCharge4Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DraweeCharge5Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DraweeCharge5Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DraweeDetails).IsUnicode(false);

                entity.Property(e => e.DraweeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawerCharge1Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DrawerCharge1Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawerCharge2Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DrawerCharge2Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawerCharge3Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DrawerCharge3Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawerCharge4Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DrawerCharge4Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawerCharge5Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DrawerCharge5Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.OurPay).IsUnicode(false);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tenor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Warnings)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YourReceive).IsUnicode(false);

                entity.Property(e => e.YourRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.ClientNumber)
                    .HasConstraintName("FK_Collections_Clients");
            });

            modelBuilder.Entity<Count>(entity =>
            {
                entity.HasKey(e => new { e.EventDate, e.Type });

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<CountryCode>(entity =>
            {
                entity.HasKey(e => e.CountryCode1)
                    .HasName("CountryCodes_PK");

                entity.Property(e => e.CountryCode1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CountryCode")
                    .IsFixedLength();

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Iddcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDDCode")
                    .IsFixedLength();

                entity.Property(e => e.NationalPrefix)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.CountryCodes)
                    .HasForeignKey(d => d.CurrencyCode)
                    .HasConstraintName("Currencies_CountryCodes_FK1");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode)
                    .IsClustered(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CutOffTime).HasColumnType("datetime");

                entity.Property(e => e.PaymentDaysNotice).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CustomResponse>(entity =>
            {
                entity.HasKey(e => e.FileName)
                    .IsClustered(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.SentWhen)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerParameter>(entity =>
            {
                entity.HasKey(e => e.LogonId)
                    .HasName("CustomerParameters_PK")
                    .IsClustered(false);

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.LimitsCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CustomerPayment>(entity =>
            {
                entity.HasIndex(e => e.HostReference, "IX_CustomerPayments_HostReference")
                    .IsUnique();

                entity.HasIndex(e => e.Status, "IX_CustomerPayments_Status");

                entity.HasIndex(e => e.IBankReference, "IX_CustomerPayments_iBankReference")
                    .IsUnique();

                entity.Property(e => e.BeneficiaryReference)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreditAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreditCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DebitAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebitAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(13, 6)");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.HostReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.Property(e => e.IsFromMbank).HasColumnName("IsFromMBank");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.PaymentTemplateDetails).HasColumnType("xml");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.PaymentTemplate)
                    .WithMany(p => p.CustomerPayments)
                    .HasForeignKey(d => d.PaymentTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPayments_PaymentTemplates");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.CustomerPayments)
                    .HasForeignKey(d => d.PaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPayments_PaymentTypes");
            });

            modelBuilder.Entity<CustomerTransfer>(entity =>
            {
                entity.HasIndex(e => e.HostReference, "IX_CustomerTransfers_HostReference")
                    .IsUnique();

                entity.HasIndex(e => e.Status, "IX_CustomerTransfers_Status");

                entity.HasIndex(e => e.IBankReference, "IX_CustomerTransfers_iBankReference")
                    .IsUnique();

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreditAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreditCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DebitAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebitAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("decimal(13, 6)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.HostReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.Property(e => e.IsFromMbank).HasColumnName("IsFromMBank");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ValueDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DebugLog>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .IsClustered(false);

                entity.ToTable("DebugLog");

                entity.Property(e => e.RecordId)
                    .ValueGeneratedNever()
                    .HasColumnName("RecordID");

                entity.Property(e => e.Class)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Details).HasColumnType("text");

                entity.Property(e => e.Function)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Header)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.ErrorNumber)
                    .IsClustered(false);

                entity.ToTable("ErrorLog");

                entity.Property(e => e.ErrorNumber).ValueGeneratedNever();

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DetailedDescription).HasColumnType("text");

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.PageBeingViewed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestBeingMade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.HasKey(e => new { e.Currency1, e.Currency2 });

                entity.Property(e => e.Currency1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BuyCurrency1Rate)
                    .HasColumnType("decimal(13, 6)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Operand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SellCurrency1Rate)
                    .HasColumnType("decimal(13, 6)")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Fxdeal>(entity =>
            {
                entity.HasKey(e => e.DealNumber)
                    .IsClustered(false);

                entity.ToTable("FXDeals");

                entity.Property(e => e.DealNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BoughtAmount).HasColumnType("money");

                entity.Property(e => e.BoughtCharges).HasColumnType("money");

                entity.Property(e => e.BoughtCommission).HasColumnType("money");

                entity.Property(e => e.BoughtCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BoughtOptionDate).HasColumnType("datetime");

                entity.Property(e => e.BoughtStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BoughtValueDate).HasColumnType("datetime");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OurPay)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.OurReceive)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SoldAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SoldCharges).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SoldCommission).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SoldCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SoldOptionDate).HasColumnType("datetime");

                entity.Property(e => e.SoldStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SoldValueDate).HasColumnType("datetime");

                entity.Property(e => e.YourPay)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.YourReceive)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Fxdeals)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_FXDeals_FK1");
            });

            modelBuilder.Entity<GlobalBeneficiary>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01")
                    .IsFixedLength();

                entity.Property(e => e.T210102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.X210101)
                    .HasColumnType("text")
                    .HasColumnName("X21___01_01");

                entity.Property(e => e.X210102)
                    .HasColumnType("text")
                    .HasColumnName("X21___01_02");

                entity.Property(e => e.X210103)
                    .HasColumnType("text")
                    .HasColumnName("X21___01_03");

                entity.Property(e => e.X790114)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_14");

                entity.Property(e => e.X790121)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_21");

                entity.Property(e => e.X790129)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_29");

                entity.Property(e => e.X790141)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_41");

                entity.Property(e => e.X790146)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_46");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01");

                entity.Property(e => e.Xx201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");
            });

            modelBuilder.Entity<Glossary>(entity =>
            {
                entity.HasKey(e => e.GlossaryId)
                    .IsClustered(false);

                entity.ToTable("Glossary");

                entity.Property(e => e.GlossaryId)
                    .ValueGeneratedNever()
                    .HasColumnName("GlossaryID");

                entity.Property(e => e.Definition).HasColumnType("text");

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("Groups_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.LogonId, "IDX_Groups_LogonID");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.HasKey(e => e.RecordType)
                    .HasName("Headers_PK");

                entity.Property(e => e.RecordType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndId).HasColumnName("EndID");

                entity.Property(e => e.StartId).HasColumnName("StartID");
            });

            modelBuilder.Entity<Help>(entity =>
            {
                entity.HasKey(e => e.HelpId)
                    .IsClustered(false);

                entity.ToTable("Help");

                entity.Property(e => e.HelpId)
                    .ValueGeneratedNever()
                    .HasColumnName("HelpID");

                entity.Property(e => e.AdditionalNotes).HasColumnType("text");

                entity.Property(e => e.Consequence1).HasColumnType("text");

                entity.Property(e => e.Consequence10).HasColumnType("text");

                entity.Property(e => e.Consequence2).HasColumnType("text");

                entity.Property(e => e.Consequence3).HasColumnType("text");

                entity.Property(e => e.Consequence4).HasColumnType("text");

                entity.Property(e => e.Consequence5).HasColumnType("text");

                entity.Property(e => e.Consequence6).HasColumnType("text");

                entity.Property(e => e.Consequence7).HasColumnType("text");

                entity.Property(e => e.Consequence8).HasColumnType("text");

                entity.Property(e => e.Consequence9).HasColumnType("text");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.OptionName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Page)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubOption)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Value1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value10)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value3)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value4)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value5)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value6)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value7)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value8)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Value9)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoricalPayment>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T11S0101)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T11S0102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T11S0103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_03")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01");

                entity.Property(e => e.T210102)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T32A0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32A0102)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T32A0103)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_03");

                entity.Property(e => e.T5001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T50___01");

                entity.Property(e => e.T5201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T52___01");

                entity.Property(e => e.T5301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T53___01");

                entity.Property(e => e.T54A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_01");

                entity.Property(e => e.T54A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_02");

                entity.Property(e => e.T54D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_01");

                entity.Property(e => e.T54D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_02");

                entity.Property(e => e.T54D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_03");

                entity.Property(e => e.T54D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_04");

                entity.Property(e => e.T54D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_05");

                entity.Property(e => e.T56A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_01");

                entity.Property(e => e.T56A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_02");

                entity.Property(e => e.T56D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_01");

                entity.Property(e => e.T56D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_02");

                entity.Property(e => e.T56D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_03");

                entity.Property(e => e.T56D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_04");

                entity.Property(e => e.T56D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_05");

                entity.Property(e => e.T5701)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T57___01");

                entity.Property(e => e.T5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T59___01");

                entity.Property(e => e.T700101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_01");

                entity.Property(e => e.T700102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_02");

                entity.Property(e => e.T700103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_03");

                entity.Property(e => e.T700104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_04");

                entity.Property(e => e.T700105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_05");

                entity.Property(e => e.T700106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_06");

                entity.Property(e => e.T700107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_07");

                entity.Property(e => e.T700108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_08");

                entity.Property(e => e.T700109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_09");

                entity.Property(e => e.T700110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_10");

                entity.Property(e => e.T7101)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("T71___01")
                    .IsFixedLength();

                entity.Property(e => e.T720101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_01");

                entity.Property(e => e.T720102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_02");

                entity.Property(e => e.T720103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_03");

                entity.Property(e => e.T720104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_04");

                entity.Property(e => e.T720105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_05");

                entity.Property(e => e.T720106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_06");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.X32A0101)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.X32A0102)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.X32A0103)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_03")
                    .IsFixedLength();

                entity.Property(e => e.X54D0102)
                    .HasColumnType("text")
                    .HasColumnName("X54_D_01_02");

                entity.Property(e => e.X56D0102)
                    .HasColumnType("text")
                    .HasColumnName("X56_D_01_02");

                entity.Property(e => e.X5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("X59___01");

                entity.Property(e => e.X700101)
                    .HasColumnType("text")
                    .HasColumnName("X70___01_01");

                entity.Property(e => e.X700201)
                    .HasColumnType("text")
                    .HasColumnName("X70___02_01");

                entity.Property(e => e.X720101)
                    .HasColumnType("text")
                    .HasColumnName("X72___01_01");

                entity.Property(e => e.X790129)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_29");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01")
                    .IsFixedLength();

                entity.Property(e => e.Xx201)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.HistoricalPayments)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_HistoricalPayments_FK1");
            });

            modelBuilder.Entity<HistoricalTransfer>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T11S0101)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T11S0102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T11S0103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_03")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01");

                entity.Property(e => e.T210102)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T32A0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32A0102)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T32A0103)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_03");

                entity.Property(e => e.T5001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T50___01");

                entity.Property(e => e.T5201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T52___01");

                entity.Property(e => e.T5301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T53___01");

                entity.Property(e => e.T5401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54___01");

                entity.Property(e => e.T5601)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56___01");

                entity.Property(e => e.T5701)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T57___01");

                entity.Property(e => e.T5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T59___01");

                entity.Property(e => e.T700101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_01");

                entity.Property(e => e.T700102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_02");

                entity.Property(e => e.T700103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_03");

                entity.Property(e => e.T700104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_04");

                entity.Property(e => e.T700105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_05");

                entity.Property(e => e.T700106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_06");

                entity.Property(e => e.T700107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_07");

                entity.Property(e => e.T700108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_08");

                entity.Property(e => e.T700109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_09");

                entity.Property(e => e.T700110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_10");

                entity.Property(e => e.T7101)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("T71___01")
                    .IsFixedLength();

                entity.Property(e => e.T720101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_01");

                entity.Property(e => e.T720102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_02");

                entity.Property(e => e.T720103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_03");

                entity.Property(e => e.T720104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_04");

                entity.Property(e => e.T720105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_05");

                entity.Property(e => e.T720106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_06");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.X32A0101)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.X32A0102)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.X32A0103)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_03")
                    .IsFixedLength();

                entity.Property(e => e.X700101)
                    .HasColumnType("text")
                    .HasColumnName("X70___01_01");

                entity.Property(e => e.X700201)
                    .HasColumnType("text")
                    .HasColumnName("X70___02_01");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01")
                    .IsFixedLength();

                entity.Property(e => e.Xx201)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.HistoricalTransfers)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_HistoricalTransfers_FK1");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.Currency })
                    .HasName("PK_Holidays_1");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.HasIndex(e => e.HostName, "Hosts_UC1")
                    .IsUnique();

                entity.Property(e => e.HostId).ValueGeneratedNever();

                entity.Property(e => e.AccessCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccessId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HostName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HostWebserviceUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HostSystemAccessDetail>(entity =>
            {
                entity.HasKey(e => e.HostSystemId)
                    .HasName("HostSystemAccessDetails_PK");

                entity.Property(e => e.HostSystemId).ValueGeneratedNever();

                entity.Property(e => e.AccessCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccessId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HostSystemLiteral)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IBankCustomer>(entity =>
            {
                entity.HasKey(e => e.LogonId)
                    .HasName("PK_iBankCustomers_LogonID")
                    .IsClustered(false);

                entity.ToTable("iBankCustomers");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.Activated)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HasBeenUpgraded)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HostBranchCustomer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ENG')")
                    .IsFixedLength();

                entity.Property(e => e.PaymentFileCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SignaturesRequiredForCancellation).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<IMailAttachment>(entity =>
            {
                entity.HasKey(e => e.MailAttachmentId);

                entity.ToTable("iMailAttachments");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileSize).HasDefaultValueSql("('')");

                entity.Property(e => e.FileType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.MailMessageReceived)
                    .WithMany(p => p.IMailAttachmentMailMessageReceiveds)
                    .HasForeignKey(d => d.MailMessageReceivedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_iMailAttachments_iMailBoxesReceived");

                entity.HasOne(d => d.MailMessageSent)
                    .WithMany(p => p.IMailAttachmentMailMessageSents)
                    .HasForeignKey(d => d.MailMessageSentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_iMailAttachments_iMailBoxesSent");
            });

            modelBuilder.Entity<IMailBox>(entity =>
            {
                entity.HasKey(e => e.MailMessageId)
                    .IsClustered(false);

                entity.ToTable("iMailBoxes");

                entity.Property(e => e.Body)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Cc)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CC");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.Priority)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReplyPermitted)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ImportMetaDatum>(entity =>
            {
                entity.HasKey(e => e.ImportMetaDataId)
                    .HasName("ImportMetaData_PK")
                    .IsClustered(false);

                entity.Property(e => e.DataType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FieldName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InputFilename)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OutputFilename)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.ImportMetaData)
                    .HasForeignKey(d => d.HostId)
                    .HasConstraintName("Hosts_ImportMetaData_FK1");
            });

            modelBuilder.Entity<ImportParameter>(entity =>
            {
                entity.HasKey(e => e.ImportParametersId);

                entity.Property(e => e.FullImportAt).HasColumnType("datetime");

                entity.Property(e => e.FullImportMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('M')")
                    .IsFixedLength();

                entity.Property(e => e.ImportFileDateFormat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('E')")
                    .IsFixedLength();

                entity.Property(e => e.ImportFileFormat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportFilesLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NegativeAmountsRepresent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PositionofDrcrind)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PositionofDRCRInd")
                    .IsFixedLength();

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.ImportParameters)
                    .HasForeignKey(d => d.HostId)
                    .HasConstraintName("Hosts_ImportParameters_FK1");
            });

            modelBuilder.Entity<ImportedBacspaymentFile>(entity =>
            {
                entity.HasKey(e => e.ImportedFileId);

                entity.ToTable("ImportedBACSPaymentFiles");

                entity.HasIndex(e => e.IBankReference, "IX_ImportedBACSFiles_iBankReference");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.Property(e => e.ImportedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemHistoryAuditTrail>(entity =>
            {
                entity.ToTable("ItemHistoryAuditTrail");

                entity.Property(e => e.AuditRecordCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.ItemDetails).HasColumnType("text");

                entity.Property(e => e.RecordId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("RecordID");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueIdofItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UniqueIDofItem");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.LanguageCultureId)
                    .IsClustered(false);

                entity.Property(e => e.LanguageCultureId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordDescription9)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LanguageCulture>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("LanguageCulture");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Lc>(entity =>
            {
                entity.HasKey(e => e.OurRef)
                    .IsClustered(false);

                entity.ToTable("LCs");

                entity.Property(e => e.OurRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryDetails).IsUnicode(false);

                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConsigneeDetails).IsUnicode(false);

                entity.Property(e => e.ConsigneeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DrawingSequence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.LastShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.Lcamount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("LCAmount");

                entity.Property(e => e.OpenedDate).HasColumnType("datetime");

                entity.Property(e => e.PartShipment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Term)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermEvent)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tolerance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TolerancePct)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalContingent).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalDrawn).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UndrawnAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Warnings)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YourRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Lcs)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_LCs_FK1");
            });

            modelBuilder.Entity<Lcdrawing>(entity =>
            {
                entity.HasKey(e => new { e.OurRef, e.DrawingSequence })
                    .IsClustered(false);

                entity.ToTable("LCDrawings");

                entity.Property(e => e.OurRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawingSequence)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AcceptanceDate).HasColumnType("datetime");

                entity.Property(e => e.AcceptedAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.BillAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DebitAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DrawingDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.FreightAndInterest).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OtherBankForOpener).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OurChargesForBeneficiary).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OurChargesForOpener).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Warnings)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YourRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.OurRefNavigation)
                    .WithMany(p => p.Lcdrawings)
                    .HasForeignKey(d => d.OurRef)
                    .HasConstraintName("LCs_LCDrawings_FK1");
            });

            modelBuilder.Entity<Lcrequest>(entity =>
            {
                entity.HasKey(e => e.RequestReference)
                    .IsClustered(false);

                entity.ToTable("LCRequests");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AmendmentLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentLogonID");

                entity.Property(e => e.AmendmentUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentUserID");

                entity.Property(e => e.AmendmentVerifiedLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentVerifiedLogonID");

                entity.Property(e => e.AmendmentVerifiedUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentVerifiedUserID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DeletionLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionLogonID");

                entity.Property(e => e.DeletionUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionUserID");

                entity.Property(e => e.DeletionVerifiedLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionVerifiedLogonID");

                entity.Property(e => e.DeletionVerifiedUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionVerifiedUserID");

                entity.Property(e => e.EntryLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryLogonID");

                entity.Property(e => e.EntryUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryUserID");

                entity.Property(e => e.EntryVerifiedLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryVerifiedLogonID");

                entity.Property(e => e.EntryVerifiedUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryVerifiedUserID");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T2301)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T23___01");

                entity.Property(e => e.T2701)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T27___01")
                    .IsFixedLength();

                entity.Property(e => e.T31C01)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T31_C_01");

                entity.Property(e => e.T31D0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T31_D_01_01");

                entity.Property(e => e.T31D0102)
                    .HasMaxLength(29)
                    .IsUnicode(false)
                    .HasColumnName("T31_D_01_02");

                entity.Property(e => e.T32B0101)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_B_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32B0102)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_B_01_02");

                entity.Property(e => e.T39A01)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T39_A_01");

                entity.Property(e => e.T39B01)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("T39_B_01");

                entity.Property(e => e.T39C01)
                    .HasColumnType("text")
                    .HasColumnName("T39_C_01");

                entity.Property(e => e.T40A01)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("T40_A_01");

                entity.Property(e => e.T41A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T41_A_01");

                entity.Property(e => e.T41D01)
                    .HasColumnType("text")
                    .HasColumnName("T41_D_01");

                entity.Property(e => e.T42A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T42_A_01");

                entity.Property(e => e.T42C01)
                    .HasColumnType("text")
                    .HasColumnName("T42_C_01");

                entity.Property(e => e.T42D01)
                    .HasColumnType("text")
                    .HasColumnName("T42_D_01");

                entity.Property(e => e.T42M01)
                    .HasColumnType("text")
                    .HasColumnName("T42_M_01");

                entity.Property(e => e.T42P01)
                    .HasColumnType("text")
                    .HasColumnName("T42_P_01");

                entity.Property(e => e.T43P01)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T43_P_01");

                entity.Property(e => e.T43T01)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T43_T_01");

                entity.Property(e => e.T44A01)
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasColumnName("T44_A_01");

                entity.Property(e => e.T44B01)
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasColumnName("T44_B_01");

                entity.Property(e => e.T44C01)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T44_C_01");

                entity.Property(e => e.T44D01)
                    .HasColumnType("text")
                    .HasColumnName("T44_D_01");

                entity.Property(e => e.T45A01)
                    .HasColumnType("text")
                    .HasColumnName("T45_A_01");

                entity.Property(e => e.T46A01)
                    .HasColumnType("text")
                    .HasColumnName("T46_A_01");

                entity.Property(e => e.T47A01)
                    .HasColumnType("text")
                    .HasColumnName("T47_A_01");

                entity.Property(e => e.T4801)
                    .HasColumnType("text")
                    .HasColumnName("T48___01");

                entity.Property(e => e.T4901)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("T49___01");

                entity.Property(e => e.T5001)
                    .HasColumnType("text")
                    .HasColumnName("T50___01");

                entity.Property(e => e.T51A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T51_A_01");

                entity.Property(e => e.T51D01)
                    .HasColumnType("text")
                    .HasColumnName("T51_D_01");

                entity.Property(e => e.T53A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T53_A_01");

                entity.Property(e => e.T53D01)
                    .HasColumnType("text")
                    .HasColumnName("T53_D_01");

                entity.Property(e => e.T57A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T57_A_01");

                entity.Property(e => e.T57B01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T57_B_01");

                entity.Property(e => e.T57D01)
                    .HasColumnType("text")
                    .HasColumnName("T57_D_01");

                entity.Property(e => e.T5901)
                    .HasColumnType("text")
                    .HasColumnName("T59___01");

                entity.Property(e => e.T71B01)
                    .HasColumnType("text")
                    .HasColumnName("T71_B_01");

                entity.Property(e => e.T7201)
                    .HasColumnType("text")
                    .HasColumnName("T72___01");

                entity.Property(e => e.T7801)
                    .HasColumnType("text")
                    .HasColumnName("T78___01");
            });

            modelBuilder.Entity<Lddeal>(entity =>
            {
                entity.HasKey(e => e.DealNumber)
                    .HasName("LDDeals_PK")
                    .IsClustered(false);

                entity.ToTable("LDDeals");

                entity.Property(e => e.DealNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CommencementDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DealStatus)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DealType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Interest).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.InterestSettlementAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaturityDate).HasColumnType("datetime");

                entity.Property(e => e.OurCommencement).HasColumnType("text");

                entity.Property(e => e.OurMaturity).HasColumnType("text");

                entity.Property(e => e.Principal).HasColumnType("money");

                entity.Property(e => e.ShortDealType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YourCommencement).HasColumnType("text");

                entity.Property(e => e.YourMaturity).HasColumnType("text");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Lddeals)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_LDDeals_FK1");
            });

            modelBuilder.Entity<LicenceDetail>(entity =>
            {
                entity.HasKey(e => e.Lna)
                    .IsClustered(false);

                entity.Property(e => e.Lna)
                    .HasMaxLength(110)
                    .IsUnicode(false)
                    .HasColumnName("LNA");

                entity.Property(e => e.BanksName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CipherCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate)
                    .HasMaxLength(110)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mandate>(entity =>
            {
                entity.HasKey(e => e.MandateId)
                    .HasName("Mandates_PK")
                    .IsClustered(false);

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ProductID")
                    .IsFixedLength();

                entity.Property(e => e.SendAdviceTo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SendAdviceTo2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SendAdviceTo3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SendAdviceTo4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SendAdviceTo5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MenuDefinition>(entity =>
            {
                entity.HasKey(e => e.MenuStructureId)
                    .HasName("PK_MenuStructure");

                entity.ToTable("MenuDefinition");

                entity.Property(e => e.MenuStructureId).HasColumnName("MenuStructureID");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.MenuDefinitions)
                    .HasForeignKey(d => d.MenuItemId)
                    .HasConstraintName("FK_MenuStructure_MenuItems");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.MenuItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuItemID");

                entity.Property(e => e.Administrators)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HelpPageId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HelpPageID");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MenuItemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mse)
                    .IsRequired()
                    .HasColumnName("MSE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Sse)
                    .IsRequired()
                    .HasColumnName("SSE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Users)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MenuPermission>(entity =>
            {
                entity.HasIndex(e => new { e.ValueId, e.MenuItemId }, "IDX_CustomerID_MenuItemID")
                    .IsUnique();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ValueId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ValueID");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.MenuPermissions)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPermissions_MenuItems");

                entity.HasOne(d => d.PermissionType)
                    .WithMany(p => p.MenuPermissions)
                    .HasForeignKey(d => d.PermissionTypeId)
                    .HasConstraintName("FK_MenuPermissions_MenuPermissionTypes");
            });

            modelBuilder.Entity<MenuPermissionType>(entity =>
            {
                entity.HasKey(e => e.PermissionTypeId)
                    .HasName("PK_PermissionTypes");

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionType)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuStructure>(entity =>
            {
                entity.ToTable("MenuStructure");

                entity.Property(e => e.MenuLevel).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MenusResource>(entity =>
            {
                entity.HasKey(e => new { e.MenuItemId, e.LanguageCultureId });

                entity.ToTable("MenusResource");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.LanguageCultureId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.MenusResources)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuItems_MenusResource_FK1");
            });

            modelBuilder.Entity<MenusStyle>(entity =>
            {
                entity.HasKey(e => e.MenuStyleId)
                    .HasName("MenusStyle_PK")
                    .IsClustered(false);

                entity.ToTable("MenusStyle");

                entity.Property(e => e.MenuStyleId).HasColumnName("MenuStyleID");

                entity.Property(e => e.Level1Width).HasDefaultValueSql("((140))");

                entity.Property(e => e.Level2Width).HasDefaultValueSql("((200))");

                entity.Property(e => e.Level3Width).HasDefaultValueSql("((200))");
            });

            modelBuilder.Entity<MerchantCharge>(entity =>
            {
                entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MerchantVoucherList>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.VoucherId })
                    .HasName("MerchantVoucherList_PK");

                entity.ToTable("MerchantVoucherList");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.MerchantVoucherLists)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Merchants_MerchantVoucherList_FK1");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.MerchantVoucherLists)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vouchers_MerchantVoucherList_FK1");
            });

            modelBuilder.Entity<MessageDefinition>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .IsClustered(false);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.IncludeInSwiftmessage).HasColumnName("IncludeInSWIFTMessage");

                entity.Property(e => e.MessageNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.Tag)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TagOption)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TagType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Meter>(entity =>
            {
                entity.ToTable("Meter");

                entity.Property(e => e.LastRecharged).HasColumnType("datetime");
            });

            modelBuilder.Entity<MeterUsageAuditTrail>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("MeterUsageAuditTrail");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EnteredOn).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ItemID");

                entity.Property(e => e.Notes).HasColumnType("text");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.MovementId)
                    .IsClustered(false);

                entity.Property(e => e.MovementId).HasColumnName("MovementID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.BalanceUpdated).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ChargeCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Narrative1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatementUpdated).HasDefaultValueSql("((0))");

                entity.Property(e => e.TransCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ValueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");
            });

            modelBuilder.Entity<Mqmessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("MQMessage");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalInfo1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalInfo2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalCode).HasMaxLength(200);

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.Cctimestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("CCTimestamp");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreditCard).HasMaxLength(200);

                entity.Property(e => e.CreditCardType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.Direction)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IpgTransactionId).HasMaxLength(50);

                entity.Property(e => e.LoadUnloadAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.OriginalReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TxnDateTime).HasColumnType("datetime");

                entity.Property(e => e.TxnNarrative).HasMaxLength(25);

                entity.Property(e => e.TxnType).HasMaxLength(10);
            });

            modelBuilder.Entity<MqmessageHistory>(entity =>
            {
                entity.HasKey(e => e.MessageHistoryId);

                entity.ToTable("MQMessageHistory");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalInfo1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalInfo2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalCode).HasMaxLength(200);

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.Cctimestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("CCTimestamp");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreditCard).HasMaxLength(200);

                entity.Property(e => e.CreditCardType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.Direction)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IpgTransactionId).HasMaxLength(50);

                entity.Property(e => e.LoadUnloadAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.OriginalReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TxnDateTime).HasColumnType("datetime");

                entity.Property(e => e.TxnNarrative).HasMaxLength(25);

                entity.Property(e => e.TxnType).HasMaxLength(10);
            });

            modelBuilder.Entity<MqmessageQueue>(entity =>
            {
                entity.HasKey(e => e.QueueId);

                entity.ToTable("MQMessageQueue");

                entity.Property(e => e.Cctimestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("CCTimestamp");

                entity.Property(e => e.ErrorDesc).IsUnicode(false);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MqmessageQueues)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MQMessageQueue_MQMessage");
            });

            modelBuilder.Entity<MquserActionLog>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("MQUserActionLog");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(1000);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MquserActionLogs)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MQUserActionLog_MQMessage");

                entity.HasOne(d => d.UserActionType)
                    .WithMany(p => p.MquserActionLogs)
                    .HasForeignKey(d => d.UserActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MQUserActionLog_MQUserActionType");
            });

            modelBuilder.Entity<MquserActionType>(entity =>
            {
                entity.HasKey(e => e.UserActionTypeId);

                entity.ToTable("MQUserActionType");

                entity.Property(e => e.ActionName).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<MseauthorityCode>(entity =>
            {
                entity.HasKey(e => e.LogonId)
                    .HasName("MSEAuthorityCodes_PK")
                    .IsClustered(false);

                entity.ToTable("MSEAuthorityCodes");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.AuthorityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Logon)
                    .WithOne(p => p.MseauthorityCode)
                    .HasForeignKey<MseauthorityCode>(d => d.LogonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iBankCustomers_MSEAuthorityCodes_FK1");
            });

            modelBuilder.Entity<Nanpcode>(entity =>
            {
                entity.HasKey(e => e.SubDialingCode)
                    .HasName("NANPCodes_PK");

                entity.ToTable("NANPCodes");

                entity.Property(e => e.SubDialingCode).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NetworkOperator>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("NetworkOperators_PK");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.ActualOperatorId).HasColumnName("ActualOperatorID");

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.NetworkOperatorNavigation)
                    .HasForeignKey<NetworkOperator>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_NetworkOperators_FK1");
            });

            modelBuilder.Entity<OpenApiMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("OpenAPIMessage");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MessageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Url).HasColumnName("URL");

                entity.HasOne(d => d.MessageCodeNavigation)
                    .WithMany(p => p.OpenApiMessages)
                    .HasForeignKey(d => d.MessageCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpenAPIMessage_OpenAPIMessageCode");
            });

            modelBuilder.Entity<OpenApiMessageCode>(entity =>
            {
                entity.HasKey(e => e.MessageCode)
                    .HasName("PK_OpenAPIMessageCode");

                entity.ToTable("OpenAPIMessageCode");

                entity.Property(e => e.MessageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpenApiRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_OpenAPIRole");

                entity.ToTable("OpenAPIRole");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<OpenApiUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_OpenAPIUser");

                entity.ToTable("OpenAPIUser");

                entity.HasIndex(e => e.Username, "IX_OpenAPIUser")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpenApiUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId)
                    .HasName("PK_OpenAPIUserRole");

                entity.ToTable("OpenAPIUserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.OpenApiUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpenAPIUserRole_OpenAPIRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OpenApiUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpenAPIUserRole_OpenAPIUser");
            });

            modelBuilder.Entity<OutboundSystemMessage>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("pk_RecordID");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.OutputFileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.HasKey(e => e.ParamKey);

                entity.Property(e => e.ParamKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParamDescription)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParamValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserEditable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T11S0101)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T11S0102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T11S0103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_03")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01");

                entity.Property(e => e.T210102)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T32A0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32A0102)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T32A0103)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_03");

                entity.Property(e => e.T5001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T50___01");

                entity.Property(e => e.T5201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T52___01");

                entity.Property(e => e.T5301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T53___01");

                entity.Property(e => e.T54A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_01");

                entity.Property(e => e.T54A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_02");

                entity.Property(e => e.T54D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_01");

                entity.Property(e => e.T54D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_02");

                entity.Property(e => e.T54D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_03");

                entity.Property(e => e.T54D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_04");

                entity.Property(e => e.T54D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_05");

                entity.Property(e => e.T56A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_01");

                entity.Property(e => e.T56A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_02");

                entity.Property(e => e.T56D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_01");

                entity.Property(e => e.T56D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_02");

                entity.Property(e => e.T56D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_03");

                entity.Property(e => e.T56D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_04");

                entity.Property(e => e.T56D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_05");

                entity.Property(e => e.T5701)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T57___01");

                entity.Property(e => e.T5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T59___01");

                entity.Property(e => e.T700101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_01");

                entity.Property(e => e.T700102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_02");

                entity.Property(e => e.T700103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_03");

                entity.Property(e => e.T700104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_04");

                entity.Property(e => e.T700105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_05");

                entity.Property(e => e.T700106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_06");

                entity.Property(e => e.T700107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_07");

                entity.Property(e => e.T700108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_08");

                entity.Property(e => e.T700109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_09");

                entity.Property(e => e.T700110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_10");

                entity.Property(e => e.T7101)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("T71___01")
                    .IsFixedLength();

                entity.Property(e => e.T720101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_01");

                entity.Property(e => e.T720102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_02");

                entity.Property(e => e.T720103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_03");

                entity.Property(e => e.T720104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_04");

                entity.Property(e => e.T720105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_05");

                entity.Property(e => e.T720106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_06");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.X32A0101)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.X32A0102)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.X32A0103)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_03")
                    .IsFixedLength();

                entity.Property(e => e.X54D0102)
                    .HasColumnType("text")
                    .HasColumnName("X54_D_01_02");

                entity.Property(e => e.X56D0102)
                    .HasColumnType("text")
                    .HasColumnName("X56_D_01_02");

                entity.Property(e => e.X5901)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("X59___01");

                entity.Property(e => e.X700101)
                    .HasColumnType("text")
                    .HasColumnName("X70___01_01");

                entity.Property(e => e.X700201)
                    .HasColumnType("text")
                    .HasColumnName("X70___02_01");

                entity.Property(e => e.X720101)
                    .HasColumnType("text")
                    .HasColumnName("X72___01_01");

                entity.Property(e => e.X790129)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_29");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01")
                    .IsFixedLength();

                entity.Property(e => e.Xx201)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_Payments_FK1");
            });

            modelBuilder.Entity<PaymentTemplate>(entity =>
            {
                entity.HasIndex(e => new { e.ClientNumber, e.CustomerReference }, "IDX_PaymentTemplates_CustomerRef_ClientNumber")
                    .IsUnique();

                entity.HasIndex(e => new { e.ClientNumber, e.CustomerReference }, "IDX_PaymentTemplates_CustomerRef_ClientNumber_UC1")
                    .IsUnique();

                entity.HasIndex(e => e.Status, "IX_PaymentTempates_Status");

                entity.HasIndex(e => e.HostReference, "IX_PaymentTemplates_HostReference")
                    .IsUnique();

                entity.HasIndex(e => e.IBankReference, "IX_PaymentTemplates_iBankReference")
                    .IsUnique();

                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryReference)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreditCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DebitAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.HostReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.PaymentTemplateDetails).HasColumnType("xml");

                entity.Property(e => e.SinglePaymentTemplate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymenTypeId);

                entity.HasIndex(e => e.IbcproductCode, "IX_PaymentTypes_IBCProductCode")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentType1, "IX_PaymentTypes_PaymentType")
                    .IsUnique();

                entity.HasIndex(e => e.ShortCode, "IX_PaymentTypes_ShortCode")
                    .IsUnique();

                entity.HasIndex(e => e.PaymentTypeValue, "IX_PaymentTypes_Value")
                    .IsUnique();

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IbcproductCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IBCProductCode")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsDomestic)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PaymentType1)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PaymentType");

                entity.Property(e => e.ShortCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ProductCode>(entity =>
            {
                entity.HasKey(e => e.ProductCode1)
                    .IsClustered(false);

                entity.Property(e => e.ProductCode1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ProductCode");

                entity.Property(e => e.AmendMessageType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CancelMessageType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewMessageType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReceiptAllocation>(entity =>
            {
                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.ReceiptAllocations)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptAllocations_UnallocatedReceipts");
            });

            modelBuilder.Entity<RedemptionCharge>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.Value, e.TransactionLevel })
                    .HasName("RedemptionCharges_PK");

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.BandLimit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ChargeId).HasColumnName("ChargeID");

                entity.HasOne(d => d.Charge)
                    .WithMany(p => p.RedemptionCharges)
                    .HasForeignKey(d => d.ChargeId)
                    .HasConstraintName("ChargeDetails_RedemptionCharges_FK1");
            });

            modelBuilder.Entity<ReleasedBatchHeaderHistory>(entity =>
            {
                entity.HasKey(e => e.BatchId);

                entity.ToTable("ReleasedBatchHeaderHistory");

                entity.HasIndex(e => e.HostReference, "IX_ReleasedBatchHeaderHistory_HostReference")
                    .IsUnique();

                entity.HasIndex(e => e.BatchId, "IX_ReleasedBatchHeaderHistory_Status");

                entity.HasIndex(e => e.IBankReference, "IX_ReleasedBatchHeaderHistory_iBankReference")
                    .IsUnique();

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.ActionDateMessageAcknowledgedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionDateMessageAcknowledgedOn).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.BatchType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ControlAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultCreditNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.HostReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.Property(e => e.LastProcessed).HasColumnType("datetime");

                entity.Property(e => e.LastProcessedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastSignedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastSignedOn).HasColumnType("datetime");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittedOn).HasColumnType("datetime");

                entity.Property(e => e.SuspenseAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TotalPaymentCommsion).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalTransferCommission).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<ReleasedBatchItemHistory>(entity =>
            {
                entity.HasKey(e => e.BatchItemId);

                entity.ToTable("ReleasedBatchItemHistory");

                entity.HasIndex(e => e.IBankReference, "IX_ReleasedBatchItemHistory_iBankReference")
                    .IsUnique();

                entity.Property(e => e.Beneficiary)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryReference)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ClearingCode)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreditAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreditNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CreditType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DebitNarrative)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IBankReference)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iBankReference");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.ReleasedBatchItemHistories)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReleasedBatchItemHistory_ReleasedBatchHeaderHistory");

                entity.HasOne(d => d.PaymentTemplate)
                    .WithMany(p => p.ReleasedBatchItemHistories)
                    .HasForeignKey(d => d.PaymentTemplateId)
                    .HasConstraintName("FK_ReleasedBatchItemHistory_PaymentTemplates");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.ReleasedBatchItemHistories)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_ReleasedBatchItemHistory_PaymentTypes");
            });

            modelBuilder.Entity<RepayReclaim>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("Merchants_PK")
                    .IsClustered(false);

                entity.ToTable("RepayReclaim");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.BalanceSweepType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastReclaimAmount).HasColumnType("money");

                entity.Property(e => e.LastReclaimDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastRepaymentAmount).HasColumnType("money");

                entity.Property(e => e.LastRepaymentDate).HasColumnType("smalldatetime");

                entity.Property(e => e.MinReclaimAmount).HasColumnType("money");

                entity.Property(e => e.MinRepaymentAmount).HasColumnType("money");

                entity.Property(e => e.MinimumBalance).HasColumnType("money");

                entity.Property(e => e.ReclaimFrequencyPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepaymentFrequencyPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TargetBalance).HasColumnType("money");

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.RepayReclaim)
                    .HasForeignKey<RepayReclaim>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_Merchants_FK1");
            });

            modelBuilder.Entity<Sccgateway>(entity =>
            {
                entity.HasKey(e => e.SystemId)
                    .HasName("SCCGateway_PK");

                entity.ToTable("SCCGateway");

                entity.Property(e => e.SystemId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SystemID")
                    .IsFixedLength();

                entity.Property(e => e.CardFirstCharacter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CardSeparatorCharacter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SccbranchId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SCCBranchID");

                entity.Property(e => e.SccoperatorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SCCOperatorID");

                entity.Property(e => e.SccstoreId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SCCStoreID");

                entity.Property(e => e.SccterminalId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SCCTerminalID");

                entity.Property(e => e.TransactionIdprefix)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TransactionIDPrefix");

                entity.HasOne(d => d.System)
                    .WithOne(p => p.Sccgateway)
                    .HasForeignKey<Sccgateway>(d => d.SystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMSSystemDefaults_SCCGateway_FK1");
            });

            modelBuilder.Entity<SecurityLog>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.ToTable("SecurityLog");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<SessionInformation>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .IsClustered(false);

                entity.ToTable("SessionInformation");

                entity.HasIndex(e => e.SessionId, "idxSessionID")
                    .IsUnique();

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BranchSelectedIndex).HasDefaultValueSql("((0))");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientInView)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateFormatChecked)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DatesChecked)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DealNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrawingReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Expiry).HasColumnType("datetime");

                entity.Property(e => e.Filter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterChecked)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue0)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterValue6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HostedDataId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HostedDataID");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Lcreference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LCReference");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.LogonQueryString)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NavigationBarCode)
                    .HasMaxLength(6000)
                    .IsUnicode(false);

                entity.Property(e => e.OrderBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageInView)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentCardLast4Digits)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentReference)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodEnd).HasColumnType("smalldatetime");

                entity.Property(e => e.PeriodStart).HasColumnType("smalldatetime");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.Property(e => e.ShowStatementBalances)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SortChecked)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpecificDateValueFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.SpecificDateValueTo).HasColumnType("smalldatetime");

                entity.Property(e => e.StatementFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.StatementTo).HasColumnType("smalldatetime");

                entity.Property(e => e.TransferReference)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.UsersCulture)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsersInternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UsersInternalID");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("ShoppingCart");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SessionID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SiteParameter>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .IsClustered(false);

                entity.Property(e => e.AccountTransferCutOffTime).HasColumnType("datetime");

                entity.Property(e => e.AdministratorEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AllowDomesticPayments)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowNonOat).HasColumnName("AllowNonOAT");

                entity.Property(e => e.BankSwiftid)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BankSWIFTID")
                    .IsFixedLength();

                entity.Property(e => e.BankValInternationalPin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BankValInternationalPIN");

                entity.Property(e => e.BankValInternationalUserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BankValUkpin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BankValUKPIN");

                entity.Property(e => e.BankValUkuserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BankValUKUserId");

                entity.Property(e => e.BanksHomePage)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BaseCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CacommonName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CACommonName");

                entity.Property(e => e.Cacountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CACountry");

                entity.Property(e => e.Calocality)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CALocality");

                entity.Property(e => e.Caname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAName");

                entity.Property(e => e.CaorgUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAOrgUnit");

                entity.Property(e => e.Castate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAState");

                entity.Property(e => e.DatabaseType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefaultEntityLimitsCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmailNotificationsAccountApplications)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalEmailServer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IBankCertificatesOnly).HasColumnName("iBankCertificatesOnly");

                entity.Property(e => e.IBankUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("iBankURL");

                entity.Property(e => e.ImportFileListLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InternalEmailServer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InternalUserClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalUserClientID");

                entity.Property(e => e.IntradayImportFileListLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lang)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SiteCommonName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiteIp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("SiteIP");

                entity.Property(e => e.StatusMessagesLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SwiftmessagesExtension)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SWIFTMessagesExtension");

                entity.Property(e => e.SwiftmessagesLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SWIFTMessagesLocation");

                entity.Property(e => e.SystemKey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeOutPeriod).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SiteSpecificHtmlcode>(entity =>
            {
                entity.HasKey(e => e.SiteSpecificHtmlcodesId);

                entity.ToTable("SiteSpecificHTMLCodes");

                entity.Property(e => e.SiteSpecificHtmlcodesId)
                    .ValueGeneratedNever()
                    .HasColumnName("SiteSpecificHTMLCodesId");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SiteSpecificHtmlvalue>(entity =>
            {
                entity.HasKey(e => e.SiteSpecificHtmlvaluesId);

                entity.ToTable("SiteSpecificHTMLValues");

                entity.HasIndex(e => new { e.SiteSpecificHtmlcodesId, e.LanguageCultureId }, "SiteSpecificHTMLCodesId_LanguageCultureId")
                    .IsUnique();

                entity.Property(e => e.SiteSpecificHtmlvaluesId).HasColumnName("SiteSpecificHTMLValuesId");

                entity.Property(e => e.LanguageCultureId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SiteSpecificHtmlcodesId).HasColumnName("SiteSpecificHTMLCodesId");

                entity.Property(e => e.Value).HasDefaultValueSql("('')");

                entity.HasOne(d => d.LanguageCulture)
                    .WithMany(p => p.SiteSpecificHtmlvalues)
                    .HasForeignKey(d => d.LanguageCultureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteSpecificHTMLValues_LanguageCulture");

                entity.HasOne(d => d.SiteSpecificHtmlcodes)
                    .WithMany(p => p.SiteSpecificHtmlvalues)
                    .HasForeignKey(d => d.SiteSpecificHtmlcodesId)
                    .HasConstraintName("FK_SiteSpecificHTMLValues_SiteSpecificHTMLCodes");
            });

            modelBuilder.Entity<Smscdefinition>(entity =>
            {
                entity.HasKey(e => e.Smscid)
                    .HasName("SMSCDefinitions_PK")
                    .IsClustered(false);

                entity.ToTable("SMSCDefinitions");

                entity.Property(e => e.Smscid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCID");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IncomingDirectory)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IncomingLayout)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.OutgoingDirectory)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OutgoingLayout)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TransferMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransferPasword)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TransferUser)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Smscode>(entity =>
            {
                entity.HasKey(e => e.Smscode1)
                    .HasName("SMSCodess_PK")
                    .IsClustered(false);

                entity.ToTable("SMSCodes");

                entity.Property(e => e.Smscode1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.Property(e => e.Description)
                    .HasMaxLength(4096)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Smsincoming>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("SMSIncoming_PK");

                entity.ToTable("SMSIncoming");

                entity.HasIndex(e => e.ConfirmationCode, "idxConfirmationCode");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.ConfirmationCode)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Confirmer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatchedSmscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MatchedSMSCode");

                entity.Property(e => e.Message)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.MessageRef)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Received).HasColumnType("datetime");

                entity.Property(e => e.Smscid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCID");
            });

            modelBuilder.Entity<Smsoutgoing>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("SMSOutgoing_PK");

                entity.ToTable("SMSOutgoing");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Message)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.MessageExpiry).HasColumnType("smalldatetime");

                entity.Property(e => e.MessagePriority)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MessageRef)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sent).HasColumnType("datetime");

                entity.Property(e => e.Smscid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCID");
            });

            modelBuilder.Entity<Smsparameter>(entity =>
            {
                entity.HasKey(e => e.ParameterId)
                    .HasName("SMSParameters_PK");

                entity.ToTable("SMSParameters");

                entity.Property(e => e.ParameterId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ParameterID");

                entity.Property(e => e.Description)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.FailAs)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Smsresponse>(entity =>
            {
                entity.HasKey(e => e.Smscode)
                    .HasName("SMSResponses_PK");

                entity.ToTable("SMSResponses");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.Property(e => e.ResponseText)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.HasOne(d => d.SmscodeNavigation)
                    .WithOne(p => p.Smsresponse)
                    .HasForeignKey<Smsresponse>(d => d.Smscode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMSCodes_SMSResponses_FK1");
            });

            modelBuilder.Entity<Smsrule>(entity =>
            {
                entity.HasKey(e => e.Smscode)
                    .HasName("SMSRules_PK");

                entity.ToTable("SMSRules");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.Property(e => e.ChargeAs)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmAs)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmParameters)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmTo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FailAs)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FailTo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FromAccountHolder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FromAccountType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RespondAs)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RespondTo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RewriteAs)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccountHolder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ToAccountType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmsshortCode>(entity =>
            {
                entity.HasKey(e => e.ShortCodeContent)
                    .HasName("SMSShortCodes_PK");

                entity.ToTable("SMSShortCodes");

                entity.Property(e => e.ShortCodeContent)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");

                entity.HasOne(d => d.SmscodeNavigation)
                    .WithMany(p => p.SmsshortCodes)
                    .HasForeignKey(d => d.Smscode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMSRules_SMSShortCodes_FK1");
            });

            modelBuilder.Entity<SmssystemDefault>(entity =>
            {
                entity.HasKey(e => e.SystemId)
                    .HasName("SystemDefaults_PK")
                    .IsClustered(false);

                entity.ToTable("SMSSystemDefaults");

                entity.Property(e => e.SystemId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SystemID")
                    .IsFixedLength();

                entity.Property(e => e.ChargesAccount)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CommisionsAccount)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrossCcyAccount)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Iddcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IDDCode");

                entity.Property(e => e.Iddsymbol)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDDSymbol")
                    .IsFixedLength();

                entity.Property(e => e.InvalidMessageSmscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("InvalidMessageSMSCODE");

                entity.Property(e => e.MasterClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MasterClientID");

                entity.Property(e => e.MaxBalanceCustomer).HasColumnType("money");

                entity.Property(e => e.MaxBalanceIntroducer).HasColumnType("money");

                entity.Property(e => e.MaxBalanceMerchant).HasColumnType("money");

                entity.Property(e => e.MaxBalanceNetworkOperator).HasColumnType("money");

                entity.Property(e => e.MaxBalanceRetailer).HasColumnType("money");

                entity.Property(e => e.NoClientSmscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NoClientSMSCODE");

                entity.Property(e => e.PrimaryCashVoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PrimaryCashVoucherID");

                entity.Property(e => e.WelcomeMessageSmscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WelcomeMessageSMSCODE");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.SmssystemDefaults)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("CountryCodes_SystemDefaults_FK1");
            });

            modelBuilder.Entity<SmstrafficCount>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Smscode })
                    .HasName("SMSTrafficCounts_PK");

                entity.ToTable("SMSTrafficCounts");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.Smscode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SMSCode");
            });

            modelBuilder.Entity<SplitAuthorityCode>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.HashedChar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.HasOne(d => d.Internal)
                    .WithMany(p => p.SplitAuthorityCodes)
                    .HasForeignKey(d => d.InternalId)
                    .HasConstraintName("FK_SplitAuthorityCodes_UserProfiles");
            });

            modelBuilder.Entity<Statement>(entity =>
            {
                entity.HasIndex(e => new { e.AccountNumber, e.EntryDate }, "IDX_AccountEntryDate");

                entity.Property(e => e.StatementId).HasColumnName("StatementID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Debit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Expanded)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImportedToday).HasDefaultValueSql("((0))");

                entity.Property(e => e.KeyValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Last4CardDigits)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Narrative5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Statements)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("Accounts_Statements_FK1");
            });

            modelBuilder.Entity<SwiftqueueDetail>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .IsClustered(false);

                entity.ToTable("SWIFTQueueDetails");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OutputFileName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SwiftqueueHeader>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .IsClustered(false);

                entity.ToTable("SWIFTQueueHeaders");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemDate>(entity =>
            {
                entity.HasKey(e => e.ExtractDate)
                    .HasName("SystemDates_PK");

                entity.Property(e => e.ExtractDate).HasColumnType("datetime");

                entity.Property(e => e.NextProcessingDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TagDefinition>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .IsClustered(false);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.PermittedValues).HasColumnType("text");

                entity.Property(e => e.SubfieldDelimiter)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SubfieldDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tag)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TagOption)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TagType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .IsClustered(false);

                entity.Property(e => e.TeamId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TeamID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestMessage>(entity =>
            {
                entity.HasKey(e => new { e.Received, e.Message });

                entity.Property(e => e.Received).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Smscid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SMSCID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TopUpConfirm>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("TopUpConfirm_PK");

                entity.ToTable("TopUpConfirm");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.MessageNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Message No");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Payment Type");

                entity.Property(e => e.ServiceProviderName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ServiceProvider Name");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Terminal Id");

                entity.Property(e => e.TimestampValue)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Timestamp Value");

                entity.Property(e => e.TopUpConfirmRequestCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TopUpConfirmRequest Code")
                    .IsFixedLength();

                entity.Property(e => e.TopUpConfirmRequestType)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("TopUpConfirmRequest Type");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Transaction Id");
            });

            modelBuilder.Entity<TopUpConfirmResponse>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("TopUpConfirmResponse_PK");

                entity.ToTable("TopUpConfirmResponse");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.MessageNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Message No");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Terminal Id");

                entity.Property(e => e.TopUpConfirmResponseCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TopUpConfirmResponse Code")
                    .IsFixedLength();

                entity.Property(e => e.TopUpConfirmResponseType)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("TopUpConfirmResponse Type");

                entity.Property(e => e.VoidTransactionId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VoidTransaction Id");
            });

            modelBuilder.Entity<TopUpPending>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("TopUpPending_PK");

                entity.ToTable("TopUpPending");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.MessageNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Message No");

                entity.Property(e => e.MobilePhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TopUpConfirmResponseTime).HasColumnType("smalldatetime");

                entity.Property(e => e.TopUpConfirmTime).HasColumnType("smalldatetime");

                entity.Property(e => e.TopUpRequestTime).HasColumnType("smalldatetime");

                entity.Property(e => e.TopUpResponseTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TopUpRequest>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("TopUpRequest_PK");

                entity.ToTable("TopUpRequest");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Amount Currency");

                entity.Property(e => e.BarCodeEan)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("BarCode EAN");

                entity.Property(e => e.BranchNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Branch No");

                entity.Property(e => e.CardDetails)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CardDetailsInput)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CardDetails Input");

                entity.Property(e => e.MessageNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Message No");

                entity.Property(e => e.OperatorId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Operator Id");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Payment Type");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Product Id");

                entity.Property(e => e.ReferenceId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Reference Id");

                entity.Property(e => e.SupplementaryReceiptTextCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("SupplementaryReceiptText Code");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Terminal Id");

                entity.Property(e => e.TimeStampValue)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("TimeStamp Value");

                entity.Property(e => e.TopUpRequestType)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("TopUpRequest Type");
            });

            modelBuilder.Entity<TopUpResponse>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("TopUpResponse_PK");

                entity.ToTable("TopUpResponse");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.ActivationCode)
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.ActivationCodeBatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ActivationCode BatchNo");

                entity.Property(e => e.ActivationCodeSerialNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ActivationCode SerialNo");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Amount Currency");

                entity.Property(e => e.CustomerMessage)
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.GenericMessage)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.HelpdeskNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Helpdesk No");

                entity.Property(e => e.MessageNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Message No");

                entity.Property(e => e.MsisdnNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MSISDN No");

                entity.Property(e => e.NewBalanceValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NewBalance Value");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("Product name");

                entity.Property(e => e.ResponseCodeValue)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ResponseCode Value");

                entity.Property(e => e.RetryTime)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Retry Time");

                entity.Property(e => e.ServiceBalanceValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ServiceBalance Value");

                entity.Property(e => e.ServiceProviderName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ServiceProvider Name");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Store Id");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Terminal Id");

                entity.Property(e => e.TillMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TopUpResponseConfirm)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TopUpResponse Confirm");

                entity.Property(e => e.TopUpResponseType)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("TopUpResponse Type");

                entity.Property(e => e.TopUpText)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Transaction Id");
            });

            modelBuilder.Entity<TransactionJournal>(entity =>
            {
                entity.ToTable("TransactionJournal");

                entity.Property(e => e.ActionedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AuditItemDate).HasColumnType("datetime");

                entity.Property(e => e.NewDetails)
                    .HasColumnType("xml")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OriginalDetails)
                    .HasColumnType("xml")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.TransactionJournals)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK_TransactionJournal_BatchHeaders");

                entity.HasOne(d => d.CustomerPayment)
                    .WithMany(p => p.TransactionJournals)
                    .HasForeignKey(d => d.CustomerPaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TransactionJournal_CustomerPayments");

                entity.HasOne(d => d.CustomerTransfer)
                    .WithMany(p => p.TransactionJournals)
                    .HasForeignKey(d => d.CustomerTransferId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TransactionJournal_CustomerTransfers");

                entity.HasOne(d => d.PaymentTemplate)
                    .WithMany(p => p.TransactionJournals)
                    .HasForeignKey(d => d.PaymentTemplateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TransactionJournal_PaymentTemplates");
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T11S0101)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T11S0102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T11S0103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_03")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01");

                entity.Property(e => e.T210102)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T32A0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32A0102)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T32A0103)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_03");

                entity.Property(e => e.T5001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T50___01");

                entity.Property(e => e.T5201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T52___01");

                entity.Property(e => e.T5301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T53___01");

                entity.Property(e => e.T54A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_01");

                entity.Property(e => e.T54A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_02");

                entity.Property(e => e.T54D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_01");

                entity.Property(e => e.T54D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_02");

                entity.Property(e => e.T54D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_03");

                entity.Property(e => e.T54D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_04");

                entity.Property(e => e.T54D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_05");

                entity.Property(e => e.T56A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_01");

                entity.Property(e => e.T56A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_02");

                entity.Property(e => e.T56D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_01");

                entity.Property(e => e.T56D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_02");

                entity.Property(e => e.T56D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_03");

                entity.Property(e => e.T56D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_04");

                entity.Property(e => e.T56D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_05");

                entity.Property(e => e.T5701)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T57___01");

                entity.Property(e => e.T5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T59___01");

                entity.Property(e => e.T700101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_01");

                entity.Property(e => e.T700102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_02");

                entity.Property(e => e.T700103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_03");

                entity.Property(e => e.T700104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_04");

                entity.Property(e => e.T700105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_05");

                entity.Property(e => e.T700106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_06");

                entity.Property(e => e.T700107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_07");

                entity.Property(e => e.T700108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_08");

                entity.Property(e => e.T700109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_09");

                entity.Property(e => e.T700110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_10");

                entity.Property(e => e.T7101)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("T71___01")
                    .IsFixedLength();

                entity.Property(e => e.T720101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_01");

                entity.Property(e => e.T720102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_02");

                entity.Property(e => e.T720103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_03");

                entity.Property(e => e.T720104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_04");

                entity.Property(e => e.T720105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_05");

                entity.Property(e => e.T720106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_06");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.X32A0101)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.X32A0102)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.X32A0103)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_03")
                    .IsFixedLength();

                entity.Property(e => e.X700101)
                    .HasColumnType("text")
                    .HasColumnName("X70___01_01");

                entity.Property(e => e.X700201)
                    .HasColumnType("text")
                    .HasColumnName("X70___02_01");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01")
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength();

                entity.Property(e => e.Xx201)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");

                entity.HasOne(d => d.ClientNumberNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.ClientNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clients_Transfers_FK1");
            });

            modelBuilder.Entity<UILanguageResource>(entity =>
            {
                entity.HasKey(e => new { e.LanguageCode, e.ResourceKey });

                entity.ToTable("UILanguageResources");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceKey)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceText)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.LanguageCodeNavigation)
                    .WithMany(p => p.UILanguageResources)
                    .HasForeignKey(d => d.LanguageCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UILanguageResources_LanguageCulture");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.UILanguageResources)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UILanguageResources_UIResources");
            });

            modelBuilder.Entity<UIResource>(entity =>
            {
                entity.HasKey(e => e.ResourceKey);

                entity.ToTable("UIResources");

                entity.Property(e => e.ResourceKey)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnallocatedReceipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PostedTotal).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ReceiptTotal).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UnallocatedTotal).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UnpostedTotal).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<UpgradeHistory>(entity =>
            {
                entity.HasKey(e => e.UpgradeTo)
                    .IsClustered(false);

                entity.ToTable("UpgradeHistory");

                entity.Property(e => e.DateApplied).HasColumnType("datetime");

                entity.Property(e => e.ReleaseNotes).HasColumnType("text");

                entity.Property(e => e.UpgradeFileContents).HasColumnType("text");
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.HasKey(e => e.InternalId)
                    .IsClustered(false);

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateFormatChecked)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayInstructions)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.RequireDigitalCertificate)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartPage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToolbarPosition)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.InternalId)
                    .IsClustered(false);

                entity.HasIndex(e => e.LogonId, "IDX_LogonID");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AmendedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AmendedOn).HasColumnType("datetime");

                entity.Property(e => e.CanCreateCustomerTemplate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanSignOwnCustomerTemplate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstTime)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ForceKeywordChange)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.IBankAdministrator).HasColumnName("iBankAdministrator");

                entity.Property(e => e.LanguageCultureId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoggedOn).HasColumnType("datetime");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.MessageForUser).HasColumnType("text");

                entity.Property(e => e.MobilePhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneNumberIdd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MobilePhoneNumberIDD");

                entity.Property(e => e.MultiCcyPaymentsAllowed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumberofAuthorisationAttempts).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentsAllowed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SessionStarted).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Logon)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.LogonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iBankCustomers_UserProfiles_FK1");
            });

            modelBuilder.Entity<UserRight>(entity =>
            {
                entity.HasKey(e => e.UserRightsId)
                    .HasName("UserRights_PK")
                    .IsClustered(false);

                entity.Property(e => e.UserRightsId).HasColumnName("UserRightsID");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccountID");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientID");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ProductID")
                    .IsFixedLength();

                entity.Property(e => e.XmaximumEntry).HasColumnName("XMaximumEntry");

                entity.Property(e => e.XmaximumSigning).HasColumnName("XMaximumSigning");

                entity.Property(e => e.XmaximumVerification).HasColumnName("XMaximumVerification");

                entity.Property(e => e.XsignOwn).HasColumnName("XSignOwn");

                entity.Property(e => e.XunlimitedEntry).HasColumnName("XUnlimitedEntry");

                entity.Property(e => e.XunlimitedSigning).HasColumnName("XUnlimitedSigning");

                entity.Property(e => e.XunlimitedVerification).HasColumnName("XUnlimitedVerification");

                entity.Property(e => e.XverifyOwn).HasColumnName("XVerifyOwn");

                entity.Property(e => e.XviewingAllowed).HasColumnName("XViewingAllowed");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.VoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");

                entity.Property(e => e.Description)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VoucherValue>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.Value })
                    .HasName("VoucherValues_PK");

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");

                entity.Property(e => e.Value).HasColumnType("money");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.VoucherValues)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vouchers_VoucherValues_FK1");
            });

            modelBuilder.Entity<XauthorityCode>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.ToTable("XAuthorityCodes");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentKeyword9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID");

                entity.Property(e => e.NewKeyword1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewKeyword9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PIN")
                    .IsFixedLength();

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Xbeneficiary>(entity =>
            {
                entity.HasKey(e => e.XbeneficiaryId)
                    .HasName("XBeneficiaries_PK")
                    .IsClustered(false);

                entity.ToTable("XBeneficiaries");

                entity.Property(e => e.XbeneficiaryId).HasColumnName("XbeneficiaryID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01")
                    .IsFixedLength();

                entity.Property(e => e.T210102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02")
                    .HasDefaultValueSql("('/NEW/')");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.X210101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("X21___01_01")
                    .IsFixedLength();

                entity.Property(e => e.X210102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("X21___01_02");

                entity.Property(e => e.X210103)
                    .HasColumnType("text")
                    .HasColumnName("X21___01_03");

                entity.Property(e => e.X790114)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_14");

                entity.Property(e => e.X790121)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_21");

                entity.Property(e => e.X790129)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_29");

                entity.Property(e => e.X790141)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_41");

                entity.Property(e => e.X790146)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_46");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01");

                entity.Property(e => e.Xx201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");
            });

            modelBuilder.Entity<XgroupMember>(entity =>
            {
                entity.HasKey(e => e.GroupMemberId)
                    .HasName("XGroupMembers_PK")
                    .IsClustered(false);

                entity.ToTable("XGroupMembers");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnteredOn).HasColumnType("datetime");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID");

                entity.Property(e => e.OriginalGroupId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OriginalGroupID");
            });

            modelBuilder.Entity<XiMailBox>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .IsClustered(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.Body).HasColumnType("text");

                entity.Property(e => e.Cc)
                    .HasColumnType("text")
                    .HasColumnName("CC");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.OriginalMessageId).HasColumnName("OriginalMessageID");

                entity.Property(e => e.Priority)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Xlcrequest>(entity =>
            {
                entity.HasKey(e => e.RequestReference)
                    .IsClustered(false);

                entity.ToTable("XLCRequests");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AmendmentLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentLogonID");

                entity.Property(e => e.AmendmentUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentUserID");

                entity.Property(e => e.AmendmentVerifiedLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentVerifiedLogonID");

                entity.Property(e => e.AmendmentVerifiedUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("AmendmentVerifiedUserID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DeletionLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionLogonID");

                entity.Property(e => e.DeletionUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionUserID");

                entity.Property(e => e.DeletionVerifiedLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionVerifiedLogonID");

                entity.Property(e => e.DeletionVerifiedUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DeletionVerifiedUserID");

                entity.Property(e => e.EntryLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryLogonID");

                entity.Property(e => e.EntryUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryUserID");

                entity.Property(e => e.EntryVerifiedLogonId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryVerifiedLogonID");

                entity.Property(e => e.EntryVerifiedUserId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EntryVerifiedUserID");

                entity.Property(e => e.MsreplSynctranTs)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("msrepl_synctran_ts");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T2301)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T23___01");

                entity.Property(e => e.T2701)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T27___01")
                    .IsFixedLength();

                entity.Property(e => e.T31C01)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T31_C_01");

                entity.Property(e => e.T31D0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T31_D_01_01");

                entity.Property(e => e.T31D0102)
                    .HasMaxLength(29)
                    .IsUnicode(false)
                    .HasColumnName("T31_D_01_02");

                entity.Property(e => e.T32B0101)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_B_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32B0102)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_B_01_02");

                entity.Property(e => e.T39A01)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T39_A_01");

                entity.Property(e => e.T39B01)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("T39_B_01");

                entity.Property(e => e.T39C01)
                    .HasColumnType("text")
                    .HasColumnName("T39_C_01");

                entity.Property(e => e.T40A01)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("T40_A_01");

                entity.Property(e => e.T41A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T41_A_01");

                entity.Property(e => e.T41D01)
                    .HasColumnType("text")
                    .HasColumnName("T41_D_01");

                entity.Property(e => e.T42A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T42_A_01");

                entity.Property(e => e.T42C01)
                    .HasColumnType("text")
                    .HasColumnName("T42_C_01");

                entity.Property(e => e.T42D01)
                    .HasColumnType("text")
                    .HasColumnName("T42_D_01");

                entity.Property(e => e.T42M01)
                    .HasColumnType("text")
                    .HasColumnName("T42_M_01");

                entity.Property(e => e.T42P01)
                    .HasColumnType("text")
                    .HasColumnName("T42_P_01");

                entity.Property(e => e.T43P01)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T43_P_01");

                entity.Property(e => e.T43T01)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T43_T_01");

                entity.Property(e => e.T44A01)
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasColumnName("T44_A_01");

                entity.Property(e => e.T44B01)
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasColumnName("T44_B_01");

                entity.Property(e => e.T44C01)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T44_C_01");

                entity.Property(e => e.T44D01)
                    .HasColumnType("text")
                    .HasColumnName("T44_D_01");

                entity.Property(e => e.T45A01)
                    .HasColumnType("text")
                    .HasColumnName("T45_A_01");

                entity.Property(e => e.T46A01)
                    .HasColumnType("text")
                    .HasColumnName("T46_A_01");

                entity.Property(e => e.T47A01)
                    .HasColumnType("text")
                    .HasColumnName("T47_A_01");

                entity.Property(e => e.T4801)
                    .HasColumnType("text")
                    .HasColumnName("T48___01");

                entity.Property(e => e.T4901)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("T49___01");

                entity.Property(e => e.T5001)
                    .HasColumnType("text")
                    .HasColumnName("T50___01");

                entity.Property(e => e.T51A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T51_A_01");

                entity.Property(e => e.T51D01)
                    .HasColumnType("text")
                    .HasColumnName("T51_D_01");

                entity.Property(e => e.T53A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T53_A_01");

                entity.Property(e => e.T53D01)
                    .HasColumnType("text")
                    .HasColumnName("T53_D_01");

                entity.Property(e => e.T57A01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T57_A_01");

                entity.Property(e => e.T57B01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("T57_B_01");

                entity.Property(e => e.T57D01)
                    .HasColumnType("text")
                    .HasColumnName("T57_D_01");

                entity.Property(e => e.T5901)
                    .HasColumnType("text")
                    .HasColumnName("T59___01");

                entity.Property(e => e.T71B01)
                    .HasColumnType("text")
                    .HasColumnName("T71_B_01");

                entity.Property(e => e.T7201)
                    .HasColumnType("text")
                    .HasColumnName("T72___01");

                entity.Property(e => e.T7801)
                    .HasColumnType("text")
                    .HasColumnName("T78___01");
            });

            modelBuilder.Entity<XmseauthorityCode>(entity =>
            {
                entity.HasKey(e => e.LogonId)
                    .HasName("XMSEAuthorityCodes_PK")
                    .IsClustered(false);

                entity.ToTable("XMSEAuthorityCodes");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.AmendedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AmendedOn).HasColumnType("datetime");

                entity.Property(e => e.AuthorityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HashValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status).HasDefaultValueSql("((10))");
            });

            modelBuilder.Entity<Xpayment>(entity =>
            {
                entity.HasKey(e => e.RequestReference)
                    .IsClustered(false);

                entity.ToTable("XPayments");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T11S0101)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T11S0102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T11S0103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_03")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01");

                entity.Property(e => e.T210102)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T32A0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32A0102)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T32A0103)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_03");

                entity.Property(e => e.T5001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T50___01");

                entity.Property(e => e.T5201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T52___01");

                entity.Property(e => e.T5301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T53___01");

                entity.Property(e => e.T54A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_01");

                entity.Property(e => e.T54A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_02");

                entity.Property(e => e.T54D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_01");

                entity.Property(e => e.T54D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_02");

                entity.Property(e => e.T54D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_03");

                entity.Property(e => e.T54D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_04");

                entity.Property(e => e.T54D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_05");

                entity.Property(e => e.T56A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_01");

                entity.Property(e => e.T56A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_02");

                entity.Property(e => e.T56D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_01");

                entity.Property(e => e.T56D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_02");

                entity.Property(e => e.T56D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_03");

                entity.Property(e => e.T56D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_04");

                entity.Property(e => e.T56D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_05");

                entity.Property(e => e.T5701)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T57___01");

                entity.Property(e => e.T5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T59___01");

                entity.Property(e => e.T700101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_01");

                entity.Property(e => e.T700102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_02");

                entity.Property(e => e.T700103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_03");

                entity.Property(e => e.T700104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_04");

                entity.Property(e => e.T700105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_05");

                entity.Property(e => e.T700106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_06");

                entity.Property(e => e.T700107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_07");

                entity.Property(e => e.T700108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_08");

                entity.Property(e => e.T700109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_09");

                entity.Property(e => e.T700110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_10");

                entity.Property(e => e.T7101)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("T71___01")
                    .IsFixedLength();

                entity.Property(e => e.T720101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_01");

                entity.Property(e => e.T720102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_02");

                entity.Property(e => e.T720103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_03");

                entity.Property(e => e.T720104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_04");

                entity.Property(e => e.T720105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_05");

                entity.Property(e => e.T720106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_06");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.X32A0101)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.X32A0102)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.X32A0103)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_03")
                    .IsFixedLength();

                entity.Property(e => e.X54D0102)
                    .HasColumnType("text")
                    .HasColumnName("X54_D_01_02");

                entity.Property(e => e.X56D0102)
                    .HasColumnType("text")
                    .HasColumnName("X56_D_01_02");

                entity.Property(e => e.X5901)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("X59___01");

                entity.Property(e => e.X700101)
                    .HasColumnType("text")
                    .HasColumnName("X70___01_01");

                entity.Property(e => e.X700201)
                    .HasColumnType("text")
                    .HasColumnName("X70___02_01");

                entity.Property(e => e.X720101)
                    .HasColumnType("text")
                    .HasColumnName("X72___01_01");

                entity.Property(e => e.X790129)
                    .HasColumnType("text")
                    .HasColumnName("X79___01_29");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01")
                    .IsFixedLength();

                entity.Property(e => e.Xx201)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");
            });

            modelBuilder.Entity<Xtransfer>(entity =>
            {
                entity.HasKey(e => e.RequestReference)
                    .IsClustered(false);

                entity.ToTable("XTransfers");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OK')")
                    .IsFixedLength();

                entity.Property(e => e.T11S0101)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T11S0102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T11S0103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T11_S_01_03")
                    .IsFixedLength();

                entity.Property(e => e.T2001)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T20___01");

                entity.Property(e => e.T210101)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_01");

                entity.Property(e => e.T210102)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_02");

                entity.Property(e => e.T210103)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("T21___01_03");

                entity.Property(e => e.T32A0101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.T32A0102)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.T32A0103)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("T32_A_01_03");

                entity.Property(e => e.T5001)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T50___01");

                entity.Property(e => e.T5201)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T52___01");

                entity.Property(e => e.T5301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T53___01");

                entity.Property(e => e.T54A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_01");

                entity.Property(e => e.T54A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_A_01_02");

                entity.Property(e => e.T54D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_01");

                entity.Property(e => e.T54D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_02");

                entity.Property(e => e.T54D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_03");

                entity.Property(e => e.T54D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_04");

                entity.Property(e => e.T54D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T54_D_01_05");

                entity.Property(e => e.T56A0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_01");

                entity.Property(e => e.T56A0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_A_01_02");

                entity.Property(e => e.T56D0101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_01");

                entity.Property(e => e.T56D0102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_02");

                entity.Property(e => e.T56D0103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_03");

                entity.Property(e => e.T56D0104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_04");

                entity.Property(e => e.T56D0105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T56_D_01_05");

                entity.Property(e => e.T5701)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T57___01");

                entity.Property(e => e.T5901)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T59___01");

                entity.Property(e => e.T700101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_01");

                entity.Property(e => e.T700102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_02");

                entity.Property(e => e.T700103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_03");

                entity.Property(e => e.T700104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_04");

                entity.Property(e => e.T700105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_05");

                entity.Property(e => e.T700106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_06");

                entity.Property(e => e.T700107)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_07");

                entity.Property(e => e.T700108)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_08");

                entity.Property(e => e.T700109)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_09");

                entity.Property(e => e.T700110)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T70___01_10");

                entity.Property(e => e.T7101)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("T71___01")
                    .IsFixedLength();

                entity.Property(e => e.T720101)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_01");

                entity.Property(e => e.T720102)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_02");

                entity.Property(e => e.T720103)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_03");

                entity.Property(e => e.T720104)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_04");

                entity.Property(e => e.T720105)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_05");

                entity.Property(e => e.T720106)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T72___01_06");

                entity.Property(e => e.T790101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_01");

                entity.Property(e => e.T790102)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_02");

                entity.Property(e => e.T790103)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_03")
                    .IsFixedLength();

                entity.Property(e => e.T790104)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_04");

                entity.Property(e => e.T790105)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_05");

                entity.Property(e => e.T790106)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_06");

                entity.Property(e => e.T790107)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_07");

                entity.Property(e => e.T790108)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_08");

                entity.Property(e => e.T790109)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_09");

                entity.Property(e => e.T790110)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_10");

                entity.Property(e => e.T790111)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_11");

                entity.Property(e => e.T790112)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_12");

                entity.Property(e => e.T790113)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_13");

                entity.Property(e => e.T790114)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_14");

                entity.Property(e => e.T790115)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_15");

                entity.Property(e => e.T790116)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_16");

                entity.Property(e => e.T790117)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_17");

                entity.Property(e => e.T790118)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_18");

                entity.Property(e => e.T790119)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_19");

                entity.Property(e => e.T790120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_20");

                entity.Property(e => e.T790121)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_21");

                entity.Property(e => e.T790122)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_22");

                entity.Property(e => e.T790123)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_23");

                entity.Property(e => e.T790124)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_24");

                entity.Property(e => e.T790125)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_25");

                entity.Property(e => e.T790126)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_26");

                entity.Property(e => e.T790127)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_27");

                entity.Property(e => e.T790128)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_28");

                entity.Property(e => e.T790129)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_29");

                entity.Property(e => e.T790130)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_30");

                entity.Property(e => e.T790131)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_31");

                entity.Property(e => e.T790132)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_32");

                entity.Property(e => e.T790133)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_33");

                entity.Property(e => e.T790134)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_34");

                entity.Property(e => e.T790135)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_35");

                entity.Property(e => e.T790136)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_36");

                entity.Property(e => e.T790137)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_37");

                entity.Property(e => e.T790138)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_38");

                entity.Property(e => e.T790139)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_39");

                entity.Property(e => e.T790140)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_40");

                entity.Property(e => e.T790141)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_41");

                entity.Property(e => e.T790142)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_42");

                entity.Property(e => e.T790143)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_43");

                entity.Property(e => e.T790144)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_44");

                entity.Property(e => e.T790145)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_45");

                entity.Property(e => e.T790146)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_46");

                entity.Property(e => e.T790147)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_47");

                entity.Property(e => e.T790148)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_48");

                entity.Property(e => e.T790149)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_49");

                entity.Property(e => e.T790150)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_50");

                entity.Property(e => e.T790151)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("T79___01_51");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.X32A0101)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_01")
                    .IsFixedLength();

                entity.Property(e => e.X32A0102)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_02")
                    .IsFixedLength();

                entity.Property(e => e.X32A0103)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("X32_A_01_03")
                    .IsFixedLength();

                entity.Property(e => e.X700101)
                    .HasColumnType("text")
                    .HasColumnName("X70___01_01");

                entity.Property(e => e.X700201)
                    .HasColumnType("text")
                    .HasColumnName("X70___02_01");

                entity.Property(e => e.Xx101)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("XX1___01")
                    .IsFixedLength();

                entity.Property(e => e.Xx201)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("XX2___01");

                entity.Property(e => e.Xx301)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX3___01");

                entity.Property(e => e.Xx401)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX4___01");

                entity.Property(e => e.Xx501)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("XX5___01");
            });

            modelBuilder.Entity<XuserProfile>(entity =>
            {
                entity.HasKey(e => e.InternalId)
                    .IsClustered(false);

                entity.ToTable("XUserProfiles");

                entity.Property(e => e.InternalId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InternalID")
                    .IsFixedLength();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AmendedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AmendedOn).HasColumnType("datetime");

                entity.Property(e => e.CanCreateCustomerTemplate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanSignOwnCustomerTemplate)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstTime)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ForceKeywordChange)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.IBankAdministrator).HasColumnName("iBankAdministrator");

                entity.Property(e => e.LanguageCultureId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoggedOn).HasColumnType("datetime");

                entity.Property(e => e.LogonId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LogonID");

                entity.Property(e => e.MessageForUser).HasColumnType("text");

                entity.Property(e => e.MobilePhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneNumberIdd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MobilePhoneNumberIDD");

                entity.Property(e => e.MultiCcyPaymentsAllowed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumberofAuthorisationAttempts).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentsAllowed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SessionStarted).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Logon)
                    .WithMany(p => p.XuserProfiles)
                    .HasForeignKey(d => d.LogonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iBankCustomers_XUserProfiles_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
