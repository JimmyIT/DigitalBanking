using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Lcrequest
    {
        public string RequestReference { get; set; } = null!;
        public DateTime DateReceived { get; set; }
        public string ClientNumber { get; set; } = null!;
        public int NumberofAuthorisationAttempts { get; set; }
        public bool? Validated { get; set; }
        public string Status { get; set; } = null!;
        public string EntryLogonId { get; set; } = null!;
        public string EntryUserId { get; set; } = null!;
        public string? EntryVerifiedLogonId { get; set; }
        public string? EntryVerifiedUserId { get; set; }
        public string? AmendmentLogonId { get; set; }
        public string? AmendmentUserId { get; set; }
        public string? AmendmentVerifiedLogonId { get; set; }
        public string? AmendmentVerifiedUserId { get; set; }
        public string? DeletionLogonId { get; set; }
        public string? DeletionUserId { get; set; }
        public string? DeletionVerifiedLogonId { get; set; }
        public string? DeletionVerifiedUserId { get; set; }
        public string? T2701 { get; set; }
        public string? T40A01 { get; set; }
        public string? T2001 { get; set; }
        public string? T2301 { get; set; }
        public string? T31C01 { get; set; }
        public string? T31D0101 { get; set; }
        public string? T51A01 { get; set; }
        public string? T51D01 { get; set; }
        public string? T5001 { get; set; }
        public string? T5901 { get; set; }
        public string? T32B0101 { get; set; }
        public string? T32B0102 { get; set; }
        public string? T39A01 { get; set; }
        public string? T39B01 { get; set; }
        public string? T39C01 { get; set; }
        public string? T41A01 { get; set; }
        public string? T41D01 { get; set; }
        public string? T42C01 { get; set; }
        public string? T42A01 { get; set; }
        public string? T42D01 { get; set; }
        public string? T42M01 { get; set; }
        public string? T42P01 { get; set; }
        public string? T43P01 { get; set; }
        public string? T43T01 { get; set; }
        public string? T44A01 { get; set; }
        public string? T44B01 { get; set; }
        public string? T44C01 { get; set; }
        public string? T44D01 { get; set; }
        public string? T45A01 { get; set; }
        public string? T46A01 { get; set; }
        public string? T47A01 { get; set; }
        public string? T71B01 { get; set; }
        public string? T4801 { get; set; }
        public string? T4901 { get; set; }
        public string? T53A01 { get; set; }
        public string? T53D01 { get; set; }
        public string? T7801 { get; set; }
        public string? T57A01 { get; set; }
        public string? T57B01 { get; set; }
        public string? T57D01 { get; set; }
        public string? T7201 { get; set; }
        public string? T31D0102 { get; set; }
    }
}
