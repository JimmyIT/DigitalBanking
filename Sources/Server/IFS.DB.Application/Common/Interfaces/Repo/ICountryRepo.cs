using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ICountryRepo : IBaseRepo
    {
        #region Queries
        Task<IEnumerable<CountryCode>> GetAllAsync();
        #endregion Queries

        #region Commands
        #endregion Commands
    }
}
