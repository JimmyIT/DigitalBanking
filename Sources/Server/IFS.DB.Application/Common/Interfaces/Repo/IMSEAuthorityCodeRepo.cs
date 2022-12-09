using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IMSEAuthorityCodeRepo : IBaseRepo
    {
        #region Queries
        #endregion

        #region Commands
        Task CreateAsync(MseauthorityCode mseAuthCode);
        #endregion
    }
}
