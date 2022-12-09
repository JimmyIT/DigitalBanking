using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.ChartOfAccounts.GetOnlineCOAByEntityTypeIdForNewApp
{
    public class GetOnlineCOAByEntityTypeIdForNewAppResponse
    {
        public int OnlineChartOfAccountId { get; set; }
        public string EntityTypeId { get; set; }
        public string FriendlyName { get; set; }
        public string ChartOfAccount { get; set; }
        public string Description { get; set; }
        public bool LinkedAccountNeeded { get; set; }
    }
}
