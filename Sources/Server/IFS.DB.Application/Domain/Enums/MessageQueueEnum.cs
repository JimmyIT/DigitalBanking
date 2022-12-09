using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Enums
{
    public enum MessageTypeEnum
    {
        Clients = 0,
        Accounts = 1,
        Statements = 2,
        ExchangeRates = 3,
        Holidays = 4,
        Currencies = 5,
        Teams = 6,
        AccountManagers = 7,
        Transfer = 8,
        SWIFTTemplate = 9,
        BACSTemplate = 10,
        SWIFTPayment = 11,
        BACSPayment = 12,
        SystemInformation = 13,
        IBankCustomerLock = 14,
        IBCOverNightEnd = 15,
        IBCSystemDate = 16,
        IBankCustomerUnlock = 17,
        Undefined = 18,
        IBCOverNightStarted = 19,
        SWIFTInbound = 20,
        BatchPayment = 21,
        FFSWIFTPayment = 22,
        FFDomesticPayment = 23,
        WireTransfer = 24,
        ACHPayment = 25,
        FireEventNotification = 26,
        TouristCard = 27,
        LloydsLoadRequest = 28,
        LloydsLoadResponse = 29,
        [Description("CAPI Load")]
        CAPILoadRequest = 30,
        CAPILoadResponse = 31,
        [Description("CAPI PreUnLoad")]
        CAPIPreUnLoadRequest = 32,
        CAPIPreUnLoadResponse = 33,
        LloydsUnLoadRequest = 34,
        LloydsUnLoadResponse = 35,
        [Description("CAPI UnLoad")]
        CAPIUnLoadRequest = 36,
        CAPIUnLoadResponse = 37,
        LloydsProcessed = 38,
        CAPIFailPreUnloadBalanceRequest = 39,
        CAPIFailPreUnloadBalanceResponse = 40,
        CAPIRegisterPaymentCardRequest = 41,
        CAPIRegisterPaymentCardResponse = 42,
        CAPICancelPreUnLoadBalanceRequest = 43,
        CAPICancelPreUnLoadBalanceResponse = 44,
        LloydsDeleteDataRequest = 45,
        LloydsDeleteDataResponse = 46,
        CAPIRemovePaymentCardRequest = 47,
        CAPIRemovePaymentCardResponse = 48,
        CAPIUpdatePaymentCardRequest = 49,
        CAPIUpdatePaymentCardResponse = 50,
        OnBoarding = 51
    }

    public enum MQMessageStatusEnum
    {
        Pending = 1,
        Failed = 2,
        Success = 3,
        Hold = 5
    }

    public enum MQUserActionTypeEnum
    {
        Created = 1,
        Processed = 2,
        Delete = 3,
        Ignore = 4,
        Continue = 5
    }
}
