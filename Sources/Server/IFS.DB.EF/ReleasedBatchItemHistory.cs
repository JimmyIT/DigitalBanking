using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ReleasedBatchItemHistory
    {
        public int BatchItemId { get; set; }
        public string IBankReference { get; set; } = null!;
        public int BatchId { get; set; }
        public string CreditType { get; set; } = null!;
        public string CreditAccount { get; set; } = null!;
        public bool? OwnAccount { get; set; }
        public int? PaymentTemplateId { get; set; }
        public string? BeneficiaryReference { get; set; }
        public string? CreditNarrative { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public bool? FreeFormatFlag { get; set; }
        public string? ClearingCode { get; set; }
        public string? Beneficiary { get; set; }
        public int? PaymentTypeId { get; set; }
        public string? DebitNarrative { get; set; }

        public virtual ReleasedBatchHeaderHistory Batch { get; set; } = null!;
        public virtual PaymentTemplate? PaymentTemplate { get; set; }
        public virtual PaymentType? PaymentType { get; set; }
    }
}
