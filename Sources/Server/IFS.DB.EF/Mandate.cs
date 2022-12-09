using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Mandate
    {
        public int? RecordType { get; set; }
        public string? ClientId { get; set; }
        public string? ProductId { get; set; }
        public string? AccountId { get; set; }
        public double? Value1 { get; set; }
        public int? NumberofSignatures1 { get; set; }
        public double? Value2 { get; set; }
        public int? NumberofSignatures2 { get; set; }
        public double? Value3 { get; set; }
        public int? NumberofSignatures3 { get; set; }
        public double? Value4 { get; set; }
        public int? NumberofSignatures4 { get; set; }
        public double? Value5 { get; set; }
        public int? NumberofSignatures5 { get; set; }
        public double? Value6 { get; set; }
        public int? NumberofSignatures6 { get; set; }
        public double? Value7 { get; set; }
        public int? NumberofSignatures7 { get; set; }
        public double? Value8 { get; set; }
        public int? NumberofSignatures8 { get; set; }
        public double? Value9 { get; set; }
        public int? NumberofSignatures9 { get; set; }
        public double? Value10 { get; set; }
        public int? NumberofSignatures10 { get; set; }
        public bool AdvisebyiMail1 { get; set; }
        public bool AdvisebyEmail1 { get; set; }
        public string? SendAdviceTo1 { get; set; }
        public bool AdvisebyiMail2 { get; set; }
        public bool AdvisebyEmail2 { get; set; }
        public string? SendAdviceTo2 { get; set; }
        public bool AdvisebyiMail3 { get; set; }
        public bool AdvisebyEmail3 { get; set; }
        public string? SendAdviceTo3 { get; set; }
        public bool AdvisebyiMail4 { get; set; }
        public bool AdvisebyEmail4 { get; set; }
        public string? SendAdviceTo4 { get; set; }
        public bool AdvisebyiMail5 { get; set; }
        public bool AdvisebyEmail5 { get; set; }
        public string? SendAdviceTo5 { get; set; }
        public float? MaximumTransactionAmount { get; set; }
        public int MandateId { get; set; }
    }
}
