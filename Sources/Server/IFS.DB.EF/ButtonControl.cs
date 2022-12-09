using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ButtonControl
    {
        public int? RecordType { get; set; }
        public string? ClientId { get; set; }
        public string? GroupId { get; set; }
        public string? InternalId { get; set; }
        public int? Level1ItemId { get; set; }
        public int? Level2ItemId { get; set; }
        public int? Level3ItemId { get; set; }
        public int? DictionaryId { get; set; }
        public bool Visible { get; set; }
        public int ButtonControlId { get; set; }
    }
}
