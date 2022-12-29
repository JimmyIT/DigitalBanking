using IFS.DB.WebApp.Models.Batch;
using IFS.DB.WebApp.Models.PayeeTemplate;
using IFS.DB.WebApp.Models.SigningQueue;
using IFS.DB.WebApp.Models.StandingOrder;

namespace IFS.DB.WebApp.Services
{
    public class AppStore
    {
        public PayeeTemplateModel? PayeeTemplateStore { get; set; }
        
        public BatchModel? BatchStore { get; set; }
        
        public CommonQueueModel? CommonSigningQueueStore { get; set; }
        
        public StandingOrderModel? StandingOrderStore { get; set; }
    }
}