using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class Team
    {
        public Team()
        {
            AccountManagers = new HashSet<AccountManager>();
        }

        public string TeamId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<AccountManager> AccountManagers { get; set; }
    }
}
