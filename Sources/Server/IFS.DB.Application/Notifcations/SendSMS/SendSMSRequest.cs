using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendSMS
{
    public class SendSMSRequest
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
