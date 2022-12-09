using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Enums
{
    public enum OpenAPIMessageStatusEnum
    {
        New = 1,
        Success = 2,
        Failed = 3
    }

    public enum OpenAPIUserStatusEnum
    {
        Active = 1,
        Blocked = 2
    }

    public enum IDTypeEnum
    {
        Passport = 0,
        IDNumber = 1
    }

    public enum GenderEnum
    {
        [Description("Female")]
        F = 0,
        [Description("Male")]
        M = 1,
        [Description("Unisex")]
        U = 2,
    }

    public enum TitleEnum
    {
        [Description("Mr.")]
        Mr = 0,
        [Description("Mrs.")]
        Mrs = 1,
        [Description("Ms.")]
        Ms = 2,
        [Description("Miss")]
        Miss = 3,
        [Description("Dr.")]
        Dr = 4,
    }

    public enum ClientTypeEnum
    {
        [Description("Individual")]
        Individual =  0,
        [Description("Corporate")]
        Corporate = 1,
        [Description("Bank")]
        Bank = 2
    }

    public enum AccountApplicationStatusEnum
    {
        [Description("Create New")]
        CreateNew = 0,
        [Description("First Time Sent")]
        FirstTimeSent = 1,
        [Description("Email Resent")]
        EmailResent = 2,
        [Description("Link Expired")]
        LinkExpired = 3,
        [Description("Create Client In BWAPI")]
        CreateClientInBWAPI = 4,
        [Description("Fail Create Client In BWAPI")]
        FailCreateClientInBWAPI = 5,
        [Description("Create Account In BWAPI")]
        CreateAccountInBWAPI = 6,
        [Description("Fail Create Account In BWAPI")]
        FailCreateAccountInBWAPI = 7,
        [Description("Create Card In Card API")]
        CreateCardInCardAPI = 8,
        [Description("Fail Create Card In Card API")]
        FailCreateCardInCardAPI = 9,
        [Description("Create Client In IBank API")]
        CreateClientInIBankAPI = 10,
        [Description("Fail Create Client In IBank API")]
        FailCreateClientInIBankAPI = 11,
        [Description("Create Account In IBank API")]
        CreateAccountInIBankAPI = 12,
        [Description("Fail Create Account In IBank API")]
        FailCreateAccountInIBankAPI = 13,
        [Description("Create SSE In IBank API")]
        CreateSSEInIBankAPI = 14,
        [Description("Fail Create SSE In IBank API")]
        FailCreateSSEInIBankAPI = 15,
        [Description("Update Online Banking In BWAPI")]
        UpdateOnlineBankingInBWAPI = 16,
        [Description("Fail Update Online Banking In BWAPI")]
        FailUpdateOnlineBankingInBWAPI = 17,
        [Description("Proceed")]
        Proceed = 18,
        [Description("Fail Update Profile")]
        FailUpdateProfile = 19,
        [Description("Reset Card PIN")]
        ResetCardPIN = 20,
        [Description("Reset Card Security Number")]
        ResetSecurityNumber = 21,
        [Description("Create Data In AMLTrac")]
        CreateDataInAMLTrac = 22,
        [Description("Fail Create Data In AMLTrac")]
        FailCreateDataInAMLTrac = 23,
        [Description("Waiting AMLTrac Response KYC")]
        WaitingAMLTracResponseKYC = 24,
        [Description("AMLTrac KYC Approved")]
        AMLTracKYCApproved = 25,
        [Description("AMLTrac KYC Rejected")]
        AMLTracKYCRejected = 26,
        [Description("Fail Get Client From AMLTrac")]
        FailGetClientFromAMLTrac = 27,
        [Description("Reset Password")]
        ResetPassword = 28,
        [Description("Send Application Accepted Email")]
        SendApplicationAcceptedEmail = 29,
        [Description("Fail Send Application Accepted Email")]
        FailSendApplicationAcceptedEmail = 30,
        [Description("Waiting Create Customer")]
        WaitingCreateCustomer = 31,
        [Description("Upload Document AML")]
        UploadDocumentAML = 32,
        [Description("Fail Upload Document AML")]
        FailUploadDocumentAML = 33,
        [Description("Notify Tag Client Approved")]
        NotifyTagClientApproved = 34,
        [Description("Fail Notify Tag Client Approved")]
        FailNotifyTagClientApproved = 35,
        [Description("Notify Tag Client Rejected")]
        NotifyTagClientRejected = 36,
        [Description("Fail Notify Tag Client Rejected")]
        FailNotifyTagClientRejected = 37,
        [Description("Send Application Accepted SMS")]
        SendApplicationAcceptedSMS = 38,
        [Description("Fail Send Application Accepted SMS")]
        FailSendApplicationAcceptedSMS = 39,
        [Description("Send Application Accepted Notification")]
        SendApplicationAcceptedNotification = 40,
        [Description("Fail Send Application Accepted Notification")]
        FailSendApplicationAcceptedNotification = 41,
        [Description("Move To Data Capture in AMLtrac")]
        MoveToDataCaptureInAMLtrac = 42,
        [Description("Fail Move To Data Capture In AMLtrac")]
        FailMoveToDataCaptureInAMLtrac = 43,
        [Description("Move To Risk Review In AMLtrac")]
        MoveToRiskReviewInAMLtrac = 44,
        [Description("Fail Move To Risk Review In AMLtrac")]
        FailMoveToRiskReviewInAMLtrac = 45,
        [Description("Auto Approve KYC In AMLtrac")]
        AutoApproveKYCInAMLTrac = 46,
        [Description("Fail Auto Approve KYC In AMLtrac")]
        FailAutoApproveKYCInAMLTrac = 47,
        [Description("Extend Required Documents")]
        ExtendRequiredDocuments = 48,
        [Description("Waiting Transaction Confirm")]
        WaitingTransactionConfirm = 49
    }

    public enum ProductCodeEnum
    {
        AccountViewing = 1000,
        Transfers = 1010,
        Payments = 5420,
        Templates = 5410,
        BatchPayments = 5419
    }

    public enum UserProfileStatusEnum
    {
        PARTIALLYAUTHORISED = 20,
        PENDING = 40,
        LIVE = 60,
        DELETED = 50,
    }

    public enum OnboardingProductionEnum
    {
        Default = 0,
        KYC = 1,
        Email = 2,
        Tag = 3
    }

    public enum NotificationTypeEnum
    {
        Both = 0,
        Email = 1,
        SMS = 2
    }

    public enum TwoFactorAuthTypeEnum
    {
        None = 0,
        Email = 1,
        SMS = 2,
        Both = 3
    }
}
