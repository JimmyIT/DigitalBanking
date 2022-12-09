using IFS.DB.Application.Domain.Bankware.Clients.CheckEmailExist;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Bankware.Clients
{
    public interface ICheckEmailExistService
    {
        Task<ActionResult<CheckEmailExistResponse>> DoActionAsync(CheckEmailExistRequest email);
    }
}
