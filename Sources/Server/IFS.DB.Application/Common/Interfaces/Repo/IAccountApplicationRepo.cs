using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IAccountApplicationRepo : IBaseRepo
    {
        #region Queries
        Task<AccountApplication> GetByEmailAsync(string emailAddress);
        Task<AccountApplication> GetByIdAsync(Guid id);
        Task<AccountApplication> GetBySessionIdAsync(Guid sessionId);
        Task<AccountApplication?> GetByClientNumberAsync(string clientNumber);
        Task<IEnumerable<AccountApplication>> GetClearDownAsync();
        Task<AccountApplication> GetByShuftiProRefIdAsync(string shuftiProRefId);
        #endregion Queries

        #region Commands
        Task InsertAsync(AccountApplication accApp);
        Task UpdateAsync(AccountApplication accApp);
        Task DeleteAsync(Guid id);
        #endregion Commands
    }
}
