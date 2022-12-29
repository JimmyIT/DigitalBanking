using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Account;
using IFS.DB.WebApp.Models.Batch;
using IFS.DB.WebApp.Models.PayeeTemplate;
using IFS.DB.WebApp.Models.Transfer;
using IFS.DB.WebApp.Models.Payment;
using IFS.DB.WebApp.Models.Transactions;
using IFS.DB.WebApp.Models.Currency;
using IFS.DB.WebApp.Models.iMails;
using IFS.DB.WebApp.Models.Users;
using IFS.DB.WebApp.Models.Notifications;
using IFS.DB.WebApp.Models.GroupMaintenance;

namespace IFS.DB.WebApp.Models;

public static partial class FakeData
{
    public static string Password = "Aa12345678";
    public static string Code = "1234";
    public static int AuthorisedUserID = 2;

    public static UserInfoModel AuthorisedUser = new()
    {
        UserID = 2,
        UserName = "Jane Watson",
        Role = "Relationship Staff",
        FirstName = "Jane",
        LastName = "Watson",
        DateOfBirth = new DateTime(1995, 04, 28),
        Email = "jane.watson@gmail.com",
        PhoneNumberIDD = "+44",
        PhoneNumber = "555 753 654",
        AvartaUrl = "/img/header/jane-watson.png",
        NotificationSettings = new()
        {
            InformTransactionsSMS = true,
            InformTransactionsEmail = true,
            InformTransactionsiMail = true,

            InformNewBankServicesSMS = false,
            InformNewBankServicesEmail = false,
            InformNewBankServicesiMail = false,

            InformMessagesFromManageriMail = true,
            InformMessagesFromManagerSMS = true,
            InformMessagesFromManagerEmail = true,
        },
        SecuritySetting = SecurityFactorEnum.OneFactor,
        DevicesActiveSessions = new()
        {
            new DevicesActiveSessionModel()
            {
                DeviceID = 1,
                DeviceName = "Personal computer",
                OperationSystem = "OS X 10.15.7",
                IPAddress = "10.15.779.110.129.198",
                Note = "Authorization in the app on this device. You can log out of all devices except the current one."
            },
            new DevicesActiveSessionModel()
            {
                DeviceID = 2,
                DeviceName = "iPhone 8 Plus",
                OperationSystem = "IOS 14.6",
                IPAddress = "79.110.129.198",
                Note = "Today 14:41"
            }
        }
    };

    public static List<CreateTransferRequestModel> TransferHistory = new()
    {
        new CreateTransferRequestModel
        {
            DebitAccount = "00000077",
            CreditAccount = "10023002",
            CreditNarrative = "Credit narrative",
            DebitNarrative = "Debit narrative",
            Amount = 10.00M,
            TransferDate = DateTime.Now
        },
        new CreateTransferRequestModel
        {
            DebitAccount = "10023002",
            CreditAccount = "00000077",
            CreditNarrative = "Credit narrative",
            DebitNarrative = "Debit narrative",
            Amount = 12.50M,
            TransferDate = DateTime.Today.AddDays(-10)
        },
        new CreateTransferRequestModel
        {
            DebitAccount = "00000075",
            CreditAccount = "00002001",
            CreditNarrative = "Credit narrative",
            DebitNarrative = "Debit narrative",
            Amount = 100.0M,
            TransferDate = DateTime.Today.AddMonths(-1).AddDays(+1)
        }
    };

    public static List<AccountModel> Accounts = new()
    {
        new AccountModel
        {
            AccountNumber = "00000077",
            AccountDescription = "ABC",
            ClientNumber = "00017",
            CurrencyCode = "GBP",
            CurrentBalance = -999999999.00M,
            AvailableBalance = -999999999.00M,
            OverdraftLimit = 0.000M,
            IsFavourite = true
        },
        new AccountModel
        {
            AccountNumber = "10023002",
            AccountDescription = "Interest Bearing ACC (Profile)",
            ClientNumber = "00065",
            CurrencyCode = "GBP",
            CurrentBalance = 133455975.000M,
            AvailableBalance = 133455975.000M,
            OverdraftLimit = 0.000M,
            IsFavourite = true
        },
        new AccountModel
        {
            AccountNumber = "00000075",
            AccountDescription = "Bank Client Monies",
            ClientNumber = "00070",
            CurrencyCode = "GBP",
            CurrentBalance = 100001000.000M,
            AvailableBalance = 100001000.000M,
            OverdraftLimit = 0.000M,
            IsFavourite = false
        },
        new AccountModel
        {
            AccountNumber = "00002001",
            AccountDescription = "Bank Client Monies IB",
            ClientNumber = "00076",
            CurrencyCode = "GBP",
            CurrentBalance = 1975.000M,
            AvailableBalance = 1975.000M,
            OverdraftLimit = 0.000M,
            IsFavourite = false
        },
        new AccountModel
        {
            AccountNumber = "10023001",
            AccountDescription = "Bank Client Monies IB",
            ClientNumber = "00076",
            CurrencyCode = "GBP",
            CurrentBalance = 1975.000M,
            AvailableBalance = 1975.000M,
            OverdraftLimit = 0.000M,
            IsFavourite = false
        }
    };

