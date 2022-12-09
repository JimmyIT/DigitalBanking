using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class IMailAttachment
    {
        public int MailAttachmentId { get; set; }
        public int MailMessageSentId { get; set; }
        public int MailMessageReceivedId { get; set; }
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public int FileSize { get; set; }
        public byte[] FileContent { get; set; } = null!;

        public virtual IMailBox MailMessageReceived { get; set; } = null!;
        public virtual IMailBox MailMessageSent { get; set; } = null!;
    }
}
