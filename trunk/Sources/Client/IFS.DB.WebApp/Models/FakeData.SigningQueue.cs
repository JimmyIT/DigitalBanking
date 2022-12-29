using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Batch;
using IFS.DB.WebApp.Models.SigningQueue;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Models;

public partial class FakeData
{
    static FakeData()
    {
        CommonSigningQueues.AddRange(SubSigningQueuesPayments);
        CommonSigningQueues.AddRange(SubSigningQueuesTransfers);
        CommonSigningQueues.AddRange(SubSigningQueuesPayees);
        CommonSigningQueues.AddRange(SubSigningQueuesBatches);
    }

    public static readonly List<SigningQueueModel> SigningQueues = new List<SigningQueueModel>
    {
        new()
        {
            ProductType = ProductTypeQueue.Payment,
            TotalSignOff = 3,
            AwaitingSignOff = 1,
        },
        new()
        {
            ProductType = ProductTypeQueue.PayeeTemplate,
            TotalSignOff = 2,
            AwaitingSignOff = 2,
        },
        new()
        {
            ProductType = ProductTypeQueue.Transfer,
            TotalSignOff = 4,
            AwaitingSignOff = 1,
        },
        new()
        {
            ProductType = ProductTypeQueue.Batch,
            TotalSignOff = 10,
            AwaitingSignOff = 2,
        }
    };

    public static readonly List<_PaymentQueueModel> PaymentQueues = new List<_PaymentQueueModel>
    {
        new()
        {
            Id = 1,
            TemplateReference = "RH6",
            DefaultAccount = "Bank Operational Account - IB Account No. 00256001",
            SortCode = "12 - 31- 56",
            AccountName = "Angel Press",
            AccountNumber = "0025601",
            PayeeReference = "Text for Payee Reference that explain everything",
            DebitAccount = "Account No. 00256001",
            UserReference = "RQ201842998-15",
            PaymentDate = new DateTime(2022, 04, 12),
            DebitNarrative = "Narrative Text",
            DefaultCreditNarrative = "Default Credit Narrative Text. Default Credit Narrative Text.",
            CreditAmount = 100000m
        },
        new()
        {
            Id = 2,
            TemplateReference = "RH6",
            DefaultAccount = "Bank Operational Account - IB Account No. 00256001",
            SortCode = "12 - 31- 56",
            AccountName = "Angel Press",
            AccountNumber = "0025601",
            PayeeReference = "Text for Payee Reference that explain everything",
            DebitAccount = "Account No. 00256001",
            UserReference = "RQ201842998-16",
            PaymentDate = new DateTime(2022, 04, 12),
            DebitNarrative = "Narrative Text",
            DefaultCreditNarrative = "Default Credit Narrative Text. Default Credit Narrative Text.",
            CreditAmount = 150000m
        },
        new()
        {
            Id = 3,
            TemplateReference = "RH6",
            DefaultAccount = "Bank Operational Account - IB Account No. 00256001",
            SortCode = "12 - 31- 56",
            AccountName = "Angel Press",
            AccountNumber = "0025601",
            PayeeReference = "Text for Payee Reference that explain everything",
            DebitAccount = "Account No. 00256001",
            UserReference = "RQ201842998-17",
            PaymentDate = new DateTime(2022, 04, 12),
            DebitNarrative = "Narrative Text",
            DefaultCreditNarrative = "Default Credit Narrative Text. Default Credit Narrative Text.",
            CreditAmount = 200000m
        }
    };

    public static readonly List<_TransferQueueModel> TransferQueues = new List<_TransferQueueModel>
    {
        new()
        {
            Id = 1,
            DebitAccount = "00000077",
            CreditAccount = "10023002",
            CreditNarrative = "Credit narrative",
            DebitNarrative = "Debit narrative",
            Amount = 10.00M,
            TransferDate = DateTime.Now
        },
        new()
        {
            Id = 2,
            DebitAccount = "10023002",
            CreditAccount = "00000077",
            CreditNarrative = "Credit narrative",
            DebitNarrative = "Debit narrative",
            Amount = 12.50M,
            TransferDate = DateTime.Today.AddDays(-10)
        },
        new()
        {
            Id = 3,
            DebitAccount = "00000075",
            CreditAccount = "00002001",
            CreditNarrative = "Credit narrative",
            DebitNarrative = "Debit narrative",
            Amount = 100.0M,
            TransferDate = DateTime.Today.AddMonths(-1).AddDays(+1)
        }
    };

