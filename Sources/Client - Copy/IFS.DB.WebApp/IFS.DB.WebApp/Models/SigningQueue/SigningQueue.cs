using System.ComponentModel;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IFS.DB.WebApp.Models.SigningQueue;

public interface ISigningQueue
{
    int TotalSignOff { get; }
    int AwaitingSignOff { get; }
}

public record SigningQueueModel : ISigningQueue
{
    public ProductTypeQueue ProductType { get; set; }
    public int TotalSignOff { get; set; }
    public int AwaitingSignOff { get; set; }
}

public record PaymentQueueModel : ISigningQueue
{
    public int Id { get; set; }
    public string? TemplateReference { get; set; }
    public string? DefaultAccount { get; set; }

    public string? SortCode { get; set; }
    public string? AccountName { get; set; }
    public string? AccountNumber { get; set; }
    public string? PayeeReference { get; set; }

    public string? DebitAccount { get; set; }
    public string? UserReference { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? DebitNarrative { get; set; }

    public string? DefaultCreditNarrative { get; set; }

    public UserInfoBrief? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    
    public ICollection<string>? AttachedFiles { get; set; }

    public int TotalSignOff { get; set; }
    public int AwaitingSignOff { get; set; }
    
    public bool CanSign { get; set; }

    public IList<SignatoryModel> Signatories { get; set; } = new List<SignatoryModel>();
}

public record UserInfoBrief
{
    public string? Name { get; set; }
    public string? AvatarUrl { get; set; }
}

public record SignatoryModel : UserInfoBrief
{
    public DateTime SignedDate { get; set; }
}

public enum ProductTypeQueue
{
    [Description("Payment")] Payment = 1,
    [Description("Payee template")] PayeeTemplate,
    [Description("Transfer")] Transfer,
    [Description("Batch")] Batch
}