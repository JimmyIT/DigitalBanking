using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Account
    {
        public Account()
        {
            Statements = new HashSet<Statement>();
        }

        public string AccountNumber { get; set; } = null!;
        public string AccountDescription { get; set; } = null!;
        public string ClientNumber { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public decimal CurrentBalance { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal? OverdraftLimit { get; set; }
        public DateTime? OverdraftExpiry { get; set; }
        public DateTime? StatementDue { get; set; }
        public DateTime? LastStatement { get; set; }
        public decimal LastBalance { get; set; }
        public string? StatementFrequency { get; set; }
        public int? StatementFixDay { get; set; }
        public short? StatementLastPage { get; set; }
        public DateTime? InterestDebitDate { get; set; }
        public string? InterestDebitFrequency { get; set; }
        public int? InterestDebitFixDay { get; set; }
        public DateTime? InterestCreditDate { get; set; }
        public string? InterestCreditFrequency { get; set; }
        public int? InterestCreditFixDay { get; set; }
        public DateTime? LastMovementDate { get; set; }
        public decimal? AverageBalance { get; set; }
        public decimal? HighestDebit { get; set; }
        public decimal? HighestCredit { get; set; }
        public DateTime? OpenDate { get; set; }
        public decimal? SodcurrentBalance { get; set; }
        public decimal? SodavailableBalance { get; set; }
        public DateTime? EarliestDate { get; set; }
        public string? PermittedActions { get; set; }
        public decimal? ActualBalance { get; set; }
        public string? VoucherId { get; set; }
        public DateTime? OverdraftReview { get; set; }
        public string? StatementFrequencyPeriod { get; set; }
        public string? InterestDebitFrequencyPeriod { get; set; }
        public string? InterestCreditFrequencyPeriod { get; set; }

        public virtual Client ClientNumberNavigation { get; set; } = null!;
        public virtual Currency CurrencyCodeNavigation { get; set; } = null!;
        public virtual ICollection<Statement> Statements { get; set; }
    }
}
