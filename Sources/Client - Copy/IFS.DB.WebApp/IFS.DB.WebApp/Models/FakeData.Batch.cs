using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Batch;

namespace IFS.DB.WebApp.Models;

public static partial class FakeData
{
    public static readonly List<BatchModel> Batches = new List<BatchModel>()
    {
        // new() { UserReference = "37297476924229", DebitAccount = "44677682", Amount = 9000000m, PaymentDate = new DateTime(2021, 11, 17), Status = BatchStatus.Waiting, SubmittedDate =  new DateTime(2021, 11, 17), RequiredSignatures = 2, CurrentSignatures = 0},
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
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "10023002",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "00002001",
                    TransactionType = TransactionType.Transfer,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "10023002",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
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
            CanSign = true,
            DebitNarrative = "DebitNarrative",
            DefaultCreditNarrative = "DefaultCreditNarrative",
            BatchItems = new List<BatchItemModel>
            {
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "00000077",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
                    BatchId = 4,
                    CreditAccount = "10023002",
                    TransactionType = TransactionType.Payment,
                },
                new()
                {
                    Amount = 1000m,
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
}