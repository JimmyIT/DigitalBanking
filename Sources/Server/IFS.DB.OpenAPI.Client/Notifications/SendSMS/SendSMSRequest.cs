using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Notifications.SendSMS
{
    public class SendSMSRequest
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
