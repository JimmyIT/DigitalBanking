using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class ImportParameterRepo : BaseRepo, IImportParameterRepo
    {
        public ImportParameterRepo(DigitalBankingDBContext dbContext)
            : base(dbContext)
        {
        }

        #region Queries
        public async Task<bool> CheckNegativeAmountsRepresentAsync()
        {
            bool result = false;

            List<ImportParameter> lst = await DBContext.ImportParameters.ToListAsync();

            if (lst != null && lst.Count() > 0)
            {
                result = lst[0].NegativeAmountsRepresent == "C";
            }

            return result;
        }
        #endregion

        #region Commands
        #endregion
    }
}
