using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Customers
{
    public interface IApproveCustomerService
    {
        Task<ActionResult<string>> DoActionAsync(Guid applicationId);
    }
}
