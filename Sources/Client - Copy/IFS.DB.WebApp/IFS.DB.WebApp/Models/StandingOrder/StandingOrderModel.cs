using System.ComponentModel;
using FluentValidation;
using IFS.DB.WebApp.Helpers.Enums;
using Microsoft.Extensions.Localization;

namespace IFS.DB.WebApp.Models.StandingOrder;

public record StandingOrderModel
{
    public int Id { get; set; }
    public StandingOrderType Type { get; set; }
    public string? DebitNarrative { get; set; }
    public string? DebitAccount { get; set; }
    public decimal? FirstAmount { get; set; }
    public decimal? RegularAmount { get; set; }
    public decimal? LastAmount { get; set; }
    public StandingOrderPeriodType? RepetitivePeriod { get; set; }
    public DateTime? PaymentDay { get; set; }
    public DateTime? LastPaymentDay { get; set; }
    public bool IsLastDayOfMonth { get; set; }
    public int NoOfPayment { get; set; }
    public TransactionType? TransactionType { get; set; }
    public string? TransferTo { get; set; }
    public string? PayeeReference { get; set; }
    public StandingOrderStatus Status { get; set; }

    public DateTime CreatedOn { get; set; }
}

public class StandingOrderModelValidator : AbstractValidator<StandingOrderModel>
{
    public StandingOrderModelValidator(IStringLocalizer<StandingOrderModelValidator> _)
    {
        RuleFor(x => x.DebitNarrative)
            .NotEmpty()
            .WithMessage("Required");

        RuleFor(x => x.DebitAccount)
            .NotNull()
            .WithMessage("Required");

        RuleFor(x => x.RegularAmount)
            .NotNull()
            .WithMessage("Required")
            .GreaterThan(0.01m)
            .LessThan(999999999m);

        When(x => DifferingFistLast(x),
            () =>
            {
                RuleFor(x => x.FirstAmount)
                    .NotNull()
                    .WithMessage("Required")
                    .GreaterThan(0.01m)
                    .LessThan(999999999m);

                RuleFor(x => x.LastAmount)
                    .NotNull()
                    .WithMessage("Required")
                    .GreaterThan(0.01m)
                    .LessThan(999999999m);
            });

        RuleFor(x => x.RepetitivePeriod)
            .NotNull()
            .WithMessage("Required");

        RuleFor(x => x.PaymentDay)
            .NotNull()
            .WithMessage("Required")
            .GreaterThan(DateTime.Today.AddDays(-1))
            .WithMessage("Payment could not be in the past")
            .When(x => x.RepetitivePeriod is StandingOrderPeriodType.EveryMonth or StandingOrderPeriodType.EveryYear);

        When(x => x.Type is StandingOrderType.Type2 or StandingOrderType.Type5, () =>
        {
            RuleFor(x => x.LastPaymentDay)
                .NotNull()
                .WithMessage("Required")
                .GreaterThan(DateTime.Today.AddDays(-1))
                .WithMessage("Payment could not be in the past");

            When(x => x.RepetitivePeriod is StandingOrderPeriodType.EveryMonth or StandingOrderPeriodType.EveryYear,
                () =>
                {
                    RuleFor(x => x.LastPaymentDay).GreaterThanOrEqualTo(x => x.PaymentDay)
                        .WithMessage("Last payment day must be greater than payment day");
                });

            When(x => x.RepetitivePeriod is StandingOrderPeriodType.EveryWeek, () =>
            {
                RuleFor(x => x.LastPaymentDay).GreaterThanOrEqualTo(x => x.PaymentDay)
                    .WithMessage("Last payment day must be greater than payment day");
            });
        });


        RuleFor(x => x.NoOfPayment)
            .GreaterThan(0)
            .WithMessage("Required")
            .When(x => x.Type is StandingOrderType.Type1 or StandingOrderType.Type4);


        RuleFor(x => x.TransactionType)
            .NotNull()
            .WithMessage("Required");

        When(x => x.TransactionType == TransactionType.Transfer, () =>
        {
            RuleFor(x => x.TransferTo)
                .NotNull()
                .WithMessage("Required");
        });

        When(x => x.TransactionType == TransactionType.Payment, () =>
        {
            RuleFor(x => x.PayeeReference)
                .NotNull()
                .WithMessage("Required");
        });
    }

    public static Func<StandingOrderModel, bool> DifferingFistLast => model =>
        new List<StandingOrderType> { StandingOrderType.Type4, StandingOrderType.Type5 }.Contains(model.Type);

    public static List<DateTime> CalculateDayOfWeeksBaseOnCurrentDate()
    {
        DateTime currentDate = DateTime.Now;
        DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;
        var listDateWeek = new List<DateTime>();
        
        for (var i = 0; i <= 6; i++)
        {
            listDateWeek.Add(currentDate.AddDays(i - (int)currentDayOfWeek + (i < (int)currentDayOfWeek ? 7 : 0)).Date);
        }

        return listDateWeek;
    }
}

public enum StandingOrderType
{
    [Description("Fixed amounts and fixed number of payments")]
    Type1 = 1,

    [Description("Fixed amounts with an end date")]
    Type2,

    [Description("Fixed amounts until cancelled")]
    Type3,

    [Description("Differing First/Last amounts with fixed number of payments")]
    Type4,

    [Description("Differing First/Last amounts with end dates")]
    Type5
}

public enum StandingOrderPeriodType
{
    [Description("Every day")] EveryDay = 1,
    [Description("Every week")] EveryWeek,
    [Description("Every month")] EveryMonth,
    [Description("Every year")] EveryYear
}

public enum StandingOrderStatus
{
    Paused = 1,
    Executing,
    Finished
}