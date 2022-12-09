using IFS.DB.Application.Domain.Repo.Customers;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ICustomerRepo : IBaseRepo
    {
        #region Queries
        Task<IBankCustomer> GetByLogonId(string logOnId);
        #endregion

        #region Commands
        Task CreateAsync(IBankCustomer customer, CustomerParameter customerParam, IEnumerable<UserModel> lstUser);
        Task UpdateAsync(IBankCustomer customer, IEnumerable<UserProfile> lstUserProfile);
        #endregion
    }
}
