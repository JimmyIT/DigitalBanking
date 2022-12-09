using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class AuthorityCodeRepo : BaseRepo, IAuthorityCodeRepo
    {
        public AuthorityCodeRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        #endregion

        #region Commands
        #endregion
    }
}
