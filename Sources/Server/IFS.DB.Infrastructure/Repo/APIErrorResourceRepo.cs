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
    public class APIErrorResourceRepo : BaseRepo, IAPIErrorResourceRepo
    {
        public APIErrorResourceRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        public async Task<ApiErrorResource> GetByKeyAsync(string key)
        {
            return await DBContext.ApiErrorResources.FirstOrDefaultAsync(x => x.ResourceKey == key);
        }
        #endregion

        #region Commands
        #endregion
    }
}
