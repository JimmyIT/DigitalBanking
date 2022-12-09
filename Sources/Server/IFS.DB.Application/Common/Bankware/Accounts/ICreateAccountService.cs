using IFS.DB.Application.Domain.Bankware.Accounts.Create;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.Accounts
{
    public interface ICreateAccountService
    {
        Task<ActionResult<CreateAccountResponse>> DoActionAsync(CreateAccountRequest account);
    }
}
