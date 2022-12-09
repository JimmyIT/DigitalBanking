using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common
{
    public interface IStringProvider
    {
        Guid NewGuid();
        string NewUniqueId();
    }

    public class StringProvider : IStringProvider
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        public string NewUniqueId()
        {
            return DateTime.UtcNow.ToString("yyMMddHHmmssff");
        }
    }
}
