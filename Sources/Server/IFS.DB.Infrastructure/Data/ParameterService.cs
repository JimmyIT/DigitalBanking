using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Utilities;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Data
{
    public class ParameterService : IParameterService
    {
        private readonly DigitalBankingDBContext _DBContext;

        public ParameterService(DigitalBankingDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        #region A Values
        //Account Application ClearDown Time
        public async Task<int> GetAccountApplicationClearDownTimeAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AccountApplicationClearDownTime);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AccountApplicationClearDownTime,
                    ParamValue = "30",
                    ParamDescription = "Account Application ClearDown Time"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return ConvertHelper.ConvertStringToInt(param.ParamValue);
        }

        //AML Approved Mode
        public async Task<string> GetAMLApprovedModeAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLApprovedMode);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLApprovedMode,
                    ParamValue = "Auto",
                    ParamDescription = "AML Approved Mode : Auto, Manual"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //AMLtrac Host Id
        public async Task<string> GetAMLtracHostIdAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLtracHostId);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLtracHostId,
                    ParamValue = "",
                    ParamDescription = "AMLtrac Host Id"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //AMLtrac Branch Code
        public async Task<string> GetAMLtracBranchCodeAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLtracBranchCode);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLtracBranchCode,
                    ParamValue = "",
                    ParamDescription = "AMLtrac Branch Code"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //AMLtrac Open API URL
        public async Task<string> GetAMLtracOpenAPIURLAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLtracOpenAPIURL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLtracOpenAPIURL,
                    ParamValue = "http://amltracopenapi",
                    ParamDescription = "AMLtracOpenAPI URL link"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //AMLTrac Open API Username
        public async Task<string> GetAMLtracOpenAPIUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLtracOpenAPIUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLtracOpenAPIUsername,
                    ParamValue = "",
                    ParamDescription = "AMLtrac Open API Username"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //AMLTrac Open API Password
        public async Task<string> GetAMLtracOpenAPIPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLtracOpenAPIPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLtracOpenAPIPassword,
                    ParamValue = "",
                    ParamDescription = "AMLtracAPI Open Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //AMLTrac Open API CertThumbPrint
        public async Task<string> GetAMLtracOpenAPICertThumbPrintAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.AMLtracOpenAPICertThumbPrint);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.AMLtracOpenAPICertThumbPrint,
                    ParamValue = "",
                    ParamDescription = "AMLtracAPI Open CertThumbPrint"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Application Email Link Expiry Time
        public async Task<int> GetApplicationEmailLinkExpiryTimeAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ApplicationEmailLinkExpiryTime);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ApplicationEmailLinkExpiryTime,
                    ParamValue = "2",
                    ParamDescription = "Application Email Link Expiry Time"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return ConvertHelper.ConvertStringToInt(param.ParamValue);
        }
        #endregion A Values

        #region B Values
        //Bankware SystemId
        public async Task<string> GetBWSystemIdAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.BWSystemId);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.BWSystemId,
                    ParamValue = "Live",
                    ParamDescription = "Bankware systemId set up on SYSTEMS table of AppsManager DB"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //BWAPI Host  Id
        public async Task<string> GetBWHostIdAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.BWHostId);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.BWHostId,
                    ParamValue = "",
                    ParamDescription = "Bankware Host Id"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //BWOpen API URL
        public async Task<string> GetBWOpenAPIURLAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.BWOpenAPIURL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.BWOpenAPIURL,
                    ParamValue = "http://bwopenapi",
                    ParamDescription = "BW Open API URL link"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //BWOpen API Username
        public async Task<string> GetBWOpenAPIUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.BWOpenAPIUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.BWOpenAPIUsername,
                    ParamValue = "",
                    ParamDescription = "BW Open API Username"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //BWOpen API Password
        public async Task<string> GetBWOpenAPIPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.BWOpenAPIPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.BWOpenAPIPassword,
                    ParamValue = "",
                    ParamDescription = "BW Open API Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //BWOpen API Cert ThumbPrint
        public async Task<string> GetBWOpenAPICertThumbPrintAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.BWOpenAPICertThumbPrint);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.BWOpenAPICertThumbPrint,
                    ParamValue = "",
                    ParamDescription = "BW Open API Client SSL Certificate Thumbprint"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }
        #endregion B Values

        #region C Values
        //Card API URL
        public async Task<string> GetCardAPIURLAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.CardAPIURL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.CardAPIURL,
                    ParamValue = "http://cardapi",
                    ParamDescription = "CardAPI URL link"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Card API Username
        public async Task<string> GetCardAPIUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.CardAPIUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.CardAPIUsername,
                    ParamValue = "",
                    ParamDescription = "CardAPI Username"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Card API Password
        public async Task<string> GetCardAPIPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.CardAPIPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.CardAPIPassword,
                    ParamValue = "",
                    ParamDescription = "CardAPI Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Card API Cert ThumbPrint
        public async Task<string> GetCardAPICertThumbPrintAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.CardAPICertThumbPrint);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.CardAPICertThumbPrint,
                    ParamValue = "",
                    ParamDescription = "Card API Client SSL Certificate Thumbprint"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Client Template For OnBoarding
        public async Task<string> GetClientTemplateForOnBoardingAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ClientTemplateForOnBoarding);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ClientTemplateForOnBoarding,
                    ParamValue = "",
                    ParamDescription = "Client Template OnBoarding"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //COA For OnBoarding
        public async Task<string> GetCOAForOnBoardingAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.COAForOnBoarding);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.COAForOnBoarding,
                    ParamValue = "",
                    ParamDescription = "COA For OnBoarding"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Currency For OnBoarding
        public async Task<string> GetCurrencyForOnBoardingAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.CurrencyForOnBoarding);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.CurrencyForOnBoarding,
                    ParamValue = "",
                    ParamDescription = "Currency For OnBoarding"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Client Template For Tourist Card
        public async Task<string> GetClientTemplateForTouristCardAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ClientTemplateForTouristCard);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ClientTemplateForTouristCard,
                    ParamValue = "[Client Template For Tourist Card]",
                    ParamDescription = "Client Template Tourist Card"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //COA For Tourist Card
        public async Task<string> GetCOAForTouristCardAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.COAForTouristCard);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.COAForTouristCard,
                    ParamValue = "COA For Tourist Card]",
                    ParamDescription = "COA For Tourist Card"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Currency For Tourist Card
        public async Task<string> GetCurrencyForTouristCardAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.CurrencyForTouristCard);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.CurrencyForTouristCard,
                    ParamValue = "Currency For Tourist Card]",
                    ParamDescription = "Currency For Tourist Card"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }
        #endregion C Values

        #region D Values
        public async Task<string> GetDefaultLanguageAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.DefaultLanguage);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.DefaultLanguage,
                    ParamValue = "en-GB",
                    ParamDescription = "Default Language"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        public async Task<string> GetDocumentUploadFolderAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.DocumentUploadFolder);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.DocumentUploadFolder,
                    ParamValue = "C:\\inetpub\\i-Financial\\iBank\\Document",
                    ParamDescription = "Document Upload Folder"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        public async Task<long> GetDocumentSizeLimitAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.DocumentSizeLimit);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.DocumentSizeLimit,
                    ParamValue = "15360",
                    ParamDescription = "Document upload file size limit, default: 15360 kilobytes(15mb)",
                    UserEditable = true
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return ConvertHelper.ConvertStringToLong(param.ParamValue);
        }

        #endregion D Values

        #region E Values
        //Enable Debit Card Feature
        public async Task<bool> GetEnableCardFeatureAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.EnableDebitCardFeature);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.EnableDebitCardFeature,
                    ParamValue = "0",
                    ParamDescription = "This is Flag to enable/disable Card feature on ibank. When the value is 1, this feature will be turn on, otherwise when it is 0."
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }
        #endregion E Values

        #region H Values
        //Get HB Process MQ Max Retry
        public async Task<byte> GetHBProcessMQMaxRetryAsync()
        {
            byte result = 0;

            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.HBProcessMQMaxRetry);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.HBProcessMQMaxRetry,
                    ParamValue = result.ToString(),
                    ParamDescription = "Heart Beat MQMessage process maximum retry."
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            result = ConvertHelper.ConvertStringToByte(param.ParamValue);
            return result;
        }
        #endregion H Values

        #region I Values

        public async Task<string> GetInitVectorAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.InitVector);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.InitVector,
                    ParamValue = "@1B2c3D4e5F6g7H8",
                    ParamDescription = "Ibank web Init Vector setting."
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        #endregion

        #region L Values
        //Lloyd API URL
        public async Task<string> GetLloydAPIUrlAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.LloydAPIUrl);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.LloydAPIUrl,
                    ParamValue = "[Lloyd API URL]",
                    ParamDescription = "Lloyds API Url"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Lloyd API Username
        public async Task<string> GetLloydUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.LloydUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.LloydUsername,
                    ParamValue = "[Lloyd API Username]",
                    ParamDescription = "Lloyds UserId"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Lloyd Password
        public async Task<string> GetLloydPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.LloydPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.LloydPassword,
                    ParamValue = "[Lloyd API Password]",
                    ParamDescription = "Lloyds API Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Lloyd Store Id
        public async Task<string> GetLloydStoreIdAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.LloydStoreId);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.LloydStoreId,
                    ParamValue = "[Lloyd API StoreId]",
                    ParamDescription = "Lloyds StoreId"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Lloyd Certificate Pwd
        public async Task<string> GetLloydCertificatePwdAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.LloydCertificatePwd);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.LloydCertificatePwd,
                    ParamValue = "[Lloyds certificate passphrase]",
                    ParamDescription = "Lloyds certificate passphrase"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }
        #endregion L Values

        #region M Values
        //Mail Port
        public async Task<int> GetMailPortAsync()
        {
            int result = 0;

            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.MailPort);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.MailPort,
                    ParamValue = result.ToString(),
                    ParamDescription = "Mail Port"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            result = ConvertHelper.ConvertStringToInt(param.ParamValue);
            return result;
        }

        //Mail Username
        public async Task<string> GetMailUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.MailUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.MailUsername,
                    ParamValue = "[Mail Username]",
                    ParamDescription = "Mail Username"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Mail Password
        public async Task<string> GetMailPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.MailPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.MailPassword,
                    ParamValue = "[Mail Password]",
                    ParamDescription = "Mail Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Mail Enable SSL
        public async Task<bool> GetMailEnableSslAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.MailEnableSSL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.MailEnableSSL,
                    ParamValue = "0",
                    ParamDescription = "Mail Enable SSL"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }
        #endregion M Values

        #region O Values
        //Onboarding Production
        public async Task<OnboardingProductionEnum> GetOnboardingProductionAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.OnboardingProduction);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.OnboardingProduction,
                    ParamValue = "0",
                    ParamDescription = "Onboarding Production - 0 : Default (Donot send register email in first step), 1 : KYC (Tag) , 2 : Email ( send register email in first step)"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (OnboardingProductionEnum)ConvertHelper.ConvertStringToInt(param.ParamValue);
        }

        //Onboarding Web URL
        public async Task<string> GetOnboardingWebURLAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.OnboardingWebURL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.OnboardingWebURL,
                    ParamValue = "http://onboardingweburl",
                    ParamDescription = "Onboarding Web URL"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }
        #endregion O Values

        #region P Values
        //Password Strength
        public async Task<string> GetPasswordStrengthAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.PasswordStrength);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.PasswordStrength,
                    ParamValue = "^.*(?=.{8,12})(?=.*[a-z])(?=.*[A-Z])(?=.*[\\d]).*$",
                    ParamDescription = "Ibank web password regex setting."
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Permitted IPs
        public async Task<string> GetPermittedIPsAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.PermittedIPs);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.PermittedIPs,
                    ParamValue = "",
                    ParamDescription = "A list of IPs (can include wild cards)"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Permitted LogonID
        public async Task<string> GetPermittedLogonIDsAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.PermittedLogonIDs);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.PermittedLogonIDs,
                    ParamValue = "",
                    ParamDescription = "A list of LogonID"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }
        #endregion P Values

        #region R Values
        //Restrict LogonID
        public async Task<bool> GetRestrictLogonAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.RestrictLogon);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.RestrictLogon,
                    ParamValue = "0",
                    ParamDescription = "1:Yes; 0:No"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }
        #endregion R Values

        #region S Values
        //Send iBank Customer Registration Email
        public async Task<bool> GetSendiBankCustomerRegistrationNotificationAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.SendiBankCustomerRegistrationNotification);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.SendiBankCustomerRegistrationNotification,
                    ParamValue = "0",
                    ParamDescription = "Send iBank Customer Registration Email"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }

        //ShuftiPro API URL
        public async Task<string> GetShuftiProAPIURLAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIURL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIURL,
                    ParamValue = "https://api.shuftipro.com",
                    ParamDescription = "ShuftiProAPI URL link"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //ShuftiPro API Username
        public async Task<string> GetShuftiProAPIUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIUsername,
                    ParamValue = "",
                    ParamDescription = "ShuftiProAPI Username"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //ShuftiPro API Password
        public async Task<string> GetShuftiProAPIPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIPassword,
                    ParamValue = "",
                    ParamDescription = "ShuftiProAPI Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //ShuftiPro API Allow Face
        public async Task<bool> GetShuftiProAPIAllowFaceAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIAllowFace);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIAllowFace,
                    ParamValue = "1",
                    ParamDescription = "ShuftiProAPI Allow Face"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }

        //ShuftiPro API Allow Offline
        public async Task<bool> GetShuftiProAPIAllowOfflineAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIAllowOffline);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIAllowOffline,
                    ParamValue = "1",
                    ParamDescription = "ShuftiProAPI Allow Offline"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }

        //ShuftiPro API Allow Online
        public async Task<bool> GetShuftiProAPIAllowOnlineAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIAllowOnline);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIAllowOnline,
                    ParamValue = "0",
                    ParamDescription = "ShuftiProAPI Allow Online"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return (param.ParamValue == "1" || param.ParamValue.ToLower() == "true" || param.ParamValue.ToUpper() == "Y") ? true : false;
        }

        //ShuftiPro API Expire Time
        public async Task<int> GetShuftiProAPIExpireTimeAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.ShuftiProAPIExpireTime);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.ShuftiProAPIExpireTime,
                    ParamValue = "60",
                    ParamDescription = "ShuftiProAPI Expire Time"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return ConvertHelper.ConvertStringToInt(param.ParamValue);
        }
        #endregion S Values

        #region T Values
        //Token Life Cirle
        public async Task<int> GetTokenLifeCirleAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TokenLifeCircle);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TokenLifeCircle,
                    ParamValue = "1",
                    ParamDescription = "Token Life Circle Time - Set in hours"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return ConvertHelper.ConvertStringToInt(param.ParamValue);
        }

        //Token Sale Open API URL
        public async Task<string> GetTokenSaleOpenAPIURLAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TokenSaleOpenAPIURL);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TokenSaleOpenAPIURL,
                    ParamValue = "",
                    ParamDescription = "Token Sale Open API URL link"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Token Sale Open API Username
        public async Task<string> GetTokenSaleOpenAPIUsernameAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TokenSaleOpenAPIUsername);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TokenSaleOpenAPIUsername,
                    ParamValue = "",
                    ParamDescription = "Token Sale Open API Username"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Token Sale Open API Password
        public async Task<string> GetTokenSaleOpenAPIPasswordAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TokenSaleOpenAPIPassword);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TokenSaleOpenAPIPassword,
                    ParamValue = "",
                    ParamDescription = "Token Sale Open API Password"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Twilio Sid
        public async Task<string> GetTwilioSidAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TwilioSid);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TwilioSid,
                    ParamValue = "",
                    ParamDescription = "2FA Twilio Sid setting"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Twilio Token
        public async Task<string> GetTwilioTokenAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TwilioToken);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TwilioToken,
                    ParamValue = "",
                    ParamDescription = "2FA Twilio Token setting"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }

        //Twilio From
        public async Task<string> GetTwilioFromAsync()
        {
            Parameter? param = await _DBContext.Parameters.FirstOrDefaultAsync(x => x.ParamKey == ParamKeyConst.TwilioFrom);

            if (param == null)
            {
                param = new Parameter()
                {
                    ParamKey = ParamKeyConst.TwilioFrom,
                    ParamValue = "",
                    ParamDescription = "2FA Twilio From setting"
                };
                await _DBContext.AddAsync(param);
                await _DBContext.SaveChangesAsync();
            }

            return param.ParamValue;
        }
        #endregion T Values


    }
}
