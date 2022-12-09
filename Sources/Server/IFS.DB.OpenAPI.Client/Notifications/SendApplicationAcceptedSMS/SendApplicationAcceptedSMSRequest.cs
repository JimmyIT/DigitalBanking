using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Notifications.SendApplicationAcceptedSMS
{
    public class SendApplicationAcceptedSMSRequest
    {
        public string PhoneNumber { get; set; }
        public string ApplicationId { get; set; }
        public string ClientNumber { get; set; }
    }
}
