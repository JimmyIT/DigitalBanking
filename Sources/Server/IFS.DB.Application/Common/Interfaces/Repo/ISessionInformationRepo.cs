using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ISessionInformationRepo : IBaseRepo
    {
        #region Queries
        Task<SessionInformation> GetByIdAsync(string id);
        #endregion

        #region Commands
        Task InsertAsync(SessionInformation sessionInfo);
        Task UpdateAsync(SessionInformation sessionInfo);
        Task DeleteAsync(string id);
        Task DeleteAsync(SessionInformation sessionInfo);
        #endregion
    }
}
