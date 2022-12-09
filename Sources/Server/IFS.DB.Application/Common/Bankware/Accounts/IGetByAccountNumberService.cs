using IFS.DB.Application.Domain.Bankware.Accounts.GetByAccountNumber;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.Accounts
{
    public interface IGetAccountByAccountNumberService
    {
        Task<ActionResult<GetByAccountNumberResponse>> DoActionAsync(string accountNumber);
    }
}
