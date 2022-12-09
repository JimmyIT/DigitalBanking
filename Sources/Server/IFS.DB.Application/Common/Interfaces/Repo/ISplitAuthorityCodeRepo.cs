using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ISplitAuthorityCodeRepo : IBaseRepo
    {
        #region Queries
        Task<int> GetPasswordLengthByInternalIdAsync(string internalId);
        #endregion

        #region Commands
        #endregion
    }
}
