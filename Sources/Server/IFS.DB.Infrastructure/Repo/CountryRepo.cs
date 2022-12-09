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
    public class CountryRepo : BaseRepo, ICountryRepo
    {
        public CountryRepo(DigitalBankingDBContext dbContext)
            : base(dbContext)
        {
        }

        #region Queries
        public async Task<IEnumerable<CountryCode>> GetAllAsync()
        {
            return await DBContext.CountryCodes.ToListAsync();
        }
        #endregion Queries

        #region Commands
        #endregion Commands
    }
}
