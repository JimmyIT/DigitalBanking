using FluentValidation;
using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.Batch;

public record BatchModel
{
    public int Id { get; set; }
    public string? UserReference { get; set; }
    public string? DebitAccount { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? DebitNarrative { get; set; }
    public string? DefaultCreditNarrative { get; set; }
    public BatchStatus Status { get; set; }
    public int RequiredSignatures { get; set; }
    public int CurrentSignatures { get; set; }
    public DateTime SubmittedDate { get; set; }
    
    public bool CanSign { get; set; }
    
    public ICollection<BatchItemModel>? BatchItems { get; set; }
}

public class BatchModelValidator : AbstractValidator<BatchModel>
{
    public BatchModelValidator()
    {
        RuleFor(x => x.UserReference)
            .NotEmpty()
            .WithMessage("Required");
        
        RuleFor(x => x.DebitAccount)
            .NotEmpty()
            .WithMessage("Required");
        
        RuleFor(x => x.Amount)
            .NotNull()
            .WithMessage("Required")
            .GreaterThan(0.01m)
            .LessThan(999999999m);

        RuleFor(x => x.PaymentDate)
            .NotNull()
            .WithMessage("Required")
            .GreaterThan(DateTime.Today.AddDays(-1))
            .WithMessage("Payment could not be in the past");
        
        RuleFor(x => x.DebitNarrative)
            .NotEmpty()
            .WithMessage("Required");
        
        RuleFor(x => x.DefaultCreditNarrative)
            .NotEmpty()
            .WithMessage("Required");
    }
}

public record BatchItemModel
{
    public int Id { get; set; }
    public int BatchId { get; set; }
    public TransactionType TransactionType { get; set; }
    public string? CreditAccount { get; set; }
    public decimal? Amount { get; set; }
    public string? CreditNarrative { get; set; }
}

public class BatchItemModelValidator : AbstractValidator<BatchItemModel>
{
    public BatchItemModelValidator()
    {
        RuleFor(x => x.TransactionType)
            .NotEmpty()
            .WithMessage("Required");
        
        RuleFor(x => x.CreditAccount)
            .NotEmpty()
            .WithMessage("Required");
        
        RuleFor(x => x.Amount)
            .NotNull()
            .WithMessage("Required")
            .GreaterThan(0.01m)
            .LessThan(999999999m);
        
    }
}

public enum BatchStatus
{
    Draft = 1,
    Waiting,
    Submitted
}