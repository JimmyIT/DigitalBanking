using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ICurrencyRepo : IBaseRepo
    {
        #region Queries
        Task<IEnumerable<Currency>> GetAllAsync();
        #endregion Queries

        #region Commands
        #endregion Commands
    }
}
