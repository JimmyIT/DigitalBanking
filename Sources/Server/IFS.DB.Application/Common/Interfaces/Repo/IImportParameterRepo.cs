using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IImportParameterRepo : IBaseRepo
    {
        #region Queries
        Task<bool> CheckNegativeAmountsRepresentAsync();
        #endregion

        #region Command
        #endregion
    }
}