    public static List<PayeeTemplateModel> PayeeTemplates = new()
    {
        new PayeeTemplateModel
        {
            ID = 1,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20221129-5",
            CreditCurrency = "GBP",
            DebitNarrative = "payment for world cup",
            BeneficiaryReference = "Julie Hegarty",
            iBankReference = "RQ20221129-5",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Esdras Geffen",
            BeneficiaryAccountNumber = "41789065",
            Pinned = true,
            CreatedDate = new DateTime(2022, 11, 21)
        },
        new PayeeTemplateModel
        {
            ID = 2,
            ClientNumber = "00002",
            DebitAccount = "00002001",
            HostReference = "RQ20121204-8",
            CreditCurrency = "GBP",
            DebitNarrative = "ISABEL DANCE LESSONS",
            BeneficiaryReference = "Mrs J Day",
            iBankReference = "RQ20121204-8",
            PaymentMethod = null,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.International,
            BeneficiaryName = "Boonie Ranby",
            BeneficiaryAccountNumber = "39779809",
            Pinned = true,
            CreatedDate = new DateTime(2022, 11, 18)
        },
        new PayeeTemplateModel
        {
            ID = 3,
            ClientNumber = "00063",
            DebitAccount = "00000075",
            HostReference = "628821669",
            CreditCurrency = "GBP",
            DebitNarrative = "monthly football fee",
            BeneficiaryReference = "Brokerage Partners",
            iBankReference = "RQ20161117-8",
            PaymentMethod = PaymentMethodEnum.BACS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Helene Nowill",
            BeneficiaryAccountNumber = "53322577",
            Pinned = false,
            CreatedDate = new DateTime(2022, 11, 15)
        },
        new PayeeTemplateModel
        {
            ID = 4,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-3",
            CreditCurrency = "GBP",
            DebitNarrative = "Payment to mum",
            BeneficiaryReference = "Sierra investments Ltd",
            iBankReference = "RQ20121129-3",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Charmine	Benoy",
            BeneficiaryAccountNumber = "99614244",
            Pinned = false,
            CreatedDate = new DateTime(2022, 11, 12)
        },
        new PayeeTemplateModel
        {
            ID = 5,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-5",
            CreditCurrency = "GBP",
            DebitNarrative = "payment for world cup",
            BeneficiaryReference = "Julie Hegarty",
            iBankReference = "RQ20121129-5",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Esdras Geffen",
            BeneficiaryAccountNumber = "41789065",
            Pinned = true,
            CreatedDate = new DateTime(2022, 11, 09)
        },
        new PayeeTemplateModel
        {
            ID = 6,
            ClientNumber = "00002",
            DebitAccount = "00002001",
            HostReference = "RQ20121204-1",
            CreditCurrency = "GBP",
            DebitNarrative = "ISABEL DANCE LESSONS",
            BeneficiaryReference = "Mrs J Day",
            iBankReference = "RQ20121204-1",
            PaymentMethod = null,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.International,
            BeneficiaryName = "Boonie Ranby",
            BeneficiaryAccountNumber = "39779809",
            Pinned = true,
            CreatedDate = new DateTime(2022, 11, 05)
        },
        new PayeeTemplateModel
        {
            ID = 7,
            ClientNumber = "00063",
            DebitAccount = "00000075",
            HostReference = "628821669",
            CreditCurrency = "GBP",
            DebitNarrative = "monthly football fee",
            BeneficiaryReference = "Brokerage Partners",
            iBankReference = "RQ20161117-3",
            PaymentMethod = PaymentMethodEnum.BACS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Helene Nowill",
            BeneficiaryAccountNumber = "53322577",
            Pinned = false,
            CreatedDate = new DateTime(2022, 11, 01)
        },
        new PayeeTemplateModel
        {
            ID = 8,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-4",
            CreditCurrency = "GBP",
            DebitNarrative = "Payment to mum",
            BeneficiaryReference = "Sierra investments Ltd",
            iBankReference = "RQ20121129-4",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Charmine	Benoy",
            BeneficiaryAccountNumber = "99614244",
            Pinned = false,
            CreatedDate = new DateTime(2022, 10, 25)
        },
        new PayeeTemplateModel
        {
            ID = 9,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-6",
            CreditCurrency = "GBP",
            DebitNarrative = "payment for world cup",
            BeneficiaryReference = "Julie Hegarty",
            iBankReference = "RQ20121129-6",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Esdras Geffen",
            BeneficiaryAccountNumber = "41789065",
            Pinned = true,
            CreatedDate = new DateTime(2022, 10, 21)
        },
        new PayeeTemplateModel
        {
            ID = 10,
            ClientNumber = "00002",
            DebitAccount = "00002001",
            HostReference = "RQ20121204-9",
            CreditCurrency = "GBP",
            DebitNarrative = "ISABEL DANCE LESSONS",
            BeneficiaryReference = "Mrs J Day",
            iBankReference = "RQ20121204-9",
            PaymentMethod = null,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.International,
            BeneficiaryName = "Boonie Ranby",
            BeneficiaryAccountNumber = "39779809",
            Pinned = true,
            CreatedDate = new DateTime(2022, 10, 21)
        },
        new PayeeTemplateModel
        {
            ID = 11,
            ClientNumber = "00063",
            DebitAccount = "00000075",
            HostReference = "628821669",
            CreditCurrency = "GBP",
            DebitNarrative = "monthly football fee",
            BeneficiaryReference = "Brokerage Partners",
            iBankReference = "RQ20161117-7",
            PaymentMethod = PaymentMethodEnum.BACS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Helene Nowill",
            BeneficiaryAccountNumber = "53322577",
            Pinned = false,
            CreatedDate = new DateTime(2022, 10, 13)
        },
        new PayeeTemplateModel
        {
            ID = 12,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-7",
            CreditCurrency = "GBP",
            DebitNarrative = "Payment to mum",
            BeneficiaryReference = "Sierra investments Ltd",
            iBankReference = "RQ20121129-7",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Charmine	Benoy",
            BeneficiaryAccountNumber = "99614244",
            Pinned = false,
            CreatedDate = new DateTime(2022, 10, 10)
        },
        new PayeeTemplateModel
        {
            ID = 13,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-9",
            CreditCurrency = "GBP",
            DebitNarrative = "payment for world cup",
            BeneficiaryReference = "Julie Hegarty",
            iBankReference = "RQ20121129-9",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Esdras Geffen",
            BeneficiaryAccountNumber = "41789065",
            Pinned = true,
            CreatedDate = new DateTime(2022, 09, 27)
        },
        new PayeeTemplateModel
        {
            ID = 14,
            ClientNumber = "00002",
            DebitAccount = "00002001",
            HostReference = "RQ20121204-11",
            CreditCurrency = "GBP",
            DebitNarrative = "ISABEL DANCE LESSONS",
            BeneficiaryReference = "Mrs J Day",
            iBankReference = "RQ20121204-11",
            PaymentMethod = null,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.International,
            BeneficiaryName = "Boonie Ranby",
            BeneficiaryAccountNumber = "39779809",
            Pinned = true,
            CreatedDate = new DateTime(2022, 09, 12)
        },
        new PayeeTemplateModel
        {
            ID = 15,
            ClientNumber = "00063",
            DebitAccount = "00000075",
            HostReference = "628821669",
            CreditCurrency = "GBP",
            DebitNarrative = "monthly football fee",
            BeneficiaryReference = "Brokerage Partners",
            iBankReference = "RQ20161117-8",
            PaymentMethod = PaymentMethodEnum.BACS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Helene Nowill",
            BeneficiaryAccountNumber = "53322577",
            Pinned = false,
            CreatedDate = new DateTime(2022, 09, 07)
        },
        new PayeeTemplateModel
        {
            ID = 16,
            ClientNumber = "10023",
            DebitAccount = "10023001",
            HostReference = "RQ20121129-10",
            CreditCurrency = "GBP",
            DebitNarrative = "Payment to mum",
            BeneficiaryReference = "Sierra investments Ltd",
            iBankReference = "RQ20121129-10",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentTemplateDetails = "",
            PaymentTemplateType = PaymentTypeEnum.Domestic,
            BeneficiaryName = "Charmine	Benoy",
            BeneficiaryAccountNumber = "99614244",
            Pinned = false,
            CreatedDate = new DateTime(2022, 09, 01)
        },
    };

