using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendApplicationAcceptedEmail
{
    public class SendApplicationAcceptedEmailRequest
    {
        public string Email { get; set; }
        public string ApplicationId { get; set; }
        public string ClientNumber { get; set; }
    }
}
