using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ClientAlias
    {
        public string ClientId { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string MobilePhoneNo { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
    }
}
