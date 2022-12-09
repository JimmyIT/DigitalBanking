using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Utilities
{
    public class HashHelper
    {
        public static string HashStringValue(string hashedString, string saltValue)
        {
            IFS.Common.Utilities.HashValidation hash = new IFS.Common.Utilities.HashValidation();
            return hash.GetHash(hashedString + saltValue);
        }

        public static string HashStringValue(string hashedString)
        {
            IFS.Common.Utilities.HashValidation hash = new IFS.Common.Utilities.HashValidation();
            return hash.GetHash(hashedString);
        }
    }
}
