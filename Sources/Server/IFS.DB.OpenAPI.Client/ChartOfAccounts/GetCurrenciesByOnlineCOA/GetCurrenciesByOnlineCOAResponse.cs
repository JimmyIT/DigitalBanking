using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.ChartOfAccounts.GetCurrenciesByOnlineCOA
{
    public class GetCurrenciesByOnlineCOAResponse
    {
        public int RecordId { get; set; }
        public int OnlineChartOfAcccountId { get; set; }
        public string Currency { get; set; }
    }
}
