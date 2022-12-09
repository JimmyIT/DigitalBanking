using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IAccountRepo : IBaseRepo
    {
        #region Queries
        #endregion

        #region Commands
        Task InsertAsync(Account account);
        Task DeleteByAccountNumberAsync(string accountNumber);
        #endregion
    }
}
