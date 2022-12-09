using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class LicenceDetail
    {
        public string Lna { get; set; } = null!;
        public string ExpiryDate { get; set; } = null!;
        public string BanksName { get; set; } = null!;
        public string CipherCode { get; set; } = null!;
    }
}
