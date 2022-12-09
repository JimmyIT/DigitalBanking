using IFS.DB.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Messages.UpdateStatus
{
    public class UpdateMessageStatusRequest
    {
        public int MessageId { get; set; }
        public MQMessageStatusEnum Status { get; set; }
        public string Note { get; set; }
        public string ErrorMessage { get; set; }
    }
}
