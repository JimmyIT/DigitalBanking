using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class SplitAuthorityCodeRepo : BaseRepo, ISplitAuthorityCodeRepo
    {
        public SplitAuthorityCodeRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        public async Task<int> GetPasswordLengthByInternalIdAsync(string internalId)
        {
            return (await DBContext.SplitAuthorityCodes.Where(x => x.InternalId == internalId).ToListAsync()).Count();
        }
        #endregion

        #region Commands
        #endregion
    }
}
