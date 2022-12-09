using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class BatchItem
    {
        public int BatchItemId { get; set; }
        public int BatchId { get; set; }
        public string CreditType { get; set; } = null!;
        public string? CreditAccount { get; set; }
        public bool? OwnAccount { get; set; }
        public int? PaymentTemplateId { get; set; }
        public string? Beneficiary { get; set; }
        public string? BeneficiaryReference { get; set; }
        public string CreditNarrative { get; set; } = null!;
        public decimal CreditAmount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public int? PaymentTypeId { get; set; }
        public DateTime CreateOn { get; set; }
        public string CreateBy { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;
        public string? DebitNarrative { get; set; }

        public virtual BatchHeader Batch { get; set; } = null!;
        public virtual PaymentTemplate? PaymentTemplate { get; set; }
        public virtual PaymentType? PaymentType { get; set; }
    }
}
