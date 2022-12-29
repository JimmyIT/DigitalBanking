using System.ComponentModel;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Batch;
using IFS.DB.WebApp.Models.Users;

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

public record CommonQueueModel : ISigningQueue
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public ProductTypeQueue ProductType { get; set; }
    public string? Reference { get; set; }
    public string? DebitAccount { get; set; }
    public UserInfoBrief? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int TotalSignOff { get; set; }
    public int AwaitingSignOff { get; set; }
    public bool CanSign { get; set; }
    public IList<SignatoryModel> Signatories { get; set; } = new List<SignatoryModel>();
}

//DELETE ME
public record _PaymentQueueModel
{
    public int Id { get; set; }
    public string? TemplateReference { get; set; }
    public string? DefaultAccount { get; set; }
    public string? SortCode { get; set; }
    public string? AccountName { get; set; }
    public string? AccountNumber { get; set; }
    public string? PayeeReference { get; set; }
    public string? DebitAccount { get; set; }
    public decimal CreditAmount { get; set; }
    public string? UserReference { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? DebitNarrative { get; set; }
    public string? DefaultCreditNarrative { get; set; }

    public ICollection<string>? AttachedFiles { get; set; }
}

//DELETE ME
public record _TransferQueueModel
{
    public int Id { get; set; }
    public string? DebitAccount { get; set; }
    public string? CreditAccount { get; set; }
    public decimal? Amount { get; set; }
    public DateTime?TransferDate { get; set; } = DateTime.Now;
    public string? DebitNarrative { get; set; }
    public string? CreditNarrative { get; set; }
}

//DELETE ME
public record _PayeeQueueModel
{
    public int Id { get; set; }
    public PaymentTypeEnum PaymentTemplateType { get; set; }
    public string? DebitAccount { get; set; }
    public PaymentMethodEnum? PaymentMethod { get; set; }
    public string? ClientNumber { get; set; }
    public string? HostReference { get; set; }
    public string? DebitNarrative { get; set; }
    public string? CreditCurrency { get; set; }
    public string? BeneficiaryReference { get; set; }
    public string? iBankReference { get; set; }
    public string? PaymentTemplateDetails { get; set; }
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryAccountNumber { get; set; }
    public bool Pinned { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? BankName { get; set; }
    public int SortCode { get; set; }
}

//DELETE ME
public record _BatchQueueModel
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
    
    public ICollection<BatchItemModel>? BatchItems { get; set; }
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