using IFS.DB.OpenAPI.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Messages.UpdateStatus
{
    public class UpdateMessageStatusRequest
    {
        public int MessageId { get; set; }
        public MQMessageStatusEnum Status { get; set; }
        public string Note { get; set; }
        public string ErrorMessage { get; set; }
    }
}
