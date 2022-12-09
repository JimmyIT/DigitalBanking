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
    public class SessionInformationRepo : BaseRepo, ISessionInformationRepo
    {
        public SessionInformationRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        public async Task<SessionInformation> GetByIdAsync(string id)
        {
            return await DBContext.SessionInformations.FirstOrDefaultAsync(x => x.SessionId == id);
        }
        #endregion

        #region Commands
        public async Task InsertAsync(SessionInformation sessionInfo)
        {
            await DBContext.SessionInformations.AddAsync(sessionInfo);
            await DBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SessionInformation sessionInfo)
        {
            DBContext.SessionInformations.Update(sessionInfo);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            SessionInformation entity = await DBContext.SessionInformations.FirstOrDefaultAsync(x => x.SessionId == id);
            if (entity != null)
            {
                DBContext.SessionInformations.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(SessionInformation sessionInfo)
        {
            DBContext.SessionInformations.Remove(sessionInfo);
            await DBContext.SaveChangesAsync();
        }
        #endregion
    }
}
