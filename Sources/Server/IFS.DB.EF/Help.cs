using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Help
    {
        public int HelpId { get; set; }
        public string? Page { get; set; }
        public string? OptionName { get; set; }
        public string? SubOption { get; set; }
        public string? Description { get; set; }
        public string? Value1 { get; set; }
        public string? Consequence1 { get; set; }
        public string? Value2 { get; set; }
        public string? Consequence2 { get; set; }
        public string? Value3 { get; set; }
        public string? Consequence3 { get; set; }
        public string? Value4 { get; set; }
        public string? Consequence4 { get; set; }
        public string? Value5 { get; set; }
        public string? Consequence5 { get; set; }
        public string? Value6 { get; set; }
        public string? Consequence6 { get; set; }
        public string? Value7 { get; set; }
        public string? Consequence7 { get; set; }
        public string? Value8 { get; set; }
        public string? Consequence8 { get; set; }
        public string? Value9 { get; set; }
        public string? Consequence9 { get; set; }
        public string? Value10 { get; set; }
        public string? Consequence10 { get; set; }
        public string? AdditionalNotes { get; set; }
        public byte[] MsreplSynctranTs { get; set; } = null!;
    }
}