    public static List<CreatePaymentRequestModel> LastPaymentTransactions = new()
    {
        new CreatePaymentRequestModel
        {
            TemplateRefernce = "RQ20121129-5",
            DebitNarrative = "payment for world cup",
            PaymentReference = "RQ20121129-5",
            PaymentMethod = PaymentMethodEnum.BACS,
            PaymentDate = new DateTime(2022, 11, 21),
            PaymentType = PaymentTypeEnum.Domestic,
            CreditAmount = 175.000M,
            DebitAccount = "10023001",
            TypeOfDocument = "Name and Address"
        },
        new CreatePaymentRequestModel
        {
            TemplateRefernce = "RQ20121204-1",
            DebitNarrative = "payment for world cup",
            PaymentReference = "RQ20121204-1",
            PaymentMethod = PaymentMethodEnum.Faster,
            PaymentDate = new DateTime(2022, 11, 12),
            PaymentType = PaymentTypeEnum.Domestic,
            CreditAmount = 1265.000M,
            DebitAccount = "00002001",
            TypeOfDocument = "Address"
        },
        new CreatePaymentRequestModel
        {
            TemplateRefernce = "628821669",
            DebitNarrative = "payment for world cup",
            PaymentReference = "628821669",
            PaymentMethod = PaymentMethodEnum.BACS,
            PaymentDate = new DateTime(2022, 10, 17),
            PaymentType = PaymentTypeEnum.Domestic,
            CreditAmount = 2975.000M,
            DebitAccount = "00002001",
            TypeOfDocument = "Name"
        },
        new CreatePaymentRequestModel
        {
            TemplateRefernce = "RQ20121129-3",
            DebitNarrative = "payment for world cup",
            PaymentReference = "RQ20121129-3",
            PaymentMethod = PaymentMethodEnum.CHAPS,
            PaymentDate = new DateTime(2022, 10, 03),
            PaymentType = PaymentTypeEnum.Domestic,
            CreditAmount = 1375.000M,
            DebitAccount = "00002001",
            TypeOfDocument = "CV"
        },
    };

