using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.Notification;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Utilities;
using NVelocityTemplateEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IFS.DB.Infrastructure.Notification
{
    public class EmailService : IEmailService
    {
        private SmtpClient _SmtpClient;
        private string _MailSender;

        private static string _CryptorKey = "@1B2c3D4e5F6g7H8";
        private static string _ParameterName = "req=";

        public EmailService(IParameterService parameterSvc,
            ISiteParameterService siteParameterSvc)
        {
            _MailSender = siteParameterSvc.GetAdministratorEmailAsync().GetAwaiter().GetResult();
            string mailServer = siteParameterSvc.GetInternalEmailServerAsync().GetAwaiter().GetResult();
            int mailPort = parameterSvc.GetMailPortAsync().GetAwaiter().GetResult();
            string mailUsername = parameterSvc.GetMailUsernameAsync().GetAwaiter().GetResult();
            string mailPassword = parameterSvc.GetMailPasswordAsync().GetAwaiter().GetResult();
            bool enableSsl = parameterSvc.GetMailEnableSslAsync().GetAwaiter().GetResult();

            NetworkCredential credential = new NetworkCredential(mailUsername, mailPassword);
            _SmtpClient = new SmtpClient(mailServer, mailPort);
            _SmtpClient.Credentials = credential.GetCredential(mailServer, mailPort, "Basic");
            _SmtpClient.UseDefaultCredentials = false;
            _SmtpClient.EnableSsl = enableSsl;
        }

        public string GetEmailContent(System.Collections.IDictionary context, string templateFileName)
        {
            string emailTemplateLocation = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            INVelocityEngine fileEngine = NVelocityTemplateEngine.NVelocityEngineFactory.CreateNVelocityFileEngine(emailTemplateLocation, true);
            return fileEngine.Process(context, templateFileName);
        }

        public string FormatUrl(string paramKey, string paramValue)
        {
            string queryStr = $"{paramKey}={paramValue}";
            //string encryptedCode = CryptorEngineService.Encrypt(queryStr, CryptorEngineService.DefaultCipherCode, _CryptorKey);
            //return $"?{_ParameterName}{HttpUtility.UrlEncode(encryptedCode)}";
            return $"?{queryStr}";
        }

        public async Task<bool> SendMailAsync(string subject, string recipients, string message)
        {
            bool result = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string[] recipientList = recipients.Split(";".ToCharArray());

            MailMessage mailMsg = new MailMessage()
            {
                From = new MailAddress(_MailSender),
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                Body = message,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8
            };

            foreach (string recipient in recipientList)
            {
                if (!string.IsNullOrEmpty(recipient.Trim()))
                {
                    mailMsg.To.Add(new MailAddress(recipient));
                }
            }

            _SmtpClient.Send(mailMsg);
            mailMsg.Attachments.Dispose();
            result = true;

            return result;
        }
    }
}
