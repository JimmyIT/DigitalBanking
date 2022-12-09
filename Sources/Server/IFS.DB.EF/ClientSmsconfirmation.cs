using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ClientSmsconfirmation
    {
        public string ClientId { get; set; } = null!;
        public string Smscode { get; set; } = null!;
        public bool? ConfirmationRequired { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
