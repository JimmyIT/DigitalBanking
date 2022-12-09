using IFS.DB.WebApp.Models.Batch;
using IFS.DB.WebApp.Models.PayeeTemplate;
using IFS.DB.WebApp.Models.SigningQueue;

namespace IFS.DB.WebApp.Services
{
    public class AppStore
    {
        public PayeeTemplateModel? PayeeTemplateStore { get; set; }
        
        public BatchModel? BatchStore { get; set; }
        
        public PaymentQueueModel? PaymentQueueStore { get; set; }
    }
}