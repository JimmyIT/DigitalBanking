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
    public class CurrencyRepo : BaseRepo, ICurrencyRepo
    {
        public CurrencyRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await DBContext.Currencies.ToListAsync();
        }
        #endregion Queries
    }
}