    public static RecentTransactionModel RecentTransaction_Page1 = new()
    {
        RecentTransactions = new()
        {
            new TransactionModel
            {
                Reference = "PMS00242",
                Narrative = "Paid invoice #00242 for Sept",
                CreatedDate = new DateTime(2021, 09, 25),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Domestic
            },
            new TransactionModel
            {
                Reference = "PMS00241",
                Narrative = "Paid invoice #00241 for Sept",
                CreatedDate = new DateTime(2021, 05, 09),
                DebitAmount = -1200.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.SWIFT
            },
            new TransactionModel
            {
                Reference = "PMS00240",
                Narrative = "Paid invoice #00240 for Sept",
                CreatedDate = new DateTime(2020, 10, 25),
                CreditAmount = 123456789.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.Transfer
            },
            new TransactionModel
            {
                Reference = "PMS00239",
                Narrative = "Paid invoice #00239 for Sept",
                CreatedDate = new DateTime(2020, 09, 29),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Batches
            },
            new TransactionModel
            {
                Reference = "PMS00238",
                Narrative = "Paid invoice #00238 for Sept",
                CreatedDate = new DateTime(2021, 08, 20),
                CreditAmount = 100.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Domestic
            },
        },
        TotalRecords = 12
    };

    public static RecentTransactionModel RecentTransaction_Page2 = new()
    {
        RecentTransactions = new()
        {
            new TransactionModel
            {
                Reference = "PMS00237",
                Narrative = "Paid invoice #00237 for Sept",
                CreatedDate = new DateTime(2021, 09, 25),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Domestic
            },
            new TransactionModel
            {
                Reference = "PMS00236",
                Narrative = "Paid invoice #00236 for Sept",
                CreatedDate = new DateTime(2021, 05, 09),
                DebitAmount = -1200.00M,
                Balance = 356878934.00M,
                ProductType = ProductTypeEnum.Domestic
            },
            new TransactionModel
            {
                Reference = "PMS00235",
                Narrative = "Paid invoice #00235 for Sept",
                CreatedDate = new DateTime(2020, 10, 25),
                CreditAmount = 243215436.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.Domestic
            },
            new TransactionModel
            {
                Reference = "PMS00234",
                Narrative = "Paid invoice #00234 for Sept",
                CreatedDate = new DateTime(2020, 09, 29),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Domestic
            },
            new TransactionModel
            {
                Reference = "PMS00233",
                Narrative = "Paid invoice #00233 for Sept",
                CreatedDate = new DateTime(2021, 08, 20),
                CreditAmount = 100.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Domestic
            },
        },
        TotalRecords = 12
    };

    public static RecentTransactionModel RecentTransaction_Page3 = new()
    {
        RecentTransactions = new()
        {
            new TransactionModel
            {
                Reference = "PMS00232",
                Narrative = "Paid invoice #00232 for Sept",
                CreatedDate = new DateTime(2021, 09, 25),
                DebitAmount = -100.00M,
                Balance = 534212300.00M,
                ProductType = ProductTypeEnum.Domestic
            },
            new TransactionModel
            {
                Reference = "PMS00231",
                Narrative = "Paid invoice #00231 for Sept",
                CreatedDate = new DateTime(2021, 05, 09),
                DebitAmount = 999120065.00M,
                Balance = 1700.00M,
                ProductType = ProductTypeEnum.Domestic
            }
        },
        TotalRecords = 12
    };

    public static List<CurrencyModel> Currencies = new()
    {
        new CurrencyModel
        {
            Code = "CAD",
            Description = "Canadian Dollar",
            DecimalPlaces = 2
        },
        new CurrencyModel
        {
            Code = "EUR",
            Description = "Euro",
            DecimalPlaces = 2
        },
        new CurrencyModel
        {
            Code = "JPY",
            Description = "Yen",
            DecimalPlaces = 2
        },
        new CurrencyModel
        {
            Code = "SEK",
            Description = "Swedish Kroner",
            DecimalPlaces = 2
        },
        new CurrencyModel
        {
            Code = "USD",
            Description = "U.S. Dollars",
            DecimalPlaces = 2
        },
        new CurrencyModel
        {
            Code = "GBP",
            Description = "GB Pounds",
            DecimalPlaces = 2
        },
    };

