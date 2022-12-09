using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IUserProfileRepo : IBaseRepo
    {
        #region Queries
        Task<IList<UserProfile>> GetByLogonIdAsync(string logonId);
        #endregion

        #region Commands
        #endregion
    }
}
