using IFS.DB.Application.Domain.Bankware.Accounts.UpdateInternetFlag;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.Accounts
{
    public interface IUpdateAccountInternetFlagService
    {
        Task<ActionResult<UpdateAccountInternetFlagResponse>> DoActionAsync(UpdateAccountInternetFlagRequest account);
    }
}
