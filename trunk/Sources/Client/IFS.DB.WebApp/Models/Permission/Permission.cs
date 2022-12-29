using System.Data;
using FluentValidation;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Models.Permission;

public record UserPermissionModel
{
    public int Id { get; set; }
    public UserInfoBrief? User { get; set; }
    public GroupPermissionModel? Group { get; set; }
    public bool IsFollowGroup { get; set; }
    
    public List<PermissionModel>? Permissions { get; set; }
}

public record GroupPermissionModel
{
    public int Id { get; set; }
    public string? Name { get; set; }      
    
    public List<PermissionModel>? Permissions { get; set; }
}

public record PermissionModel
{
    public AccountBriefModal Account { get; set; } = default!;
    public PermissionType Type { get; set; }
    public bool IsViewingAccount { get; set; }
    public bool IsUnlimitedDebit { get; set; }
    public decimal? MaxDebitAmount { get; set; }
    public bool IsUnlimitedSigning { get; set; }
    public decimal? MaxSigningAmount { get; set; }
    
    public bool IsAllowedToEnter { get; set; }
    public bool IsAllowedToSign { get; set; }
    public bool IsSignOwn { get; set; }
}

public class PermissionModelValidator : AbstractValidator<PermissionModel>
{
    public PermissionModelValidator()
    {
        When(x => x.IsUnlimitedDebit is false, () =>
        {
            RuleFor(x => x.MaxDebitAmount)
                .NotNull().WithMessage("Required")
                .GreaterThan(0.01m)
                .LessThan(999999999m);
        });
        
        RuleFor(x => x.MaxSigningAmount)
            .NotNull().WithMessage("Required")
            .When(x => x.IsUnlimitedSigning is false);
    }
}

public record AccountBriefModal
{
    public string? AccountNumber { get; set; }
    public string? AccountDescription { get; set; }
}

public enum PermissionType
{
    AccountViewing = 1,
    Transfer,
    Payment,
    Payee,
    BatchPayment
}