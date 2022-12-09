using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Bankware.ChartOfAccounts.GetCurrenciesByOnlineCOA
{
    public class GetCurrenciesByOnlineCOAResponse
    {
        public int RecordId { get; set; }
        public int OnlineChartOfAcccountId { get; set; }
        public string Currency { get; set; }
    }
}
