using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.GroupMaintenance;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Models;

public partial class FakeData
{
    public static List<GroupInfoModel> Groups = new List<GroupInfoModel>()
    {
        new GroupInfoModel()
        {
            ID = 1,
            Name = "Developers",
            Description = "Users who work with system developing",
            TotalMembers = 26
        },
        new GroupInfoModel()
        {
            ID = 2,
            Name = "Sales & Marketing",
            Description = "The group has the responsibility for deciding where the company should s...",
            TotalMembers = 18
        },
        new GroupInfoModel()
        {
            ID = 3,
            Name = "Marketing",
            Description = "A co-operative, consortium, franchise or other profit-motivated grouping o...",
            TotalMembers = 12
        },
        new GroupInfoModel()
        {
            ID = 4,
            Name = "Executive",
            Description = "An executive chairman of the company and the closest employees",
            TotalMembers = 4
        },
        new GroupInfoModel()
        {
            ID = 5,
            Name = "Procurement / Purchasing",
            Description = "All members of the Procurement and Purchasing departments",
            TotalMembers = 41
        },
        new GroupInfoModel()
        {
            ID = 6,
            Name = "Housekeeping",
            Description = "Housekeeping supervisor, manager or inspector",
            TotalMembers = 28
        },
        new GroupInfoModel()
        {
            ID = 7,
            Name = "Accounting",
            Description = "All members of the department who are responsible for identifying, trackin...",
            TotalMembers = 34
        },
        new GroupInfoModel()
        {
            ID = 8,
            Name = "Food & Beverage",
            Description = "Restaurant manager/supervisor, receptionist, head waiter",
            TotalMembers = 15
        },
        new GroupInfoModel()
        {
            ID = 9,
            Name = "Security",
            Description = "All members of the security department",
            TotalMembers = 3
        }
    };

