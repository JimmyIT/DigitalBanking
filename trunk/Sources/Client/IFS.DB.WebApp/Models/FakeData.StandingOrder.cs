using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.StandingOrder;

namespace IFS.DB.WebApp.Models;

public static partial class FakeData
{
    public static readonly List<StandingOrderModel> StandingOrders = new List<StandingOrderModel>
    {
        new()
        {
            Id = 1,
            TransactionType = TransactionType.Payment,
            DebitNarrative = "Paid Invoice #564 for Sept",
            DebitAccount = "00000077",
            RegularAmount = 1000m,
            Status = StandingOrderStatus.Executing,
            CreatedOn = new DateTime(2022, 11, 3),
            Type = StandingOrderType.Type1,
            RepetitivePeriod = StandingOrderPeriodType.EveryDay,
            NoOfPayment = 10,
            
        },
        new()
        {
            Id = 2,
            TransactionType = TransactionType.Payment,
            DebitNarrative = "Paid Invoice Alley Deli",
            DebitAccount = "10023002",
            RegularAmount = 1400m,
            Status = StandingOrderStatus.Executing,
            CreatedOn = new DateTime(2022, 4, 12),
            Type = StandingOrderType.Type2
        },
        new()
        {
            Id = 3,
            TransactionType = TransactionType.Transfer,
            DebitNarrative = "Paid Invoice #5643 for Sept",
            DebitAccount = "00000075",
            RegularAmount = 9000m,
            Status = StandingOrderStatus.Paused,
            CreatedOn = new DateTime(2022, 1, 20),
            Type = StandingOrderType.Type3
        },
        new()
        {
            Id = 4,
            TransactionType = TransactionType.Transfer,
            DebitNarrative = "Paid For Shopping",
            DebitAccount = "00002001",
            RegularAmount = 95000m,
            Status = StandingOrderStatus.Paused,
            CreatedOn = new DateTime(2022, 1, 7),
            Type = StandingOrderType.Type4
        },
        new()
        {
            Id = 5,
            TransactionType = TransactionType.Payment,
            DebitNarrative = "Paid Invoice #5646 for Dec",
            DebitAccount = "00002001",
            RegularAmount = 23000m,
            Status = StandingOrderStatus.Finished,
            CreatedOn = new DateTime(2022, 7, 30),
            Type = StandingOrderType.Type5
        },
        new()
        {
            Id = 6,
            TransactionType = TransactionType.Transfer,
            DebitNarrative = "Paid Invoice #5646 for Dec",
            DebitAccount = "00002001",
            RegularAmount = 23000m,
            Status = StandingOrderStatus.Finished,
            CreatedOn = new DateTime(2022, 7, 30),
            Type = StandingOrderType.Type3
        },
    };
}