    public static readonly List<_PayeeQueueModel> PayeeQueues = new List<_PayeeQueueModel>
    {
        new()
        {
            Id = 1,
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
            CreatedDate = new DateTime(2022, 11, 21),
            SortCode = 123
        },
        new()
        {
            Id = 2,
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
            CreatedDate = new DateTime(2022, 11, 18),
            SortCode = 234
        },
        new()
        {
            Id = 3,
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
            CreatedDate = new DateTime(2022, 11, 15),
            SortCode = 554
        },
        new()
        {
            Id = 4,
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
            CreatedDate = new DateTime(2022, 11, 12),
            SortCode = 112
        },
    };

    public static readonly List<BatchModel> BatchQueues = new List<BatchModel>
    {
        new()
        {
            Id = 1,
            UserReference = "37297476920123",
            DebitAccount = "10023002",
            Amount = 100000m,
            PaymentDate = new DateTime(2021, 11, 12),
            Status = BatchStatus.Waiting,
            SubmittedDate = new DateTime(2021, 11, 12),
            DebitNarrative = "DebitNarrative",
            DefaultCreditNarrative = "DefaultCreditNarrative",
            BatchItems = new List<BatchItemModel>
            {
                new()
                {
                    Amount = 30000m,
                    BatchId = 1,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 20000m,
                    BatchId = 1,
                    CreditAccount = "10023002",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 50000m,
                    BatchId = 1,
                    CreditAccount = "00002001",
                    TransactionType = TransactionType.Transfer,
                }
            }
        },
        new()
        {
            Id = 2,
            UserReference = "37297476920128",
            DebitAccount = "00000075",
            Amount = 3000m,
            PaymentDate = new DateTime(2021, 11, 16),
            Status = BatchStatus.Waiting,
            SubmittedDate = new DateTime(2021, 11, 16),
            RequiredSignatures = 3,
            CurrentSignatures = 2,
            DebitNarrative = "DebitNarrative",
            DefaultCreditNarrative = "DefaultCreditNarrative",
            BatchItems = new List<BatchItemModel>
            {
                new()
                {
                    Amount = 1000m,
                    BatchId = 2,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 2,
                    CreditAccount = "10023002",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 2,
                    CreditAccount = "00002001",
                    TransactionType = TransactionType.Transfer,
                },
            }
        },
        new()
        {
            Id = 1,
            UserReference = "37297476920123",
            DebitAccount = "10023002",
            Amount = 100000m,
            PaymentDate = new DateTime(2021, 11, 12),
            Status = BatchStatus.Draft,
            SubmittedDate = new DateTime(2021, 11, 12),
            DebitNarrative = "DebitNarrative",
            DefaultCreditNarrative = "DefaultCreditNarrative",
            BatchItems = new List<BatchItemModel>
            {
                new()
                {
                    Amount = 70000m,
                    BatchId = 4,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 20000m,
                    BatchId = 4,
                    CreditAccount = "10023002",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 10000m,
                    BatchId = 4,
                    CreditAccount = "00002001",
                    TransactionType = TransactionType.Transfer,
                },
            }
        },
        new()
        {
            Id = 3,
            UserReference = "37297476922284",
            DebitAccount = "00002001", Amount = 140000m,
            PaymentDate = new DateTime(2021, 11, 2),
            Status = BatchStatus.Submitted,
            SubmittedDate = new DateTime(2021, 11, 2),
            DebitNarrative = "DebitNarrative",
            DefaultCreditNarrative = "DefaultCreditNarrative",
            BatchItems = new List<BatchItemModel>
            {
                new()
                {
                    Amount = 100000m,
                    BatchId = 4,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 40000m,
                    BatchId = 4,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Transfer,
                }
            }
        },
    };

    public static readonly List<CommonQueueModel> CommonSigningQueues = new List<CommonQueueModel>
    {
    };

    static readonly List<CommonQueueModel> SubSigningQueuesPayments = new List<CommonQueueModel>
    {
        new()
        {
            Id = 2,
            ItemId = 2,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-16",
            ProductType = ProductTypeQueue.Payment,
            CreatedBy = new UserInfoBrief
            {
                Name = "Lindsey Mango",
                AvatarUrl = "/img/sign/avatar1.svg"
            },
            TotalSignOff = 5,
            AwaitingSignOff = 4,
            CanSign = false,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 3,
            ItemId = 3,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-17",
            ProductType = ProductTypeQueue.Payment,
            CreatedBy = new UserInfoBrief
            {
                Name = "Tiana Siphron",
                AvatarUrl = "/img/sign/avatar3.svg"
            },
            TotalSignOff = 3,
            AwaitingSignOff = 1,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        }
    };

