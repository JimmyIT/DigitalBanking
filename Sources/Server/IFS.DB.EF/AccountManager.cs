using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class AccountManager
    {
        public AccountManager()
        {
            Clients = new HashSet<Client>();
        }

        public string AccountManagerId { get; set; } = null!;
        public string? Name { get; set; }
        public string? TeamId { get; set; }
        public string? Email { get; set; }

        public virtual Team? Team { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
