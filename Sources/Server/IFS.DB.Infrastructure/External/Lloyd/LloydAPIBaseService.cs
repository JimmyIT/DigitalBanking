using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IFS.DB.Infrastructure.External.Lloyd
{
    public class LloydAPIBaseService
    {
        protected readonly IParameterService _ParameterSvc;

        private string _LloydsStoreId;
        private string _LloydsUserId;
        private string _LloydsPwd;
        private string _LloydsApiUrl;
        private string _LloydsCertificatePwd;

        public LloydAPIBaseService(IParameterService parameterSvc)
        {
            _ParameterSvc = parameterSvc;
        }

        private async Task SetupConfig()
        {
            _LloydsStoreId = await _ParameterSvc.GetLloydStoreIdAsync();
            _LloydsUserId = await _ParameterSvc.GetLloydUsernameAsync();
            _LloydsPwd = await _ParameterSvc.GetLloydPasswordAsync();
            _LloydsApiUrl = await _ParameterSvc.GetLloydAPIUrlAsync();
            _LloydsCertificatePwd = await _ParameterSvc.GetLloydCertificatePwdAsync();
        }

        private async Task<HttpWebRequest> GetRequest(string certificatePath)
        {
            await SetupConfig();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_LloydsApiUrl);

            string username = "WS" + _LloydsStoreId + "._." + _LloydsUserId;
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + _LloydsPwd));

            X509Certificate2 certificate = new X509Certificate2(certificatePath, _LloydsCertificatePwd, X509KeyStorageFlags.MachineKeySet);

            webRequest.ClientCertificates.Add(certificate);

            webRequest.Headers.Add("Authorization", "Basic " + encoded);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        protected async Task Sale(string IpgTransactionId, string certificatePath)
        {
            HttpWebRequest webRequest = await GetRequest(certificatePath);

            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(string.Format(LloydXmlRequestConst.Sale, _LloydsStoreId, IpgTransactionId));

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    // parse to object later
                }
            }
        }

        protected async Task<string> Credit(string certificatePath, string request)
        {
            HttpWebRequest webRequest = await GetRequest(certificatePath);

            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(request);

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    return soapResult;
                }
            }
        }

        protected async Task<string> Display(string certificatePath, string hostedDataId)
        {
            HttpWebRequest webRequest = await GetRequest(certificatePath);

            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(string.Format(LloydXmlRequestConst.Display, hostedDataId));

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    return soapResult;
                }
            }
        }

        protected async Task<string> Delete(string certificatePath, string request)
        {
            HttpWebRequest webRequest = await GetRequest(certificatePath);

            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(request);

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    return soapResult;
                }
            }
        }
    }
}
