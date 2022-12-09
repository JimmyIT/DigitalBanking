using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Customers
{
    public interface IMoveCustomerToDataCaptureService
    {
        Task<ActionResult<bool>> DoActionAsync(Guid entityGuid);
    }
}
