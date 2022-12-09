using IFS.DB.WebApp.Models.SigningQueue;

namespace IFS.DB.WebApp.Models;

public partial class FakeData
{
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

    public static readonly List<PaymentQueueModel> PaymentQueues = new List<PaymentQueueModel>
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
            CreatedOn = new DateTime(2022, 04, 12),
            DefaultCreditNarrative = "Default Credit Narrative Text. Default Credit Narrative Text.",
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
            CreatedOn = new DateTime(2022, 08, 12),
            DebitNarrative = "Narrative Text",
            DefaultCreditNarrative = "Default Credit Narrative Text. Default Credit Narrative Text.",
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
            CreatedOn = new DateTime(2022, 12, 12),
            DebitNarrative = "Narrative Text",
            DefaultCreditNarrative = "Default Credit Narrative Text. Default Credit Narrative Text.",
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
}