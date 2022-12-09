using IFS.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Repo.Customers;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {
        private readonly IRandomHelper _RandomHelper;
        private readonly IStoreProcedureRepo _StoreProcedureRepo;

        public CustomerRepo(DigitalBankingDBContext dBContext,
            IRandomHelper randomHelper,
            IStoreProcedureRepo storeProcedureRepo)
            : base(dBContext)
        {
            _RandomHelper = randomHelper;
            _StoreProcedureRepo = storeProcedureRepo;
        }

        #region Queries
        public async Task<IBankCustomer> GetByLogonId(string logonId)
        {
            return await DBContext.IBankCustomers.FirstOrDefaultAsync(x => x.LogonId == logonId);
        }
        #endregion

        #region Commands
        public async Task CreateAsync(IBankCustomer customer, CustomerParameter customerParam, IEnumerable<UserModel> lstUser)
        {
            //Create IBankCustomer
            await DBContext.IBankCustomers.AddAsync(customer);
            await DBContext.SaveChangesAsync();

            //Create CustomerParameters
            await DBContext.CustomerParameters.AddAsync(customerParam);
            await DBContext.SaveChangesAsync();

            //Create Users
            foreach (UserModel user in lstUser)
            {
                //Create UserProfile
                await DBContext.UserProfiles.AddAsync(user.Profile);
                await DBContext.SaveChangesAsync();

                //Create user preferences with default values
                await _StoreProcedureRepo.CreateDefaultPreference(user.Profile.InternalId, user.Profile.LogonId, user.Profile.UserId);

                //If PIN is empty and Password is not empty, set PIN = Password
                if (string.IsNullOrEmpty(user.PIN) && !string.IsNullOrEmpty(user.Password))
                    user.PIN = user.Password;

                //Generate PIN when PIN is empty
                if (string.IsNullOrEmpty(user.PIN))
                    user.PIN = Cryptor.Encrypt(_RandomHelper.GeneratePIN());

                //If Password is empty, set Password = PIN
                if (string.IsNullOrEmpty(user.Password))
                    user.Password = user.PIN;

                //Decrypt PIN and Password
                string password = Cryptor.Decrypt(user.Password);
                string pin = Cryptor.Decrypt(user.PIN);

                //Create AuthorityCodes
                string pinHash = HashHelper.HashStringValue(pin, user.Profile.InternalId.Trim());
                string passwordHash = HashHelper.HashStringValue(password, user.Profile.InternalId.Trim());

                AuthorityCode authCodeEntity = new AuthorityCode()
                {
                    InternalId = user.Profile.InternalId,
                    Keyword1 = passwordHash,
                    Keyword2 = passwordHash,
                    Keyword3 = passwordHash,
                    Keyword4 = passwordHash,
                    Keyword5 = passwordHash,
                    Keyword6 = passwordHash,
                    Keyword7 = passwordHash,
                    Keyword8 = passwordHash,
                    Keyword9 = passwordHash,
                    Keyword10 = passwordHash,
                    Pin = pinHash
                };

                await DBContext.AuthorityCodes.AddAsync(authCodeEntity);
                await DBContext.SaveChangesAsync();

                //Create SplitAuthorityCode
                for (int i = 0; i < password.Length; i++)
                {
                    SplitAuthorityCode splitAuthCodeEntity = new SplitAuthorityCode()
                    {
                        InternalId = user.Profile.InternalId,
                        HashedChar = HashHelper.HashStringValue(password[i].ToString(), user.Profile.InternalId.Trim()),
                        Sequence = (short)i
                    };

                    await DBContext.SplitAuthorityCodes.AddAsync(splitAuthCodeEntity);
                    await DBContext.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateAsync(IBankCustomer customer, IEnumerable<UserProfile> lstUserProfile)
        {
            //Update IBankCustomer
            DBContext.IBankCustomers.Update(customer);
            await DBContext.SaveChangesAsync();

            //Update User Profile
            DBContext.UserProfiles.UpdateRange(lstUserProfile);
            await DBContext.SaveChangesAsync();
        }
        #endregion
    }
}
