using FluentValidation;

namespace IFS.DB.WebApp.Models.Security;

public record MseAuthorityCodeModel
{
    public string? AuthorityCode { get; set; }
    public string? AuthorityCodeConfirm { get; set; }
    public DateTime? LastAccessOn { get; set; }
    public DateTime? ConfirmOn { get; set; }
    public MseAuthorityCodeStatus? Status { get; set; }
}

public class MseAuthorityCodeModelValidator : AbstractValidator<MseAuthorityCodeModel>
{
    public MseAuthorityCodeModelValidator()
    {
        RuleFor(x => x.AuthorityCode)
            .NotEmpty()
            .WithMessage("Required");

        RuleFor(x => x.AuthorityCodeConfirm)
            .NotEmpty().WithMessage("Required")
            .Equal(x => x.AuthorityCode)
            .WithMessage("Confirm code does not matched");
    }
}


public record PasswordBatchModel
{
    public int Id { get; set; }
    public string? UserReference { get; set; }
    public PasswordBatchStatus? Status { get; set; }
    public string? LassAccessBy { get; set; }
    public DateTime? LastProcessOn { get; set; }
}


public enum MseAuthorityCodeStatus
{
    WaitingReview,
    WaitingNotify
}

public enum PasswordBatchStatus
{
    Locked = 1,
    Unlocked
}