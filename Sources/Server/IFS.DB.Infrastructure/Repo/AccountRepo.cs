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
    public class AccountRepo : BaseRepo, IAccountRepo
    {
        public AccountRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {
        }

        #region Queries
        #endregion

        #region Commands
        public async Task InsertAsync(Account account)
        {
            await DBContext.Accounts.AddAsync(account);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteByAccountNumberAsync(string accountNumber)
        {
            Account entity = await DBContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
            DBContext.Accounts.Remove(entity);
            await DBContext.SaveChangesAsync();
        }
        #endregion
    }
}
