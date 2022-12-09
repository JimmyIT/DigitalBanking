using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Notifications.SendApplicationAcceptedEmail
{
    public class SendApplicationAcceptedEmailRequest
    {
        public string Email { get; set; }
        public string ApplicationId { get; set; }
        public string ClientNumber { get; set; }
    }
}
