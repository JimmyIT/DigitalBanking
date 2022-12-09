using IFS.DB.Application.Domain.AMLtrac.Customers.CheckMissingDocument;
using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.AMLtrac.Customers
{
    public interface ICheckCustomerMissingDocumentService
    {
        Task<ActionResult<CheckCustomerMissingDocumentResponse>> DoActionAsync(Guid amltracRefId);
    }
}
