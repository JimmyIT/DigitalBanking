using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Constants
{
    public struct ParamKeyConst
    {
        #region A Values
        public const string AccountApplicationClearDownTime = "AccountApplicationClearDownTime";

        public const string AMLApprovedMode = "AMLApprovedMode";

        public const string AMLtracHostId = "AMLTrac_HostId";
        public const string AMLtracBranchCode = "AMLTrac_BranchCode";

        public const string AMLtracOpenAPIURL = "AMLTracOpenAPI_BaseURL";
        public const string AMLtracOpenAPIUsername = "AMLTracOpenAPI_Username";
        public const string AMLtracOpenAPIPassword = "AMLTracOpenAPI_Password";
        public const string AMLtracOpenAPICertThumbPrint = "AMLTracOpenAPI_CertThumbPrint";

        public const string ApplicationEmailLinkExpiryTime = "ApplicationEmailLinkExpiryTime";
        #endregion A Values

        #region B Values
        public const string BankHomePage = "BankHomePage";

        public const string BWSystemId = "BankwareSystemId";

        public const string BWHostId = "BW_HostId";

        public const string BWOpenAPIURL = "BWOpenAPI_BaseURL";
        public const string BWOpenAPIUsername = "BWOpenAPI_Username";
        public const string BWOpenAPIPassword = "BWOpenAPI_Password";
        public const string BWOpenAPICertThumbPrint = "BWOpenAPI_CertThumbPrint";
        #endregion B Values

        #region C Values
        public const string CardAPIURL = "CardAPI_BaseURL";
        public const string CardAPIUsername = "CardAPI_Username";
        public const string CardAPIPassword = "CardAPI_Password";
        public const string CardAPICertThumbPrint = "CARDAPI_CertThumbprint";

        public const string ClientTemplateForOnBoarding = "ClientTemplateForOnBoarding";
        public const string COAForOnBoarding = "COAForOnBoarding";
        public const string CurrencyForOnBoarding = "CurrencyForOnBoarding";

        public const string ClientTemplateForTouristCard = "ClientTemplateForTouristCard";
        public const string COAForTouristCard = "COAForTouristCard";
        public const string CurrencyForTouristCard = "CurrencyForTouristCard";
        #endregion C Values

        #region D Values
        public const string DefaultLanguage = "DefaultLanguage";
        public const string DocumentUploadFolder = "DocumentUploadFolder";
        public const string DocumentSizeLimit = "DocumentSizeLimit";
        #endregion D Values

        #region E Values
        public const string EnableDebitCardFeature = "EnableDebitCardFeature";
        #endregion E Values

        #region H Values
        public const string HBProcessMQMaxRetry = "HBProcessMQMaxRetry";
        #endregion H Values

        #region I Values
        public const string InitVector = "InitVector";
        #endregion

        #region L Values
        public const string LloydAPIUrl = "LloydsApiUrl";
        public const string LloydUsername = "LloydsUserId";
        public const string LloydPassword = "LloydsPwd";
        public const string LloydStoreId = "LloydsStoreId";
        public const string LloydCertificatePwd = "LloydsCertificatePwd";
        #endregion L Values

        #region M Values
        public const string MailPort = "Mail_Port";
        public const string MailUsername = "Mail_Username";
        public const string MailPassword = "Mail_Password";
        public const string MailEnableSSL = "Mail_EnableSSL";
        #endregion M Values

        #region O Values
        public const string OnboardingProduction = "OnboardingProduction";
        public const string OnboardingWebURL = "OnboardingWebURL";
        #endregion O Values

        #region P Values
        public const string PasswordStrength = "passwordstrength";
        public const string PermittedIPs = "PermittedIPs";
        public const string PermittedLogonIDs = "PermittedLogonIDs";
        #endregion P Values

        #region R Values
        public const string RestrictLogon = "RestrictLogon";
        #endregion R Values

        #region S Values
        public const string SendiBankCustomerRegistrationNotification = "SendiBankCustomerRegistrationNotification";
        public const string SendOTPAtLogon = "SendOTPAtLogon";
        public const string ShuftiProAPIURL = "ShuftiProAPI_BaseURL";
        public const string ShuftiProAPIUsername = "ShuftiProAPI_Username";
        public const string ShuftiProAPIPassword = "ShuftiProAPI_Password";
        public const string ShuftiProAPIAllowFace = "ShuftiProAPI_AllowFace";
        public const string ShuftiProAPIAllowOffline = "ShuftiProAPI_AllowOffline";
        public const string ShuftiProAPIAllowOnline = "ShuftiProAPI_AllowOnline";
        public const string ShuftiProAPIExpireTime = "ShuftiProAPI_ExpireTime";
        #endregion S Values

        #region T Values
        public const string TokenLifeCircle = "TokenLifeCircle";

        public const string TokenSaleOpenAPIURL = "TokenSaleOpenAPI_BaseURL";
        public const string TokenSaleOpenAPIUsername = "TokenSaleOpenAPI_Username";
        public const string TokenSaleOpenAPIPassword = "TokenSaleOpenAPI_Password";

        public const string TwilioSid = "Twilio_Sid";
        public const string TwilioToken = "Twilio_Token";
        public const string TwilioFrom = "Twilio_From";
        #endregion T Values

        
    }
}
