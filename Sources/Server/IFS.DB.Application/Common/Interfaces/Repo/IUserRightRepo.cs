using IFS.DB.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IUserRightRepo : IBaseRepo
    {
        Task CreateAsync(string clientNumber, string internalId, ProductCodeEnum productCode);
        Task CreateListAsync(string clientNumber, string internalId, IEnumerable<ProductCodeEnum> lstProductCode);
    }
}
