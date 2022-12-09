using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Constants
{
    public struct ErrorMessageCode
    {
        #region Http Error Code
        public const string ResourceNotFound = "404";
        public const string InternalServerError = "500";
        public const string UnhandledException = "500";
        #endregion

        #region Application Error Code
        public const string SessionIdRequired = "1";
        public const string SessionIdMaxLength50 = "2";
        public const string LogonRestricted = "3";
        public const string IPBlocked = "4";
        public const string LogonIdInvalid = "5";
        public const string LogonIdRequired = "6";
        public const string CustomerAccountInActive = "7";
        public const string CustomerAccountLocked = "8";
        #endregion
    }
}
