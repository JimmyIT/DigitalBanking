using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ICountRepo : IBaseRepo
    {
        #region Queries
        Task<Count> GetByEventDateAndTypeAsync(DateTime eventDate, string type);
        #endregion

        #region Command
        Task<string> GetNextReferenceAsync(string type, string clientNumber, string userId, string code);
        #endregion
    }
}
