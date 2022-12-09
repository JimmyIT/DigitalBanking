using IFS.DB.OpenAPI.Client.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI.Services.Common
{
    public static class ActionResultExtension
    {
        public static ActionResult Fail(this ActionResult actionResult)
        {
            actionResult.IsError = true;
            return actionResult;
        }

        public static ActionResult Fail(this ActionResult actionResult, string message)
        {
            actionResult.IsError = true;
            actionResult.ErrorMessages.Add(message);
            return actionResult;
        }

        public static ActionResult Fail(this ActionResult actionResult, List<string> messages)
        {
            actionResult.IsError = true;
            actionResult.ErrorMessages.AddRange(messages);
            return actionResult;
        }

        public static ActionResult AggregateWith(this ActionResult self, ActionResult orther)
        {
            _ = self ?? throw new ArgumentNullException();
            if (orther == null) return self;
            self.IsError = self.IsError || orther.IsError;
            self.ErrorMessages.AddRange(orther.ErrorMessages);
            return self;
        }

        public static async Task<APIActionResult<T>> AsActionResultAsync<T>(this HttpResponseMessage response)
            where T : class
        {

            APIActionResult<T> result = new APIActionResult<T>
            {
                StatusCode = response.StatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                result.Data = response.Content != null
                    ? await response.Content.ReadFromJsonAsync<T>()
                    : default;

                return result;
            }

            result.IsError = true;

            result.ErrorMessages.Add(response.ReasonPhrase);

            if (response.StatusCode == HttpStatusCode.MethodNotAllowed
                || response.Content == null)
            {
                return result;
            }

            List<Error> errors = new List<Error>();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (jsonResponse.TryParseJToken(out var errorResultJToken))
            {
                if (errorResultJToken is JArray)
                {
                    errors.AddRange(JsonConvert.DeserializeObject<List<Error>>(jsonResponse));
                }
                else if (errorResultJToken is JObject)
                {
                    errors.Add(JsonConvert.DeserializeObject<Error>(jsonResponse));
                }

                if (errors?.Count > 0)
                {
                    result.ErrorMessages.AddRange(errors.Select(error => error.Message).ToList());
                }
            }

            return result;
        }

        private static bool TryParseJToken(this string inputStr, out JToken result)
        {
            result = null;
            try
            {
                result = JToken.Parse(inputStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
