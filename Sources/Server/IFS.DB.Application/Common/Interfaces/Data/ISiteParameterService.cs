using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Data
{
    public interface ISiteParameterService
    {
        #region A Values
        Task<string> GetAdministratorEmailAsync();
        #endregion A Values

        #region B Values
        Task<string> GetBankHomePageAsync();
        Task<string> GetBaseCurrencyAsync();
        #endregion B Values

        #region D Values
        Task<string> GetDefaultEntityLimitsCurrencyAsync();
        #endregion D Values

        #region E Values
        Task<int> GetExternalCustomerTimeOutAsync();
        #endregion E Values

        #region I Values
        Task<string> GetIBankURLAsync();
        Task<string> GetInternalEmailServerAsync();
        #endregion I Values
    }
}
