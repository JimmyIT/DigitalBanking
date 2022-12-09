using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Smsrule
    {
        public Smsrule()
        {
            SmsshortCodes = new HashSet<SmsshortCode>();
        }

        public string Smscode { get; set; } = null!;
        public short Priority { get; set; }
        public bool InHelp { get; set; }
        public string? ChargeAs { get; set; }
        public string? RewriteAs { get; set; }
        public bool Help { get; set; }
        public bool ResponseRequired { get; set; }
        public string? RespondAs { get; set; }
        public string? RespondTo { get; set; }
        public bool CanConfirm { get; set; }
        public string? ConfirmAs { get; set; }
        public string? ConfirmTo { get; set; }
        public string? ConfirmParameters { get; set; }
        public bool FailRequired { get; set; }
        public string? FailAs { get; set; }
        public string? FailTo { get; set; }
        public bool InitiatedByRetailler { get; set; }
        public bool InitiatedByMerchant { get; set; }
        public bool InitiatedByIntroducer { get; set; }
        public bool InitiatedByInternal { get; set; }
        public bool InitiatedByCustomer { get; set; }
        public bool? InitiatedByOperator { get; set; }
        public bool ValidBankDetails { get; set; }
        public bool ImmediateUpdate { get; set; }
        public string? FromAccountType { get; set; }
        public string? ToAccountType { get; set; }
        public string? FromAccountHolder { get; set; }
        public string? ToAccountHolder { get; set; }
        public string? TransCode { get; set; }
        public bool Rewrite { get; set; }
        public bool ListBalances { get; set; }
        public bool ListAlias { get; set; }
        public bool NewAlias { get; set; }
        public bool DeleteAlias { get; set; }
        public bool Confirmation { get; set; }
        public bool Movement { get; set; }
        public bool TopUp { get; set; }
        public bool? CrossCurrency { get; set; }

        public virtual ICollection<SmsshortCode> SmsshortCodes { get; set; }
    }
}
