using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Notifications.SendMail
{
    public class SendMailRequest
    {
        public string Subject { get; set; }
        public string Recipients { get; set; }
        public string Message { get; set; }
    }
}
