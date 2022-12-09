using IFS.DB.Application.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Notification
{
    public interface ISMSService
    {
        Task<ActionResult<bool>> SendSMSAsync(string phoneNumber, string message);
    }
}
