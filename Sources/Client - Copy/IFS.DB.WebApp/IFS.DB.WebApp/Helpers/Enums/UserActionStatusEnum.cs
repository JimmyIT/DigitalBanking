using System.ComponentModel;

namespace IFS.DB.WebApp.Helpers.Enums;

public enum UserActionStatusEnum
{
    [Description("Awaiting Sign-off")]
    AwaitingSignoff = 0, 
    [Description("Live")]
    Confirmed = 1, 
    [Description("Rejected")]
    Rejected = 2,
    [Description("Locked")]
    Locked = 3,
}

public enum UsePaymentPreferenceEnum
{
    [Description("Authorise Payments In Bulk")]
    AuthoriseInBulk = 0,
    [Description("User is allowed to make external payments.")]
    AllowedExternalPayments = 1,
    [Description("User is allowed to make cross currency payments.")]
    AllowedCrossCurrencyPayments = 2,
    [Description("User can release payments.")]
    CanReleasePayments = 3,
    [Description("Can upload payment files.")]
    CanUploadPaymentsFile = 4,
}

public enum UseTransferPreferenceEnum
{
    [Description("Allow transfer to non internet enabled account")]
    AuthoriseInBulk = 0,
    [Description("User can release transfers")]
    AllowedExternalPayments = 1,
    [Description("Can upload transfer files")]
    AllowedCrossCurrencyPayments = 2,
}

public enum CustomerAccessEnum
{
    [Description("User can create customer template")]
    CanCreateCustomerTemplate = 0,
    [Description("User can sign own customer template")]
    CanSignOwnCustomerTemplate = 1,
}

public enum UserAccessLevelEnum
{
    [Description("Simple User")]
    Simple = 0,
}

public enum LevelOfUserEnum
{
    [Description("A")]
    A = 0,
    [Description("B")]
    B = 1,
    [Description("C")]
    C = 2,
}