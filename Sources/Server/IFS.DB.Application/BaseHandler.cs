using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Domain.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application
{
    public interface IBaseHandler
    {
        public APIHeader Header { get; set; }
    }

    public class BaseHandler : IBaseHandler
    {
        public APIHeader Header { get; set; }

        protected readonly IErrorMessageService _ErrorMessageSvc;
        protected readonly IAPIHeaderValidator _HeaderValidator;

        public BaseHandler(IErrorMessageService errorMessageSvc,
            IAPIHeaderValidator headerValidator)
        {
            _ErrorMessageSvc = errorMessageSvc;
            _HeaderValidator = headerValidator;
        }
    }
}
