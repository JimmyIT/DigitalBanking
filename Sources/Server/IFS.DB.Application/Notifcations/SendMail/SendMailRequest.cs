using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Notifcations.SendMail
{
    public class SendMailRequest
    {
        public string Subject { get; set; }
        public string Recipients { get; set; }
        public string Message { get; set; }
    }
}
