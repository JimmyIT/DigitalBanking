using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class CountRepo : BaseRepo, ICountRepo
    {
        private string _DefaultPrefixRef = "RQ";
        private string _OnboardingPrefixRef = "OB";
        private static SemaphoreSlim _Semaphore = new SemaphoreSlim(1, 1);

        private readonly IDateTimeProvider _DateTimeProvider;

        public CountRepo(DigitalBankingDBContext dBContext,
            IDateTimeProvider dateTimeProvider)
            : base(dBContext)
        {
            _DateTimeProvider = dateTimeProvider;
        }

        #region Queries
        public async Task<Count> GetByEventDateAndTypeAsync(DateTime eventDate, string type)
        {
            return await DBContext.Counts.FirstOrDefaultAsync(x => x.EventDate == eventDate && x.Type == type);
        }
        #endregion

        #region Commands
        public async Task<string> GetNextReferenceAsync(string type, string clientNumber, string userId, string code)
        {
            string result = string.Empty;
            await _Semaphore.WaitAsync();
            
            double lastAllocatedRef = 1;
            DateTime dtToday = _DateTimeProvider.Today();

            Count entity = await GetByEventDateAndTypeAsync(dtToday, type);

            if (entity == null)
            {
                entity = new Count()
                {
                    ClientNumber = clientNumber,
                    EventDate = dtToday,
                    LastAllocatedReference = lastAllocatedRef,
                    Type = type,
                    UserId = userId
                };

                await DBContext.Counts.AddAsync(entity);
            }
            else
            {
                double max = type switch
                {
                    CountTypeConst.CustomerRequest or CountTypeConst.Onboarding => 99999,
                    CountTypeConst.OutputFileSeq or CountTypeConst.Error or _ => 99999999
                };

                if (entity.LastAllocatedReference < max)
                    entity.LastAllocatedReference++;
                else entity.LastAllocatedReference = 1;

                lastAllocatedRef = entity.LastAllocatedReference;

                DBContext.Counts.Update(entity);
            }

            await DBContext.SaveChangesAsync();

            string prefix = code;
            if (string.IsNullOrEmpty(prefix))
                prefix = type switch
                {
                    CountTypeConst.Onboarding => _OnboardingPrefixRef,
                    _ => _DefaultPrefixRef
                };

            result = $"{prefix}{dtToday.Year}{dtToday.Month.ToString().PadLeft(2, '0')}{dtToday.Day.ToString().PadLeft(2, '0')}-{lastAllocatedRef}";

            _Semaphore.Release();
            return result;
        }
        #endregion
    }
}
