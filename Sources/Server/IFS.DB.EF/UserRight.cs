using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class UserRight
    {
        public string? ClientId { get; set; }
        public string? GroupId { get; set; }
        public string? InternalId { get; set; }
        public string ProductId { get; set; } = null!;
        public string? AccountId { get; set; }
        public bool ViewingAllowed { get; set; }
        public double? MaximumEntry { get; set; }
        public bool UnlimitedEntry { get; set; }
        public double? MaximumSigning { get; set; }
        public bool UnlimitedSigning { get; set; }
        public bool SignOwn { get; set; }
        public double? MaximumVerification { get; set; }
        public bool? UnlimitedVerification { get; set; }
        public bool? VerifyOwn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public bool? XviewingAllowed { get; set; }
        public double? XmaximumEntry { get; set; }
        public bool? XunlimitedEntry { get; set; }
        public double? XmaximumSigning { get; set; }
        public bool? XunlimitedSigning { get; set; }
        public bool? XsignOwn { get; set; }
        public double? XmaximumVerification { get; set; }
        public bool? XunlimitedVerification { get; set; }
        public bool? XverifyOwn { get; set; }
        public int? Status { get; set; }
        public int UserRightsId { get; set; }
    }
}
