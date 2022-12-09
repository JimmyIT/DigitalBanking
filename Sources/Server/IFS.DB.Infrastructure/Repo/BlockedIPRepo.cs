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
    public class BlockedIPRepo : BaseRepo, IBlockedIPRepo
    {
        public BlockedIPRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        public async Task<BlockedIp> GetByIPAsync(string ip)
        {
            return await DBContext.BlockedIps.FirstOrDefaultAsync(x => x.Ip == ip);
        }
        #endregion

        #region Command
        #endregion
    }
}