    public static RecentTransactionModel RecentTransaction_All = new()
    {
        RecentTransactions = new()
        {
            new TransactionModel
            {
                AccountNumber = "10023001",
                Reference = "PMS00242",
                Narrative = "Paid invoice #00242 for Sept",
                CreatedDate = new DateTime(2021, 09, 25),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Domestic,
                TransactionType = TransactionTypeEnum.Income
            },
            new TransactionModel
            {
                AccountNumber = "00000077",
                Reference = "PMS00241",
                Narrative = "Paid invoice #00241 for Sept",
                CreatedDate = new DateTime(2021, 05, 09),
                DebitAmount = -1200.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.Transfer,
                TransactionType = TransactionTypeEnum.Outcome
            },
            new TransactionModel
            {
                AccountNumber = "00000077",
                Reference = "PMS00240",
                Narrative = "Paid invoice #00240 for Sept",
                CreatedDate = new DateTime(2020, 10, 25),
                CreditAmount = 900.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.Domestic,
                TransactionType = TransactionTypeEnum.Income
            },
            new TransactionModel
            {
                AccountNumber = "10023002",
                Reference = "PMS00239",
                Narrative = "Paid invoice #00239 for Sept",
                CreatedDate = new DateTime(2020, 09, 29),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Transfer,
                TransactionType = TransactionTypeEnum.Outcome
            },
            new TransactionModel
            {
                AccountNumber = "10023002",
                Reference = "PMS00238",
                Narrative = "Paid invoice #00238 for Sept",
                CreatedDate = new DateTime(2021, 08, 20),
                CreditAmount = 100.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Transfer,
                TransactionType = TransactionTypeEnum.Outcome
            },
            new TransactionModel
            {
                AccountNumber = "10023002",
                Reference = "PMS00237",
                Narrative = "Paid invoice #00237 for Sept",
                CreatedDate = new DateTime(2021, 09, 25),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Transfer,
                TransactionType = TransactionTypeEnum.Income
            },
            new TransactionModel
            {
                AccountNumber = "00000075",
                Reference = "PMS00236",
                Narrative = "Paid invoice #00236 for Sept",
                CreatedDate = new DateTime(2021, 05, 09),
                DebitAmount = -1200.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.Transfer,
                TransactionType = TransactionTypeEnum.Income
            },
            new TransactionModel
            {
                AccountNumber = "00000075",
                Reference = "PMS00235",
                Narrative = "Paid invoice #00235 for Sept",
                CreatedDate = new DateTime(2020, 10, 25),
                CreditAmount = 900.00M,
                Balance = 999999999.00M,
                ProductType = ProductTypeEnum.Batches,
                TransactionType = TransactionTypeEnum.Income,
            },
            new TransactionModel
            {
                AccountNumber = "00000075",
                Reference = "PMS00234",
                Narrative = "Paid invoice #00234 for Sept",
                CreatedDate = new DateTime(2020, 09, 29),
                DebitAmount = -999999999.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Batches,
                TransactionType = TransactionTypeEnum.Outcome,
            },
            new TransactionModel
            {
                AccountNumber = "10023001",
                Reference = "PMS00233",
                Narrative = "Paid invoice #00233 for Sept",
                CreatedDate = new DateTime(2021, 08, 20),
                CreditAmount = 100.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.Batches,
                TransactionType = TransactionTypeEnum.Income
            },
            new TransactionModel
            {
                AccountNumber = "10023001",
                Reference = "PMS00232",
                Narrative = "Paid invoice #00232 for Sept",
                CreatedDate = new DateTime(2021, 09, 25),
                DebitAmount = -100.00M,
                Balance = 500.00M,
                ProductType = ProductTypeEnum.SWIFT,
                TransactionType = TransactionTypeEnum.Outcome
            },
            new TransactionModel
            {
                AccountNumber = "00000075",
                Reference = "PMS00231",
                Narrative = "Paid invoice #00231 for Sept",
                CreatedDate = new DateTime(2021, 05, 09),
                DebitAmount = -1200.00M,
                Balance = 1700.00M,
                ProductType = ProductTypeEnum.SWIFT,
                TransactionType = TransactionTypeEnum.Income
            }
        },
        TotalRecords = 12
    };

    public static List<IMailMessageModel> iMailMessages = new()
    {
        new IMailMessageModel()
        {
            MailID = 1,
            SenderID = 1,
            ReceiverID = 2,
            Status = IMailStatusEnum.New,
            Message =
                "Hello, Jane! Your request about credit of $50,000 was approved by Bank. We will contact you for further details. Notice that you will need to provide additional documentation to prove your payment availability. Have a great weekends!Hello, Jane! Your request about credit of $50,000 was approved by Bank. We will contact you for further details. Notice that you will need to provide additional documentation to prove your payment availability.",
            Priority = IMailPriorityEnum.High,
            Subject = "Credit opportunity",
            CreatedDate = DateTime.Now,
            AnswerIMailMessages = new List<AnswerIMailMessageModel>()
            {
                new AnswerIMailMessageModel()
                {
                    AnswerID = 1,
                    MailID = 1,
                    CreatedDate = new DateTime(2021, 09, 25),
                    Subject = "Credit opportunity",
                    Message = "Thank you, Anna for the answer. Let me know please does the bank require these documents for the payment opportunity prove?",
                    Priority = IMailPriorityEnum.High,
                    ReceiverID = 1,
                    SenderID = 2,
                    Status= IMailStatusEnum.New
                }
            }
        },
        new IMailMessageModel()
        {
            MailID = 2,
            SenderID = 1,
            ReceiverID = 2,
            Status = IMailStatusEnum.Read,
            Message =
                "Hello, Jane! Your request about credit of $50,000 was approved by Bank. We will contact you for further details. Notice that you will need to provide additional documentation to prove your payment availability. Have a great weekends!Hello, Jane! Your request about credit of $50,000 was approved by Bank. We will contact you for further details. Notice that you will need to provide additional documentation to prove your payment availability.",
            Priority = IMailPriorityEnum.High,
            Subject = "Credit opportunity",
            CreatedDate = DateTime.Now,
        },
    };

