using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Bankware.Accounts.GetByAccountNumber
{
    public class GetByAccountNumberResponse
    {
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public DateTime? AccountClosedDate { get; set; }
        public bool InternetFlag { get; set; }
        public string AlternativeAccountNumber { get; set; }
        public decimal? AvailableBalance { get; set; }
        public decimal? AverageBalance { get; set; }
        public string BlockReason { get; set; }
        public string BlockType { get; set; }
        public string ChartOfAccount { get; set; }
        public decimal? ClearedBalance { get; set; }
        public string ClientNumber { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? CurrentBalance { get; set; }
        public string DormantActiveFlag { get; set; }
        public DateTime? EarliestDate { get; set; }
        public string ExcludeFromS17 { get; set; }
        public string FidDepFeeAccount { get; set; }
        public decimal? FidDepFeeAccrual { get; set; }
        public string FollowsInterestDefaults { get; set; }
        public string FollowsStatementDefaults { get; set; }
        public string FullName { get; set; }
        public decimal? HighestCredit { get; set; }
        public decimal? HighestDebit { get; set; }
        public DateTime? HistoricalLastStatementDate { get; set; }
        public decimal? HistoricalStatementBroughtForwardBalance { get; set; }
        public DateTime? InterestCreditDate { get; set; }
        public int? InterestCreditFixDay { get; set; }
        public string InterestCreditFrequency { get; set; }
        public string InterestCreditFrequencyPeriod { get; set; }
        public DateTime? InterestDebitDate { get; set; }
        public int? InterestDebitFixDay { get; set; }
        public string InterestDebitFrequency { get; set; }
        public string InterestDebitFrequencyPeriod { get; set; }
        public decimal? LastBalance { get; set; }
        public DateTime? LastFDFeeAccrualDate { get; set; }
        public DateTime? LastMovementDate { get; set; }
        public DateTime? LastStatement { get; set; }
        public DateTime? OpenDate { get; set; }
        public decimal? OriginalBroughtForwardBalance { get; set; }
        public DateTime? OverdraftExpiry { get; set; }
        public decimal? OverdraftLimit { get; set; }
        public string R105Indicator { get; set; }
        public string R85Indicator { get; set; }
        public string ReportName { get; set; }
        public decimal? SignatoryLevel1Amount { get; set; }
        public int? SignatoryLevel1NumberOfSignatures { get; set; }
        public decimal? SignatoryLevel2Amount { get; set; }
        public int? SignatoryLevel2NumberOfSignatures { get; set; }
        public int? SignatoryLevel3NumberOfSignatures { get; set; }
        public decimal? SodAvailableBalance { get; set; }
        public decimal? SodCurrentBalance { get; set; }
        public DateTime? StatementDue { get; set; }
        public int? StatementFixDay { get; set; }
        public string StatementFrequency { get; set; }
        public string StatementFrequencyPeriod { get; set; }
        public short? StatementLastPage { get; set; }
        public decimal? ThisPeriodCRIntAdjustment { get; set; }
        public decimal? ThisPeriodDRIntAdjustment { get; set; }
        public decimal? ThisPeriodTaxAdjustment { get; set; }
        public string IBAN { get; set; }
    }
}
