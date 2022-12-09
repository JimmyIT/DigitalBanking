using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class UserRightRepo : BaseRepo, IUserRightRepo
    {
        private readonly IDateTimeProvider _DateTimeProvider;

        public UserRightRepo(DigitalBankingDBContext dbContext,
            IDateTimeProvider dateTimeProvider)
            : base(dbContext)
        {
            _DateTimeProvider = dateTimeProvider;
        }

        #region Commands
        public async Task CreateAsync(string clientNumber, string internalId, ProductCodeEnum productCode)
        {
            if (!string.IsNullOrEmpty(clientNumber) && !string.IsNullOrEmpty(internalId))
            {
                UserRight entity = new UserRight()
                {
                    ClientId = clientNumber,
                    GroupId = null,
                    InternalId = internalId,
                    ProductId = ((int)productCode).ToString(),
                    AccountId = "",
                    ViewingAllowed = true,
                    UnlimitedEntry = true,
                    UnlimitedSigning = true,
                    UnlimitedVerification = true,
                    SignOwn = true,
                    VerifyOwn = true,
                    LastUpdatedBy = internalId,
                    LastUpdatedOn = _DateTimeProvider.Now()
                };

                await DBContext.UserRights.AddAsync(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task CreateListAsync(string clientNumber, string internalId, IEnumerable<ProductCodeEnum> lstProductCode)
        {
            if (!string.IsNullOrEmpty(clientNumber) && !string.IsNullOrEmpty(internalId))
            {
                foreach (ProductCodeEnum productCode in lstProductCode)
                {
                    UserRight entity = new UserRight()
                    {
                        ClientId = clientNumber,
                        GroupId = null,
                        InternalId = internalId,
                        ProductId = ((int)productCode).ToString(),
                        AccountId = "",
                        ViewingAllowed = true,
                        UnlimitedEntry = true,
                        UnlimitedSigning = true,
                        UnlimitedVerification = true,
                        SignOwn = true,
                        VerifyOwn = true,
                        LastUpdatedBy = internalId,
                        LastUpdatedOn = _DateTimeProvider.Now()
                    };

                    await DBContext.UserRights.AddAsync(entity);
                    await DBContext.SaveChangesAsync();
                }
            }
        }
        #endregion
    }
}
