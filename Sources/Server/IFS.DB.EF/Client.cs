using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
            Beneficiaries = new HashSet<Beneficiary>();
            ChargeHistoryByClients = new HashSet<ChargeHistoryByClient>();
            ClientAliases = new HashSet<ClientAlias>();
            ClientSmsconfirmations = new HashSet<ClientSmsconfirmation>();
            Collections = new HashSet<Collection>();
            Fxdeals = new HashSet<Fxdeal>();
            HistoricalPayments = new HashSet<HistoricalPayment>();
            HistoricalTransfers = new HashSet<HistoricalTransfer>();
            Lcs = new HashSet<Lc>();
            Lddeals = new HashSet<Lddeal>();
            MerchantVoucherLists = new HashSet<MerchantVoucherList>();
            Payments = new HashSet<Payment>();
            Transfers = new HashSet<Transfer>();
        }

        public string ClientNumber { get; set; } = null!;
        public string? ClientName { get; set; }
        public string? GroupNumber { get; set; }
        public string? GroupName { get; set; }
        public bool? GroupHeader { get; set; }
        public string? ClientTown { get; set; }
        public string? ClientType { get; set; }
        public string? AccountManagerId { get; set; }
        public string? EmailAddress { get; set; }
        public string? RegistrationType { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public string? FamilyName { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public bool? NetworkOperator { get; set; }
        public string? HomeAddressLine1 { get; set; }
        public string? HomeAddressLine2 { get; set; }
        public string? HomeAddressCountry { get; set; }
        public string? ScccardNo { get; set; }
        public string? Sccexpiry { get; set; }
        public bool? Customer { get; set; }
        public string? IntroducerId { get; set; }
        public bool? Introducer { get; set; }
        public bool? Merchant { get; set; }
        public bool? Retailer { get; set; }
        public bool? Internal { get; set; }
        public DateTime? SignUpDate { get; set; }
        public string? MobilePhoneOperator { get; set; }
        public string? Pincode { get; set; }
        public bool? WelcomeSent { get; set; }
        public string? ExternalReference { get; set; }
        public string? HomeAddress { get; set; }
        public string? MiddleName { get; set; }
        public string? Mneumonic { get; set; }
        public bool? ShowNameToReceiver { get; set; }
        public bool? SeeNameOnIncomingMsg { get; set; }
        public string? TopUpRequestDirectory { get; set; }
        public bool? Registered { get; set; }
        public string? TopUpResponseDirectory { get; set; }
        public string? TopUpConfirmDirectory { get; set; }
        public string? CountryCode { get; set; }

        public virtual AccountManager? AccountManager { get; set; }
        public virtual BankDetail BankDetail { get; set; } = null!;
        public virtual NetworkOperator NetworkOperatorNavigation { get; set; } = null!;
        public virtual RepayReclaim RepayReclaim { get; set; } = null!;
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
        public virtual ICollection<ChargeHistoryByClient> ChargeHistoryByClients { get; set; }
        public virtual ICollection<ClientAlias> ClientAliases { get; set; }
        public virtual ICollection<ClientSmsconfirmation> ClientSmsconfirmations { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Fxdeal> Fxdeals { get; set; }
        public virtual ICollection<HistoricalPayment> HistoricalPayments { get; set; }
        public virtual ICollection<HistoricalTransfer> HistoricalTransfers { get; set; }
        public virtual ICollection<Lc> Lcs { get; set; }
        public virtual ICollection<Lddeal> Lddeals { get; set; }
        public virtual ICollection<MerchantVoucherList> MerchantVoucherLists { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