    public static List<UserInfoModel> UserInfos = new()
    {
        new UserInfoModel()
        {
            UserID = 1,
            UserName = "Anna Smith",
            Role = "Relationship Manager",
            FirstName = "Anna",
            LastName = "Smith",
            DateOfBirth = new DateTime(1990, 05, 15),
            AvartaUrl = "/img/header/avatarDummy.png"
        },
        new UserInfoModel()
        {
            UserID = 2,
            UserName = "Jane Watson",
            Role = "Relationship Staff",
            FirstName = "Jane",
            LastName = "Watson",
            DateOfBirth = new DateTime(1995, 04, 28),
            AvartaUrl = "/img/header/jane-watson.png"
        }
    };


    public static NotificationsModel Notifications = new()
    {
        AwaitingSignoffNotifications = new()
        {
            new AwaitingSignoffNotificationModel()
            {
                UserID = 84008402,
                Name = "Lindsey Mango",
                Description = "Administrator 1 has offered to Lock account. You need to Confirm or Reject this action.",
                LastAccessBy = string.Empty,
                NewAuthorityCode = string.Empty,
                Note = string.Empty,
                Status = UserActionStatusEnum.AwaitingSignoff,
                Time = "7 hours",
                UrlAvarta = "/img/sign/avatar1.svg"
            },
            new AwaitingSignoffNotificationModel()
            {
                UserID = 84028490,
                Name = "Marley Passaquindici Arcand",
                Description = "Administrator 1 has offered to Lock account. You need to Confirm or Reject this action.",
                LastAccessBy = string.Empty,
                NewAuthorityCode = string.Empty,
                Note = string.Empty,
                Status = UserActionStatusEnum.AwaitingSignoff,
                Time = "1 day",
                UrlAvarta = "/img/sign/avatar2.svg"
            }
        },
        MSEAuthorityCodeNotification = new()
        {
            Name = "MSE Authority Code",
            Description =
                "Administrator 1  has requested a change to the MSE Authority Code which requires your signature to make it active.",
            LastAccessBy = "29 October 2022 at 10:37",
            NewAuthorityCode = "12345678910",
            Note = string.Empty,
            Status = AuthorityCodeStatusEnum.AwaitingSignoff,
            Time = "23 min ago",
            Icon = "/img/admin/authorityCodeIcon.svg"
        }
    };

    public static UserActionsModel UserActions = new UserActionsModel()
    {
        LastUsers = new List<UserInfoModel>()
        {
            new UserInfoModel()
            {
                UserID = 84008402,
                UserName = "Lindsey Mango",
                Role = "Relationship Staff",
                FirstName = "Lindsey",
                LastName = "Mango",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "lindsey.mango@gmail.com",
                PhoneNumberIDD = "+44",
                PhoneNumber = "555 753 654",
                AvartaUrl = "/img/sign/avatar1.svg",
                LastLoggedin = string.Empty,
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.AwaitingSignoff,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            },
            new UserInfoModel()
            {
                UserID = 84028490,
                UserName = "Marley Passaquindici Arcand",
                Role = "Relationship Staff",
                FirstName = "Marley",
                MiddleName = "Passaquindici",
                LastName = "Arcand",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "marley.arcand@gmail.com",
                PhoneNumberIDD = "",
                PhoneNumber = "",
                AvartaUrl = "/img/sign/avatar2.svg",
                LastLoggedin = string.Empty,
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.AwaitingSignoff,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            },
            new UserInfoModel()
            {
                UserID = 84028491,
                UserName = "Tiana Siphron",
                Role = "Relationship Staff",
                FirstName = "Tiana",
                LastName = "Siphron",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "tiana.siphron@gmail.com",
                PhoneNumberIDD = "",
                PhoneNumber = "",
                AvartaUrl = "/img/sign/avatar3.svg",
                LastLoggedin = "15 June 2021 at 9:30:31",
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.Confirmed,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            },
            new UserInfoModel()
            {
                UserID = 84028492,
                UserName = "Leo Baptista",
                Role = "Relationship Staff",
                FirstName = "Leo",
                LastName = "Baptista",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "leo.baptista@gmail.com",
                PhoneNumberIDD = "",
                PhoneNumber = "",
                AvartaUrl = "/img/sign/avatar3.svg",
                LastLoggedin = "18 June 2021 at 16:20:31",
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.Confirmed,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            }
        },
        TotalRecords = 3
    };

