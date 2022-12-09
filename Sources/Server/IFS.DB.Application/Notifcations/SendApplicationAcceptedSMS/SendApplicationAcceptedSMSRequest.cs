using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendApplicationAcceptedSMS
{
    public class SendApplicationAcceptedSMSRequest
    {
        public string PhoneNumber { get; set; }
        public string ApplicationId { get; set; }
        public string ClientNumber { get; set; }
    }
}
