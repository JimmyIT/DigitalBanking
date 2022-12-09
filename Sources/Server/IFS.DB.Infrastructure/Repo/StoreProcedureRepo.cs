using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class StoreProcedureRepo : BaseRepo, IStoreProcedureRepo
    {
        public StoreProcedureRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region UserPreferences
        public async Task CreateDefaultPreference(string internalID, string logonID, string userID)
        {
            List<SqlParameter> lstParam = new List<SqlParameter>
                { 
                    // Create parameters    
                    new SqlParameter { ParameterName = "@InternalID", Value = internalID },
                    new SqlParameter { ParameterName = "@LogonID", Value = logonID },
                    new SqlParameter { ParameterName = "@UserID", Value = userID }
                };

            await DBContext.Database.ExecuteSqlRawAsync($"{StoreProcedureConst.UserPreferences.CreateDefaultPreference} @InternalID, @LogonID, @UserID", lstParam.ToArray());
        }
        #endregion UserPreferences
    }
}
