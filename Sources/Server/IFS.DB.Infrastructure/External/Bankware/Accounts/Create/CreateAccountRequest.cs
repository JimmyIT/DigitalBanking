using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.Bankware.Accounts.Create
{
    public class CreateAccountRequest
    {
        public string AccountNumber { get; set; }
        public string AltAccountNumber { get; set; }
        public string Currency { get; set; }
        public string ChartOfAccount { get; set; }
        public string ClientNumber { get; set; }
        public string AltClientNumber { get; set; }
        public string AccountDescription { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal ClearedBalance { get; set; }
        public string StatementFrequency { get; set; }
        public string FixedDayOfStatement { get; set; }
        public string OverdraftLimit { get; set; }
        public string OverdraftExpiry { get; set; }
        public string OpenDate { get; set; }
        public string StatementDueDate { get; set; }
        public string LastStatementDate { get; set; }
        public string InternetAccessRequired { get; set; }
        public string BlockStatus { get; set; }
        public string DebitInterestAccount { get; set; }
        public string CreditInterestAccount { get; set; }
        public string TemplateCustomerNumber { get; set; }
        public string Sequence { get; set; }
    }
}