    public static GroupMaintenanceModel GroupMaintenance = new GroupMaintenanceModel()
    {
        Groups = new List<GroupInfoModel>()
        {
            new GroupInfoModel()
            {
                ID = 1,
                Name = "Developers",
                Description = "Users who work with system developing",
                TotalMembers = 0
            },
            new GroupInfoModel()
            {
                ID = 2,
                Name = "Sales & Marketing",
                Description = "The group has the responsibility for deciding where the company should s...",
                TotalMembers = 0
            },
            new GroupInfoModel()
            {
                ID = 3,
                Name = "Marketing",
                Description = "A co-operative, consortium, franchise or other profit-motivated grouping o...",
                GroupMembers = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 84008402,
                        UserName = "Lindsey Mango",
                        Role = "Relationship Staff",
                        FirstName = "Lindsey",
                        LastName = "Mango",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "lindsey.mango@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/sign/avatar1.svg",
                        LastLoggedin = string.Empty,
                        GroupID = 3,
                        NotificationSettings = new()
                        {
                            InformTransactionsSMS = true,
                            InformTransactionsEmail = true,
                            InformTransactionsiMail = true,

                            InformNewBankServicesSMS = false,
                            InformNewBankServicesEmail = false,
                            InformNewBankServicesiMail = false,

                            InformMessagesFromManageriMail = true,
                            InformMessagesFromManagerSMS = true,
                            InformMessagesFromManagerEmail = true,
                        },
                        SecuritySetting = SecurityFactorEnum.OneFactor,
                        ActionStatus = UserActionStatusEnum.AwaitingSignoff,
                        DevicesActiveSessions = new()
                        {
                            new DevicesActiveSessionModel()
                            {
                                DeviceID = 1,
                                DeviceName = "Personal computer",
                                OperationSystem = "OS X 10.15.7",
                                IPAddress = "10.15.779.110.129.198",
                                Note =
                                    "Authorization in the app on this device. You can log out of all devices except the current one."
                            },
                            new DevicesActiveSessionModel()
                            {
                                DeviceID = 2,
                                DeviceName = "iPhone 8 Plus",
                                OperationSystem = "IOS 14.6",
                                IPAddress = "79.110.129.198",
                                Note = "Today 14:41"
                            }
                        }
                    },
                },
                TotalMembers = 1
            },
            new GroupInfoModel()
            {
                ID = 4,
                Name = "Executive",
                Description = "An executive chairman of the company and the closest employees",
                GroupMembers = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 84028490,
                        UserName = "Marley Passaquindici Arcand",
                        Role = "Relationship Staff",
                        FirstName = "Marley",
                        MiddleName = "Passaquindici",
                        LastName = "Arcand",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "marley.arcand@gmail.com",
                        PhoneNumberIDD = "",
                        PhoneNumber = "",
                        AvartaUrl = "/img/sign/avatar2.svg",
                        LastLoggedin = string.Empty,
                        GroupID = 4,
                        NotificationSettings = new()
                        {
                            InformTransactionsSMS = true,
                            InformTransactionsEmail = true,
                            InformTransactionsiMail = true,

                            InformNewBankServicesSMS = false,
                            InformNewBankServicesEmail = false,
                            InformNewBankServicesiMail = false,

                            InformMessagesFromManageriMail = true,
                            InformMessagesFromManagerSMS = true,
                            InformMessagesFromManagerEmail = true,
                        },
                        SecuritySetting = SecurityFactorEnum.OneFactor,
                        ActionStatus = UserActionStatusEnum.Confirmed,
                        DevicesActiveSessions = new()
                        {
                            new DevicesActiveSessionModel()
                            {
                                DeviceID = 1,
                                DeviceName = "Personal computer",
                                OperationSystem = "OS X 10.15.7",
                                IPAddress = "10.15.779.110.129.198",
                                Note =
                                    "Authorization in the app on this device. You can log out of all devices except the current one."
                            },
                            new DevicesActiveSessionModel()
                            {
                                DeviceID = 2,
                                DeviceName = "iPhone 8 Plus",
                                OperationSystem = "IOS 14.6",
                                IPAddress = "79.110.129.198",
                                Note = "Today 14:41"
                            }
                        }
                    },
                },
                TotalMembers = 1
            },
            new GroupInfoModel()
            {
                ID = 5,
                Name = "Procurement / Purchasing",
                Description = "All members of the Procurement and Purchasing departments",
                TotalMembers = 0
            },
            new GroupInfoModel()
            {
                ID = 6,
                Name = "Housekeeping",
                Description = "Housekeeping supervisor, manager or inspector",
                TotalMembers = 0
            },
            new GroupInfoModel()
            {
                ID = 7,
                Name = "Accounting",
                Description = "All members of the department who are responsible for identifying, trackin...",
                GroupMembers = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 84028492,
                        UserName = "Leo Baptista",
                        Role = "Relationship Staff",
                        FirstName = "Leo",
                        LastName = "Baptista",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "leo.baptista@gmail.com",
                        PhoneNumberIDD = "",
                        PhoneNumber = "",
                        AvartaUrl = "/img/sign/avatar8.svg",
                        LastLoggedin = "18 June 2021 at 16:20:31",
                        GroupID = 7,
                        NotificationSettings = new()
                        {
                            InformTransactionsSMS = true,
                            InformTransactionsEmail = true,
                            InformTransactionsiMail = true,

                            InformNewBankServicesSMS = false,
                            InformNewBankServicesEmail = false,
                            InformNewBankServicesiMail = false,

                            InformMessagesFromManageriMail = true,
                            InformMessagesFromManagerSMS = true,
                            InformMessagesFromManagerEmail = true,
                        },
                        SecuritySetting = SecurityFactorEnum.OneFactor,
                        ActionStatus = UserActionStatusEnum.Confirmed,
                        DevicesActiveSessions = new()
                        {
                            new DevicesActiveSessionModel()
                            {
                                DeviceID = 1,
                                DeviceName = "Personal computer",
                                OperationSystem = "OS X 10.15.7",
                                IPAddress = "10.15.779.110.129.198",
                                Note =
                                    "Authorization in the app on this device. You can log out of all devices except the current one."
                            },
                            new DevicesActiveSessionModel()
                            {
                                DeviceID = 2,
                                DeviceName = "iPhone 8 Plus",
                                OperationSystem = "IOS 14.6",
                                IPAddress = "79.110.129.198",
                                Note = "Today 14:41"
                            }
                        }
                    }
                },
                TotalMembers = 1
            },
            new GroupInfoModel()
            {
                ID = 8,
                Name = "Food & Beverage",
                Description = "Restaurant manager/supervisor, receptionist, head waiter",
                TotalMembers = 0
            },
            new GroupInfoModel()
            {
                ID = 9,
                Name = "Security",
                Description = "All members of the security department",
                TotalMembers = 0
            }
        },
        TotalRecords = 9
    };
}