    public static List<UserInfoModel> LastUsers = new List<UserInfoModel>()
    {
        new UserInfoModel()
        {
            UserID = 84008402,
            UserName = "Lindsey Mango",
            Role = "Relationship Staff",
            FirstName = "Lindsey",
            LastName = "Mango",
            DateOfBirth = new DateTime(1995, 04, 28),
            Email = "lindsey.mango@gmail.com",
            PhoneNumberIDD = "+44",
            PhoneNumber = "555 753 654",
            AvartaUrl = "/img/sign/avatar1.svg",
            LastLoggedin = string.Empty,
            NotificationSettings = new()
            {
                InformTransactionsSMS = true,
                InformTransactionsEmail = true,
                InformTransactionsiMail = true,

                InformNewBankServicesSMS = false,
                InformNewBankServicesEmail = false,
                InformNewBankServicesiMail = false,

                InformMessagesFromManageriMail = true,
                InformMessagesFromManagerSMS = true,
                InformMessagesFromManagerEmail = true,
            },
            SecuritySetting = SecurityFactorEnum.OneFactor,
            ActionStatus = UserActionStatusEnum.AwaitingSignoff,
            DevicesActiveSessions = new()
            {
                new DevicesActiveSessionModel()
                {
                    DeviceID = 1,
                    DeviceName = "Personal computer",
                    OperationSystem = "OS X 10.15.7",
                    IPAddress = "10.15.779.110.129.198",
                    Note =
                        "Authorization in the app on this device. You can log out of all devices except the current one."
                },
                new DevicesActiveSessionModel()
                {
                    DeviceID = 2,
                    DeviceName = "iPhone 8 Plus",
                    OperationSystem = "IOS 14.6",
                    IPAddress = "79.110.129.198",
                    Note = "Today 14:41"
                }
            }
        },
        new UserInfoModel()
        {
            UserID = 84028490,
            UserName = "Marley Passaquindici Arcand",
            Role = "Relationship Staff",
            FirstName = "Marley",
            MiddleName = "Passaquindici",
            LastName = "Arcand",
            DateOfBirth = new DateTime(1995, 04, 28),
            Email = "marley.arcand@gmail.com",
            PhoneNumberIDD = "",
            PhoneNumber = "",
            AvartaUrl = "/img/sign/avatar2.svg",
            LastLoggedin = string.Empty,
            NotificationSettings = new()
            {
                InformTransactionsSMS = true,
                InformTransactionsEmail = true,
                InformTransactionsiMail = true,

                InformNewBankServicesSMS = false,
                InformNewBankServicesEmail = false,
                InformNewBankServicesiMail = false,

                InformMessagesFromManageriMail = true,
                InformMessagesFromManagerSMS = true,
                InformMessagesFromManagerEmail = true,
            },
            SecuritySetting = SecurityFactorEnum.OneFactor,
            ActionStatus = UserActionStatusEnum.AwaitingSignoff,
            DevicesActiveSessions = new()
            {
                new DevicesActiveSessionModel()
                {
                    DeviceID = 1,
                    DeviceName = "Personal computer",
                    OperationSystem = "OS X 10.15.7",
                    IPAddress = "10.15.779.110.129.198",
                    Note =
                        "Authorization in the app on this device. You can log out of all devices except the current one."
                },
                new DevicesActiveSessionModel()
                {
                    DeviceID = 2,
                    DeviceName = "iPhone 8 Plus",
                    OperationSystem = "IOS 14.6",
                    IPAddress = "79.110.129.198",
                    Note = "Today 14:41"
                }
            }
        },
        new UserInfoModel()
        {
            UserID = 84028491,
            UserName = "Tiana Siphron",
            Role = "Relationship Staff",
            FirstName = "Tiana",
            LastName = "Siphron",
            DateOfBirth = new DateTime(1995, 04, 28),
            Email = "tiana.siphron@gmail.com",
            PhoneNumberIDD = "",
            PhoneNumber = "",
            AvartaUrl = "/img/sign/avatar3.svg",
            LastLoggedin = "15 June 2021 at 9:30:31",
            NotificationSettings = new()
            {
                InformTransactionsSMS = true,
                InformTransactionsEmail = true,
                InformTransactionsiMail = true,

                InformNewBankServicesSMS = false,
                InformNewBankServicesEmail = false,
                InformNewBankServicesiMail = false,

                InformMessagesFromManageriMail = true,
                InformMessagesFromManagerSMS = true,
                InformMessagesFromManagerEmail = true,
            },
            SecuritySetting = SecurityFactorEnum.OneFactor,
            ActionStatus = UserActionStatusEnum.Confirmed,
            DevicesActiveSessions = new()
            {
                new DevicesActiveSessionModel()
                {
                    DeviceID = 1,
                    DeviceName = "Personal computer",
                    OperationSystem = "OS X 10.15.7",
                    IPAddress = "10.15.779.110.129.198",
                    Note =
                        "Authorization in the app on this device. You can log out of all devices except the current one."
                },
                new DevicesActiveSessionModel()
                {
                    DeviceID = 2,
                    DeviceName = "iPhone 8 Plus",
                    OperationSystem = "IOS 14.6",
                    IPAddress = "79.110.129.198",
                    Note = "Today 14:41"
                }
            }
        },
        new UserInfoModel()
        {
            UserID = 84028492,
            UserName = "Leo Baptista",
            Role = "Relationship Staff",
            FirstName = "Leo",
            LastName = "Baptista",
            DateOfBirth = new DateTime(1995, 04, 28),
            Email = "leo.baptista@gmail.com",
            PhoneNumberIDD = "",
            PhoneNumber = "",
            AvartaUrl = "/img/sign/avatar3.svg",
            LastLoggedin = "18 June 2021 at 16:20:31",
            NotificationSettings = new()
            {
                InformTransactionsSMS = true,
                InformTransactionsEmail = true,
                InformTransactionsiMail = true,

                InformNewBankServicesSMS = false,
                InformNewBankServicesEmail = false,
                InformNewBankServicesiMail = false,

                InformMessagesFromManageriMail = true,
                InformMessagesFromManagerSMS = true,
                InformMessagesFromManagerEmail = true,
            },
            SecuritySetting = SecurityFactorEnum.OneFactor,
            ActionStatus = UserActionStatusEnum.Confirmed,
            DevicesActiveSessions = new()
            {
                new DevicesActiveSessionModel()
                {
                    DeviceID = 1,
                    DeviceName = "Personal computer",
                    OperationSystem = "OS X 10.15.7",
                    IPAddress = "10.15.779.110.129.198",
                    Note =
                        "Authorization in the app on this device. You can log out of all devices except the current one."
                },
                new DevicesActiveSessionModel()
                {
                    DeviceID = 2,
                    DeviceName = "iPhone 8 Plus",
                    OperationSystem = "IOS 14.6",
                    IPAddress = "79.110.129.198",
                    Note = "Today 14:41"
                }
            }
        }
    };    

