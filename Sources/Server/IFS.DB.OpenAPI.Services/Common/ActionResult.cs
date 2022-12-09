using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace IFS.DB.OpenAPI.Services.Common
{
    public class ActionResult
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public bool IsError { get; set; } = false;

        public bool IsSuccess => !IsError;

        public static ActionResult Fail() =>
            new ActionResult { IsError = true };

        public static ActionResult Fail(string errorMessage) =>
            new ActionResult { IsError = true, ErrorMessages = new List<string> { errorMessage } };

        public static ActionResult Fail(List<string> errorMessages) =>
             new ActionResult { IsError = true, ErrorMessages = errorMessages };

        public static ActionResult Success() =>
             new ActionResult { IsError = false };

        public override string ToString()
        {
            return string.Join(Environment.NewLine, ErrorMessages);
        }

        public static ActionResult operator +(ActionResult first, ActionResult second)
        {
            ActionResult result = new ActionResult
            {
                IsError = first.IsError || second.IsError
            };
            result.ErrorMessages.AddRange(first.ErrorMessages.Concat(second.ErrorMessages));
            return result;
        }
    }

    public class ActionResult<T> : ActionResult
    {
        public T Data { get; set; } = default;

        public static new ActionResult<T> Fail() =>
            new ActionResult<T> { IsError = true };

        public static new ActionResult<T> Fail(string errorMessage) =>
            new ActionResult<T> { IsError = true, ErrorMessages = new List<string> { errorMessage } };

        public static new ActionResult<T> Fail(List<string> errorMessages) =>
            new ActionResult<T> { IsError = true, ErrorMessages = errorMessages };

        public static new ActionResult<T> Success() =>
            new ActionResult<T> { IsError = false };

        public static ActionResult<T> Success(T data) =>
             new ActionResult<T> { IsError = false, Data = data };

    }

    public class APIActionResult<T> : ActionResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public static new APIActionResult<T> Fail() =>
            new APIActionResult<T> { IsError = true };

        public static new APIActionResult<T> Fail(string errorMessage) =>
            new APIActionResult<T> { IsError = true, ErrorMessages = new List<string> { errorMessage } };

        public static new APIActionResult<T> Fail(List<string> errorMessages) =>
            new APIActionResult<T> { IsError = true, ErrorMessages = errorMessages };

        public static new APIActionResult<T> Success() =>
            new APIActionResult<T> { IsError = false };

        public static new APIActionResult<T> Success(T data) =>
             new APIActionResult<T> { IsError = false, Data = data };

    }

    public class APIActionResult : ActionResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public static new APIActionResult Fail() =>
            new APIActionResult { IsError = true };

        public static new APIActionResult Fail(string errorMessage) =>
            new APIActionResult { IsError = true, ErrorMessages = new List<string> { errorMessage } };

        public static new APIActionResult Fail(List<string> errorMessages) =>
            new APIActionResult { IsError = true, ErrorMessages = errorMessages };

        public static new APIActionResult Success() =>
            new APIActionResult { IsError = false };

    }

}
