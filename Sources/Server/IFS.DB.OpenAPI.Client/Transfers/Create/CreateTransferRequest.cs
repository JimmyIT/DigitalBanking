using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Client.Transfers.Create
{
    public class CreateTransferRequest
    {
        public string CreditCurrency { get; set; }
        public decimal CreditAmount { get; set; }
        public string CreditAccount { get; set; }
        public string CreditNarrative { get; set; }
        public bool? OwnAccount { get; set; }
        public string DebitAccount { get; set; }
        public string DebitNarrative { get; set; }
        public string ClientNumber { get; set; }
        public string LogonID { get; set; }
        public string iBankReference { get; set; }
        public DateTime ValueDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsFromMBank { get; set; }
    }
}
