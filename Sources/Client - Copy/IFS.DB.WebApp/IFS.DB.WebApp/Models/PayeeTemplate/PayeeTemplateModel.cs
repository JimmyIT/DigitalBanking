using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Models.PayeeTemplate;

public record PayeeTemplateModel
{
    public int ID { get; set; }
    public PaymentTypeEnum PaymentTemplateType { get; set; }
    public string DebitAccount { get; set; }
    public PaymentMethodEnum? PaymentMethod { get; set; }
    public string ClientNumber { get; set; }
    public string HostReference { get; set; }
    public string DebitNarrative { get; set; }
    public string CreditCurrency { get; set; }
    public string BeneficiaryReference { get; set; }
    public string iBankReference { get; set; }
    public string PaymentTemplateDetails { get; set; }
    public string BeneficiaryName { get; set; }
    public string BeneficiaryAccountNumber { get; set; }
    public bool Pinned { get; set; }
    public DateTime? CreatedDate { get; set; }
    
}
