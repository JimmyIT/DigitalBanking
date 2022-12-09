using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class AccountApplicationRepo : BaseRepo, IAccountApplicationRepo
    {
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IParameterService _ParameterSvc;

        public AccountApplicationRepo(DigitalBankingDBContext dBContext,
            IDateTimeProvider dateTimeProvider,
            IParameterService parameterSvc)
            : base(dBContext)
        {
            _DateTimeProvider = dateTimeProvider;
            _ParameterSvc = parameterSvc;
        }

        #region Queries
        public async Task<AccountApplication?> GetByEmailAsync(string emailAddress)
        {
            return await DBContext.AccountApplications.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
        }

        public async Task<AccountApplication?> GetByIdAsync(Guid id)
        {
            return await DBContext.AccountApplications.FirstOrDefaultAsync(x => x.UniqueId == id);
        }

        public async Task<AccountApplication?> GetBySessionIdAsync(Guid sessionId)
        {
            return await DBContext.AccountApplications.FirstOrDefaultAsync(x => x.SessionId == sessionId);
        }

        public async Task<AccountApplication?> GetByClientNumberAsync(string clientNumber)
        {
            return await DBContext.AccountApplications.FirstOrDefaultAsync(x => x.AllocatedClientId == clientNumber);
        }

        public async Task<IEnumerable<AccountApplication>> GetClearDownAsync()
        {
            List<AccountApplicationStatusEnum> lstStatus = new List<AccountApplicationStatusEnum>()
            {
                AccountApplicationStatusEnum.FailUpdateProfile,
                AccountApplicationStatusEnum.ResetCardPIN,
                AccountApplicationStatusEnum.ResetSecurityNumber,
                AccountApplicationStatusEnum.ResetPassword
            };

            int clearDownTime = await _ParameterSvc.GetAccountApplicationClearDownTimeAsync();
            return await DBContext.AccountApplications.Where(x => !lstStatus.Contains((AccountApplicationStatusEnum)x.Status.GetValueOrDefault()) && (x.DateSubmitted ?? (DateTime?)_DateTimeProvider.Now()).Value.AddDays(clearDownTime) <= _DateTimeProvider.Now()).ToListAsync();
        }

        public async Task<AccountApplication> GetByShuftiProRefIdAsync(string shuftiProRefId)
        {
            return await DBContext.AccountApplications.FirstOrDefaultAsync(x => x.ShuftiProRefId == shuftiProRefId);
        }
        #endregion Queries

        #region Commands
        public async Task InsertAsync(AccountApplication accApp)
        {
            await DBContext.AccountApplications.AddAsync(accApp);
            await DBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AccountApplication accApp)
        {
            DBContext.AccountApplications.Update(accApp);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            AccountApplication entity = await DBContext.AccountApplications.FirstOrDefaultAsync(x => x.UniqueId == id);
            if (entity != null)
            {
                DBContext.AccountApplications.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }       
        #endregion Commands
    }
}
