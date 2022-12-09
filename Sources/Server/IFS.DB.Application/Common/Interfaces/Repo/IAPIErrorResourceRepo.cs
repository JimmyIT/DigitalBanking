using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IAPIErrorResourceRepo : IBaseRepo
    {
        #region Queries
        Task<ApiErrorResource> GetByKeyAsync(string key);
        #endregion

        #region Commands
        #endregion
    }
}