    public static UserMaintenanceModel UserMaintenance = new UserMaintenanceModel()
    {
        UserInfos = new List<UserInfoModel>()
        {
            new UserInfoModel()
            {
                UserID = 84008402,
                UserName = "Lindsey Mango",
                Role = "Relationship Staff",
                FirstName = "Lindsey",
                LastName = "Mango",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "lindsey.mango@gmail.com",
                PhoneNumberIDD = "+44",
                PhoneNumber = "555 753 654",
                AvartaUrl = "/img/sign/avatar1.svg",
                LastLoggedin = string.Empty,
                GroupID = 3,
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.AwaitingSignoff,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            },
            new UserInfoModel()
            {
                UserID = 84028490,
                UserName = "Marley Passaquindici Arcand",
                Role = "Relationship Staff",
                FirstName = "Marley",
                MiddleName = "Passaquindici",
                LastName = "Arcand",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "marley.arcand@gmail.com",
                PhoneNumberIDD = "",
                PhoneNumber = "",
                AvartaUrl = "/img/sign/avatar2.svg",
                LastLoggedin = string.Empty,
                GroupID = 4,
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.AwaitingSignoff,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            },
            new UserInfoModel()
            {
                UserID = 84028491,
                UserName = "Tiana Siphron",
                Role = "Relationship Staff",
                FirstName = "Tiana",
                LastName = "Siphron",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "tiana.siphron@gmail.com",
                PhoneNumberIDD = "",
                PhoneNumber = "",
                AvartaUrl = "/img/sign/avatar3.svg",
                LastLoggedin = "15 June 2021 at 9:30:31",
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.Locked,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            },
            new UserInfoModel()
            {
                UserID = 84028492,
                UserName = "Leo Baptista",
                Role = "Relationship Staff",
                FirstName = "Leo",
                LastName = "Baptista",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "leo.baptista@gmail.com",
                PhoneNumberIDD = "",
                PhoneNumber = "",
                AvartaUrl = "/img/sign/avatar8.svg",
                LastLoggedin = "18 June 2021 at 16:20:31",
                GroupID = 7,
                NotificationSettings = new()
                {
                    InformTransactionsSMS = true,
                    InformTransactionsEmail = true,
                    InformTransactionsiMail = true,

                    InformNewBankServicesSMS = false,
                    InformNewBankServicesEmail = false,
                    InformNewBankServicesiMail = false,

                    InformMessagesFromManageriMail = true,
                    InformMessagesFromManagerSMS = true,
                    InformMessagesFromManagerEmail = true,
                },
                SecuritySetting = SecurityFactorEnum.OneFactor,
                ActionStatus = UserActionStatusEnum.Confirmed,
                DevicesActiveSessions = new()
                {
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 1,
                        DeviceName = "Personal computer",
                        OperationSystem = "OS X 10.15.7",
                        IPAddress = "10.15.779.110.129.198",
                        Note =
                            "Authorization in the app on this device. You can log out of all devices except the current one."
                    },
                    new DevicesActiveSessionModel()
                    {
                        DeviceID = 2,
                        DeviceName = "iPhone 8 Plus",
                        OperationSystem = "IOS 14.6",
                        IPAddress = "79.110.129.198",
                        Note = "Today 14:41"
                    }
                }
            }
        },
        TotalRecords = 4,
    };
}