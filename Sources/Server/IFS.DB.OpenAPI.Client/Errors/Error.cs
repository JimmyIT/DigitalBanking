using System;
using System.Collections.Generic;
using System.Text;

namespace IFS.DB.OpenAPI.Client.Errors
{
    public class Error
    {
        public string AdditionalInfo { set; get; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Reference { get; set; }
    }
}