    static readonly List<CommonQueueModel> SubSigningQueuesTransfers = new List<CommonQueueModel>
    {
        new()
        {
            Id = 4,
            ItemId = 1,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-15",
            ProductType = ProductTypeQueue.Transfer,
            CreatedBy = new UserInfoBrief
            {
                Name = "Kaylynn Ekstrom Bothman",
                AvatarUrl = "/img/sign/avatar4.svg"
            },
            TotalSignOff = 4,
            AwaitingSignOff = 2,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 5,
            ItemId = 2,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-16",
            ProductType = ProductTypeQueue.Transfer,
            CreatedBy = new UserInfoBrief
            {
                Name = "Lindsey Mango",
                AvatarUrl = "/img/sign/avatar1.svg"
            },
            TotalSignOff = 5,
            AwaitingSignOff = 4,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 6,
            ItemId = 3,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-17",
            ProductType = ProductTypeQueue.Transfer,
            CreatedBy = new UserInfoBrief
            {
                Name = "Tiana Siphron",
                AvatarUrl = "/img/sign/avatar3.svg"
            },
            TotalSignOff = 3,
            AwaitingSignOff = 1,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        }
    };

    static readonly List<CommonQueueModel> SubSigningQueuesPayees = new List<CommonQueueModel>
    {
        new()
        {
            Id = 7,
            ItemId = 1,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-15",
            ProductType = ProductTypeQueue.PayeeTemplate,
            CreatedBy = new UserInfoBrief
            {
                Name = "Kaylynn Ekstrom Bothman",
                AvatarUrl = "/img/sign/avatar4.svg"
            },
            TotalSignOff = 4,
            AwaitingSignOff = 2,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 8,
            ItemId = 2,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-16",
            ProductType = ProductTypeQueue.PayeeTemplate,
            CreatedBy = new UserInfoBrief
            {
                Name = "Lindsey Mango",
                AvatarUrl = "/img/sign/avatar1.svg"
            },
            TotalSignOff = 5,
            AwaitingSignOff = 4,
            CanSign = false,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 9,
            ItemId = 3,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-17",
            ProductType = ProductTypeQueue.PayeeTemplate,
            CreatedBy = new UserInfoBrief
            {
                Name = "Tiana Siphron",
                AvatarUrl = "/img/sign/avatar3.svg"
            },
            TotalSignOff = 3,
            AwaitingSignOff = 1,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        }
    };

    static readonly List<CommonQueueModel> SubSigningQueuesBatches = new List<CommonQueueModel>
    {
        new()
        {
            Id = 10,
            ItemId = 1,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-15",
            ProductType = ProductTypeQueue.Batch,
            CreatedBy = new UserInfoBrief
            {
                Name = "Kaylynn Ekstrom Bothman",
                AvatarUrl = "/img/sign/avatar4.svg"
            },
            TotalSignOff = 4,
            AwaitingSignOff = 2,
            CanSign = true,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 11,
            ItemId = 2,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-16",
            ProductType = ProductTypeQueue.Batch,
            CreatedBy = new UserInfoBrief
            {
                Name = "Lindsey Mango",
                AvatarUrl = "/img/sign/avatar1.svg"
            },
            TotalSignOff = 5,
            AwaitingSignOff = 4,
            CanSign = false,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Tiana Siphron",
                    AvatarUrl = "/img/sign/avatar3.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        },
        new()
        {
            Id = 12,
            ItemId = 3,
            DebitAccount = "Account No. 00256001",
            Reference = "RQ201842998-17",
            ProductType = ProductTypeQueue.Batch,
            CreatedBy = new UserInfoBrief
            {
                Name = "Tiana Siphron",
                AvatarUrl = "/img/sign/avatar3.svg"
            },
            TotalSignOff = 3,
            AwaitingSignOff = 1,
            CanSign = false,
            Signatories = new List<SignatoryModel>
            {
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 20)
                },
                new()
                {
                    Name = "Lindsey Mango",
                    AvatarUrl = "/img/sign/avatar1.svg",
                    SignedDate = new DateTime(2022, 11, 22)
                }
            }
        }
    };
}