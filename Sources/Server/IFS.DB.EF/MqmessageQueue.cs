using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class MqmessageQueue
    {
        public int QueueId { get; set; }
        public int MessageId { get; set; }
        public int Status { get; set; }
        public byte? RetryCount { get; set; }
        public string? ErrorDesc { get; set; }
        public bool? ErrorNotified { get; set; }
        public byte[] Cctimestamp { get; set; } = null!;

        public virtual Mqmessage Message { get; set; } = null!;
    }
}
