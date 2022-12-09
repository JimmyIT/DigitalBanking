using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.API
{
    public class APIMessage
    {
        public int MessageId { get; set; }
        public string MessageCode { get; set; } = null!;
        public string? IdempotencyKey { get; set; }
        public string? AccountNumber { get; set; }
        public string? ClientNumber { get; set; }
        public string? AdditionalInfo1 { get; set; }
        public string? AdditionalInfo2 { get; set; }
        public string Url { get; set; } = null!;
        public string Header { get; set; } = null!;
        public string RequestMessage { get; set; } = null!;
        public string? ResponseMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
