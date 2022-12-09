using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class IMailBox
    {
        public IMailBox()
        {
            IMailAttachmentMailMessageReceiveds = new HashSet<IMailAttachment>();
            IMailAttachmentMailMessageSents = new HashSet<IMailAttachment>();
        }

        public int MailMessageId { get; set; }
        public string? RequestReference { get; set; }
        public string CustomersReference { get; set; } = null!;
        public string? ClientNumber { get; set; }
        public int? NumberofAuthorisationAttempts { get; set; }
        public string Status { get; set; } = null!;
        public string InternalId { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime Date { get; set; }
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool Read { get; set; }
        public bool RepliedTo { get; set; }
        public bool Deleted { get; set; }
        public int LinkedMessageId { get; set; }
        public bool? ReplyPermitted { get; set; }

        public virtual ICollection<IMailAttachment> IMailAttachmentMailMessageReceiveds { get; set; }
        public virtual ICollection<IMailAttachment> IMailAttachmentMailMessageSents { get; set; }
    }
}
