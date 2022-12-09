using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IClientRepo : IBaseRepo
    {
        #region Queries
        Task<Client> GetByClientNumberAsync(string clientNumber);
        #endregion Queries

        #region Commands
        Task InsertAsync(Client client);
        Task DeleteAsync(string clientNumber);
        #endregion Commands
    }
}
