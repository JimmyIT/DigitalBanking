using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Results;
using IFS.DB.Application.Domain.ErrorCodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using IFS.DB.Application.Domain.Constants;

namespace IFS.DB.Infrastructure.External.AMLtrac
{
    public class BaseAMLtracOpenAPIService
    {
        protected readonly IParameterService _ParameterSvc;

        private HttpClient _HttpClient;
        private string _TokenPath = "/Token";

        private string _APIBaseURL = string.Empty;
        private bool _UseSSL = false;
        private string _AccessToken = "";

        public BaseAMLtracOpenAPIService(IParameterService parameterSvc)
        {
            _ParameterSvc = parameterSvc;
        }

        #region Protected functions
        protected async Task<ActionResult<T>> GetAsync<T>(string apiRoute)
        {
            await SetupConfig();

            string result = string.Empty;

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.GetAsync(apiRoute);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }

        protected async Task<ActionResult<T>> PostMultiPartFormAsync<T>(string apiRoute, MultipartFormDataContent content)
        {
            await SetupConfig();

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PostAsync(apiRoute, content);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }

        protected async Task<ActionResult<T>> POSTJsonAsync<T>(string apiRoute, string msgBody)
        {
            await SetupConfig();

            string result = string.Empty;

            //Set up request content
            HttpContent requestContent = new StringContent(msgBody, Encoding.UTF8, "application/Json");

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PostAsync(apiRoute, requestContent);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }

        protected async Task<ActionResult<T>> POSTJsonWithHeaderAsync<T>(string apiRoute, string msgBody, List<APIRequestHeader> lstHeader)
        {
            await SetupConfig();

            //Set Header
            foreach (APIRequestHeader item in lstHeader)
                _HttpClient.DefaultRequestHeaders.Add(item.ParamKey, item.ParamValue);

            string result = string.Empty;

            //Set up request content
            HttpContent requestContent = new StringContent(msgBody, Encoding.UTF8, "application/Json");

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PostAsync(apiRoute, requestContent);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }

        protected async Task<ActionResult<T>> PUTJsonAsync<T>(string apiRoute, string msgBody)
        {
            await SetupConfig();

            string result = string.Empty;

            //Set up request content
            HttpContent requestContent = new StringContent(msgBody, Encoding.UTF8, "application/Json");

            //Post request and get respone
            HttpResponseMessage response = await _HttpClient.PutAsync(apiRoute, requestContent);

            //Deserialize  Response
            return DeserializeResponse<T>(response);
        }
        #endregion

        #region Private Functions
        private async Task SetupConfig()
        {
            _HttpClient = new HttpClient();

            //Application name (https://<app name> || http://<app name>)
            _APIBaseURL = await _ParameterSvc.GetAMLtracOpenAPIURLAsync();
            string userName = await _ParameterSvc.GetAMLtracOpenAPIUsernameAsync();
            string password = await _ParameterSvc.GetAMLtracOpenAPIPasswordAsync();
            string thumbPrint = await _ParameterSvc.GetAMLtracOpenAPICertThumbPrintAsync();

            //using SSL?
            if (_APIBaseURL.Contains(@"https://"))
                _UseSSL = true;

            //Get access token
            _AccessToken = await GetClientToken(_APIBaseURL + _TokenPath, userName, password, thumbPrint);

            //Create Http Client
            _HttpClient = CreateHttpClient(thumbPrint);
        }

        private async Task<string> GetClientToken(string URL, string username, string password, string thumbPrint)
        {
            string tokenData = string.Empty;

            HttpClientHandler requestHandler = new HttpClientHandler();

            if (_UseSSL)
            {
                //Get SSL certificate when using https
                requestHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                X509Certificate2Collection certs = GetSSLCertFromStore(thumbPrint);
                requestHandler.ClientCertificates.AddRange(certs);
            }

            using (var client = new HttpClient(requestHandler, false))
            {
                //Initiate base root url
                client.BaseAddress = new Uri(_APIBaseURL);

                //Clear accept header
                client.DefaultRequestHeaders.Accept.Clear();

                //Authorizing step
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(new ASCIIEncoding().GetBytes(String.Format("{0}:{1}", username, password))));

                string postData = $"grant_type=password&username={username}&password={password}";
                HttpContent requestContent = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");

                //Get token from api
                HttpResponseMessage response = await client.PostAsync(new Uri(URL), requestContent);
                if (response.IsSuccessStatusCode)
                    tokenData = response.Content.ReadAsStringAsync().Result;
                else
                    throw new Exception($"No such host is known. ({_APIBaseURL})");
            }

            return DeserializeToken(tokenData);
        }

        private string DeserializeToken(string tokenData)
        {
            //Serialize happen here            
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(tokenData);
            string token = "";

            if (values.ContainsKey("access_token"))
                token = values["access_token"].ToString();
            return token;
        }

        private X509Certificate2Collection GetSSLCertFromStore(string thumbPrint)
        {
            X509Store store = new X509Store("My", StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbPrint, false);
            //if (certificates.Count == 0)
            //throw new Exception("Fail to locate certificate or the certificate is invalid");

            return certificates;
        }

        private HttpClient CreateHttpClient(string thumbPrint)
        {
            HttpClientHandler requestHandler = new HttpClientHandler();
            HttpClient client = null;
            if (_UseSSL)
            {
                requestHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                X509Certificate2Collection certs = GetSSLCertFromStore(thumbPrint);
                requestHandler.ClientCertificates.AddRange(certs);
            }

            client = new HttpClient(requestHandler, false);

            client.BaseAddress = new Uri(_APIBaseURL);
            client.DefaultRequestHeaders.Accept.Clear();

            //Set up token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken);

            //Set up header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
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

                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                JObject errorResultJToken = JObject.Parse(jsonResponse);

                if (errorResultJToken.SelectToken("errors") != null)
                {
                    Error[] errrors = JsonConvert.DeserializeObject<Error[]>(errorResultJToken.SelectToken("errors").ToString());
                    foreach (var error in errrors)
                    {
                        lstError.Add(error);
                    }
                }
                else
                {
                    Error error = new ExternalError(jsonResponse, ExternalSystemConst.AMLtracAPI);
                    lstError.Add(error);
                }

                result.Validation = new ValidationResult(lstError);
            }

            return result;
        }
        #endregion
    }
}
