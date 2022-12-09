using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.ErrorCodes;
using IFS.DB.Application.Domain.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.External.ShuftiPro
{
    public class BaseShuftiProAPIService
    {
        protected readonly IParameterService _ParameterSvc;

        private HttpClient _HttpClient;

        public BaseShuftiProAPIService(IParameterService parameterSvc)
        {
            _ParameterSvc = parameterSvc;
        }

        #region Protected Functions
        protected async Task<ActionResult<T>> POSTJsonAsync<T>(string apiRoute, object body)
        {
            await SetupConfig();

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PostAsJsonAsync(apiRoute, body);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }
        #endregion

        #region Private Functions
        private async Task SetupConfig()
        {
            string url = await _ParameterSvc.GetShuftiProAPIURLAsync();
            string username = await _ParameterSvc.GetShuftiProAPIUsernameAsync();
            string password = await _ParameterSvc.GetShuftiProAPIPasswordAsync();

            //Create Http Client
            _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri(url);
            _HttpClient.DefaultRequestHeaders.Accept.Clear();

            //Set up token
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
        }

        private ActionResult<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            ActionResult<T> result = new ActionResult<T>();

            //Check success
            if (response.IsSuccessStatusCode)
                result.Result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            else
            {
                IList<Error> lstError = new List<Error>();

                //Mapping Error
                ShuftiProError shuftiProError = JsonConvert.DeserializeObject<ShuftiProError>(response.Content.ReadAsStringAsync().Result);
                lstError.Add(new ExternalError(shuftiProError.ErrorDetail.Message, ExternalSystemConst.ShuftiProAPI));

                result.Validation = new ValidationResult(lstError);
            }

            return result;
        }
        #endregion
    }

    internal class ShuftiProError
    {
        [JsonProperty("error")]
        public ShuftiProErrorDetail ErrorDetail { get; set; }
    }

    internal class ShuftiProErrorDetail
    {
        [JsonProperty("service")]
        public string Service { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
