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
    public class UserProfileRepo : BaseRepo, IUserProfileRepo
    {
        public UserProfileRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        public async Task<IList<UserProfile>> GetByLogonIdAsync(string logonId)
        {
            return await DBContext.UserProfiles.Where(x => x.LogonId == logonId).ToListAsync();
        }
        #endregion

        #region Commands
        #endregion
    }
}
