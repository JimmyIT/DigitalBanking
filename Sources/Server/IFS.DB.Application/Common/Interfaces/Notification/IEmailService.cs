using IFS.DB.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Notification
{
    public interface IEmailService
    {
        string GetEmailContent(System.Collections.IDictionary context, string templateFileName);
        string FormatUrl(string paramKey, string paramValue);

        Task<bool> SendMailAsync(string subject, string recipients, string message);
    }
}
