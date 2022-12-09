using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Data
{
    public class SiteParameterService : ISiteParameterService
    {
        private SiteParameter _SiteParam;

        public SiteParameterService(DigitalBankingDBContext dbContext)
        {
            List<SiteParameter> lst = dbContext.SiteParameters.ToList();
            _SiteParam = lst[0] ?? new SiteParameter();
        }

        #region A Values
        public async Task<string> GetAdministratorEmailAsync()
        {
            return _SiteParam.AdministratorEmail;
        }
        #endregion A Values

        #region B Values
        public async Task<string> GetBankHomePageAsync()
        {
            return _SiteParam.BanksHomePage;
        }

        public async Task<string> GetBaseCurrencyAsync()
        {
            return _SiteParam.BaseCurrency;
        }
        #endregion B Values

        #region D Values
        public async Task<string> GetDefaultEntityLimitsCurrencyAsync()
        {
            return _SiteParam.DefaultEntityLimitsCurrency;
        }
        #endregion D Values

        #region E Values
        public async Task<int> GetExternalCustomerTimeOutAsync()
        {
            return _SiteParam.ExternalCustomerTimeOut.GetValueOrDefault(0);
        }
        #endregion E Values

        #region I Values
        public async Task<string> GetIBankURLAsync()
        {
            return _SiteParam.IBankUrl;
        }

        public async Task<string> GetInternalEmailServerAsync()
        {
            return _SiteParam.InternalEmailServer;
        }
        #endregion I Values

    }
}
