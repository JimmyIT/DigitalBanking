using IFS.DB.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Data
{
    public interface IParameterService
    {
        #region A Values
        Task<int> GetAccountApplicationClearDownTimeAsync();

        Task<string> GetAMLApprovedModeAsync();

        Task<string> GetAMLtracHostIdAsync();
        Task<string> GetAMLtracBranchCodeAsync();

        Task<string> GetAMLtracOpenAPIURLAsync();
        Task<string> GetAMLtracOpenAPIUsernameAsync();
        Task<string> GetAMLtracOpenAPIPasswordAsync();
        Task<string> GetAMLtracOpenAPICertThumbPrintAsync();

        Task<int> GetApplicationEmailLinkExpiryTimeAsync();
        #endregion A Values

        #region B Values
        Task<string> GetBWSystemIdAsync();

        Task<string> GetBWHostIdAsync();

        Task<string> GetBWOpenAPIURLAsync();
        Task<string> GetBWOpenAPIUsernameAsync();
        Task<string> GetBWOpenAPIPasswordAsync();
        Task<string> GetBWOpenAPICertThumbPrintAsync();
        #endregion B Values

        #region C Values
        Task<string> GetCardAPIURLAsync();
        Task<string> GetCardAPIUsernameAsync();
        Task<string> GetCardAPIPasswordAsync();
        Task<string> GetCardAPICertThumbPrintAsync();

        Task<string> GetClientTemplateForOnBoardingAsync();
        Task<string> GetCOAForOnBoardingAsync();
        Task<string> GetCurrencyForOnBoardingAsync();

        Task<string> GetClientTemplateForTouristCardAsync();
        Task<string> GetCOAForTouristCardAsync();
        Task<string> GetCurrencyForTouristCardAsync();
        #endregion C Values

        #region D Values
        Task<string> GetDefaultLanguageAsync();
        Task<string> GetDocumentUploadFolderAsync();
        Task<long> GetDocumentSizeLimitAsync();
        #endregion D Values

        #region E Values
        Task<bool> GetEnableCardFeatureAsync();
        #endregion E Values

        #region H Values
        Task<byte> GetHBProcessMQMaxRetryAsync();
        #endregion H Values

        #region I Values
        Task<string> GetInitVectorAsync();
        #endregion

        #region L Values
        Task<string> GetLloydAPIUrlAsync();
        Task<string> GetLloydUsernameAsync();
        Task<string> GetLloydPasswordAsync();
        Task<string> GetLloydStoreIdAsync();
        Task<string> GetLloydCertificatePwdAsync();
        #endregion L Values

        #region M Values
        Task<int> GetMailPortAsync();
        Task<string> GetMailUsernameAsync();
        Task<string> GetMailPasswordAsync();
        Task<bool> GetMailEnableSslAsync();
        #endregion M Values

        #region O Values
        Task<OnboardingProductionEnum> GetOnboardingProductionAsync();
        Task<string> GetOnboardingWebURLAsync();
        #endregion O Values

        #region P Values
        Task<string> GetPasswordStrengthAsync();
        Task<string> GetPermittedIPsAsync();
        Task<string> GetPermittedLogonIDsAsync();
        #endregion P Values

        #region R Values
        Task<bool> GetRestrictLogonAsync();
        #endregion R Values

        #region S Values
        Task<bool> GetSendiBankCustomerRegistrationNotificationAsync();
        Task<string> GetShuftiProAPIURLAsync();
        Task<string> GetShuftiProAPIUsernameAsync();
        Task<string> GetShuftiProAPIPasswordAsync();
        Task<bool> GetShuftiProAPIAllowFaceAsync();
        Task<bool> GetShuftiProAPIAllowOfflineAsync();
        Task<bool> GetShuftiProAPIAllowOnlineAsync();
        Task<int> GetShuftiProAPIExpireTimeAsync();
        #endregion S Values

        #region T Values
        Task<int> GetTokenLifeCirleAsync();

        Task<string> GetTokenSaleOpenAPIURLAsync();
        Task<string> GetTokenSaleOpenAPIUsernameAsync();
        Task<string> GetTokenSaleOpenAPIPasswordAsync();

        Task<string> GetTwilioSidAsync();
        Task<string> GetTwilioTokenAsync();
        Task<string> GetTwilioFromAsync();
        #endregion T Values
    }
}
