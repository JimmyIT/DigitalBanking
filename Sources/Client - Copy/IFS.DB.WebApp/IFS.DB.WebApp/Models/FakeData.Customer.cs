using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Account;
using IFS.DB.WebApp.Models.Customer;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Models;

public partial class FakeData
{
    public static CustomerInfoModel HostCustomerInfo = new CustomerInfoModel()
    {
        ID = 1,
        CustomerID = "Host_User",
        AuthenticateCode = "",
        Password = "",
        SecurityCode = "",
        IsHost = true,
        Type = CustomerTypeEnum.MSE,
        Users = new List<UserInfoModel>()
        {
            new UserInfoModel()
            {
                UserID = 2,
                UserName = "Jane Watson",
                Role = "Relationship Staff",
                FirstName = "Jane",
                LastName = "Watson",
                DateOfBirth = new DateTime(1995, 04, 28),
                Email = "jane.watson@gmail.com",
                PhoneNumberIDD = "+44",
                PhoneNumber = "555 753 654",
                AvartaUrl = "/img/header/jane-watson.png",
            }
        }
    };

    public static List<CustomerInfoModel> ListHostCustomers = new List<CustomerInfoModel>()
    {
        new CustomerInfoModel()
        {
            ID = 1,
            CustomerID = "Host_User",
            AuthenticateCode = "",
            Password = "",
            SecurityCode = "",
            Address = "",
            IsHost = true,
            Type = CustomerTypeEnum.MSE,
            Users = new List<UserInfoModel>()
            {
                new UserInfoModel()
                {
                    UserID = 2,
                    UserName = "Jane Watson",
                    Role = "Relationship Staff",
                    FirstName = "Jane",
                    LastName = "Watson",
                    DateOfBirth = new DateTime(1995, 04, 28),
                    Email = "jane.watson@gmail.com",
                    PhoneNumberIDD = "+44",
                    PhoneNumber = "555 753 654",
                    AvartaUrl = "/img/header/jane-watson.png",
                }
            },
            Accounts = new List<AccountModel>()
            {
                new AccountModel
                {
                    AccountNumber = "00000077",
                    AccountDescription = "ABC - 12345678",
                    ClientNumber = "00017",
                    CurrencyCode = "GBP",
                    CurrentBalance = -999999999.00M,
                    AvailableBalance = -999999999.00M,
                    OverdraftLimit = 0.000M,
                    IsFavourite = true
                },
                new AccountModel
                {
                    AccountNumber = "10023002",
                    AccountDescription = "Interest Bearing ACC (Profile)",
                    ClientNumber = "00065",
                    CurrencyCode = "GBP",
                    CurrentBalance = 133455975.000M,
                    AvailableBalance = 133455975.000M,
                    OverdraftLimit = 0.000M,
                    IsFavourite = true
                },
                new AccountModel
                {
                    AccountNumber = "00000075",
                    AccountDescription = "Bank Client Monies - NIB",
                    ClientNumber = "00070",
                    CurrencyCode = "GBP",
                    CurrentBalance = 100001000.000M,
                    AvailableBalance = 100001000.000M,
                    OverdraftLimit = 0.000M,
                    IsFavourite = false
                },
            }
        }

    };

    public static CustomerMaintenanceModel CustomerMaintenance = new CustomerMaintenanceModel()
    {
        Customers = new List<CustomerInfoModel>()
        {
            new CustomerInfoModel()
            {
                ID = 2,
                CustomerID = "IBM",
                CustomerName = "IBM",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "2118 Thornridge Cir. Syracuse, Connecticut 35624",
                IsHost = false,
                Type = CustomerTypeEnum.MSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 3,
                CustomerID = "eBay",
                CustomerName = "eBay",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "2972 Westheimer Rd. Santa Ana, Illinois 85486",
                IsHost = false,
                Type = CustomerTypeEnum.MSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 4,
                CustomerID = "Nintendo",
                CustomerName = "Nintendo",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "2715 Ash Dr. San Jose, South Dakota 83475",
                IsHost = false,
                Type = CustomerTypeEnum.MSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 5,
                CustomerID = "WaltDisney",
                CustomerName = "The Walt Disney Company",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "2715 Ash Dr. San Jose, South Dakota 83475",
                IsHost = false,
                Type = CustomerTypeEnum.MSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 6,
                CustomerID = "Mitsubishi",
                CustomerName = "Mitsubishi",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "2715 Ash Dr. San Jose, South Dakota 83475",
                IsHost = false,
                Type = CustomerTypeEnum.SSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 7,
                CustomerID = "MasterCard",
                CustomerName = "MasterCard",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "3891 Ranchview Dr. Richardson, California 62639",
                IsHost = false,
                Type = CustomerTypeEnum.SSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 8,
                CustomerID = "Johnson",
                CustomerName = "Johnson & Johnson	",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "4517 Washington Ave. Manchester, Kentucky 39495",
                IsHost = false,
                Type = CustomerTypeEnum.MSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
            new CustomerInfoModel()
            {
                ID = 9,
                CustomerID = "LOreal",
                CustomerName = "L'Oréal",
                AuthenticateCode = "",
                Password = "",
                SecurityCode = "",
                Address = "1901 Thornridge Cir. Shiloh, Hawaii 81063	",
                IsHost = false,
                Type = CustomerTypeEnum.MSE,
                Users = new List<UserInfoModel>()
                {
                    new UserInfoModel()
                    {
                        UserID = 2,
                        UserName = "Jane Watson",
                        Role = "Relationship Staff",
                        FirstName = "Jane",
                        LastName = "Watson",
                        DateOfBirth = new DateTime(1995, 04, 28),
                        Email = "jane.watson@gmail.com",
                        PhoneNumberIDD = "+44",
                        PhoneNumber = "555 753 654",
                        AvartaUrl = "/img/header/jane-watson.png",
                    }
                },
                Accounts = new List<AccountModel>()
                {
                    new AccountModel
                    {
                        AccountNumber = "00000077",
                        AccountDescription = "ABC - 12345678",
                        ClientNumber = "00017",
                        CurrencyCode = "GBP",
                        CurrentBalance = -999999999.00M,
                        AvailableBalance = -999999999.00M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "10023002",
                        AccountDescription = "Interest Bearing ACC (Profile)",
                        ClientNumber = "00065",
                        CurrencyCode = "GBP",
                        CurrentBalance = 133455975.000M,
                        AvailableBalance = 133455975.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = true
                    },
                    new AccountModel
                    {
                        AccountNumber = "00000075",
                        AccountDescription = "Bank Client Monies - NIB",
                        ClientNumber = "00070",
                        CurrencyCode = "GBP",
                        CurrentBalance = 100001000.000M,
                        AvailableBalance = 100001000.000M,
                        OverdraftLimit = 0.000M,
                        IsFavourite = false
                    },
                }
            },
        },
        TotalRecords = 8
    };
}
