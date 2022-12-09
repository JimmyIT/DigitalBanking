using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.ErrorCodes
{
    public class Error
    {
        protected Error(string code)
        {
            Code = code;
        }

        protected Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        protected Error(string code, string message, string additionalInfo)
        {
            Code = code;
            Message = message;
            AdditionalInfo = additionalInfo;
        }

        public Error()
        {
        }

        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { set; get; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }

    public class CustomError : Error
    {
        public CustomError(string errorMessage)
            : base("99", errorMessage) { }
    }

    public class ExternalError : Error
    {
        public ExternalError(string errorMessage, string exteralSystem)
            : base("01", errorMessage, exteralSystem) { }
    }

    public class RequireError : Error
    {
        public RequireError()
            : base("02", "'{PropertyName}' is required") { }

        public RequireError(string name)
            : base("02", $"'{name}' is required") { }
    }

    public class ExistedError : Error
    {
        public ExistedError()
            : base("03", "'{PropertyName}' : {PropertyValue} already exists") { }
    }

    public class MissingHeaderError : Error
    {
        public MissingHeaderError()
            : base("04", "Header '{PropertyName}' is required") { }
    }

    public class NotExistedError : Error
    {
        public NotExistedError()
            : base("05", "'{PropertyName}' : {PropertyValue} doesn't exists") { }

        public NotExistedError(string name)
            : base("05", $"'{name}' doesn't exists") { }
    }

    public class InvalidDataError : Error
    {
        public InvalidDataError()
            : base("06", "'{PropertyName}' is invalid") { }

        public InvalidDataError(string name)
            : base("06", $"'{name}' is invalid") { }
    }

    public class MissingSettingError : Error
    {
        public MissingSettingError(string property)
            : base("07", $"Missing '{property}' settings") { }
    }

    public class MaxLengthError : Error
    {
        public MaxLengthError()
            : base("08", "'{PropertyName}' cannot be greater than {MaxLength} characters") { }
    }
}
