using IFS.DB.WebApp.Models.Account;
using IFS.DB.WebApp.Models.Permission;
using IFS.DB.WebApp.Models.Users;

namespace IFS.DB.WebApp.Models;

public static partial class FakeData
{
    public static GroupPermissionModel GroupDeveloper = new GroupPermissionModel
    {
        Id = 1,
        Name = "Developer"
    };

    public static GroupPermissionModel GroupHrAdmin = new GroupPermissionModel
    {
        Id = 2,
        Name = "HR Admins"
    };

    public static GroupPermissionModel GroupSale = new GroupPermissionModel
    {
        Id = 3,
        Name = "Sale"
    };

    public static List<UserPermissionModel> UserPermissions = new List<UserPermissionModel>
    {
        new()
        {
            Id = 1,
            User = new UserInfoBrief()
            {
                Name = "Eleanor Pena",
                AvatarUrl = "/img/userTable/avatar.svg",
            },
            Group = GroupSale,
            IsFollowGroup = true
        },
        new()
        {
            Id = 2,
            User = new UserInfoBrief()
            {
                Name = "Alfredo Culhane",
                AvatarUrl = "/img/userTable/avatar.svg"
            },
            Group = GroupDeveloper
        },
        new()
        {
            Id = 3,
            User = new UserInfoBrief()
            {
                Name = "Darrell Steward",
                AvatarUrl = "/img/userTable/avatar.svg"
            },
            Group = GroupSale
        },
        new()
        {
            Id = 4,
            User = new UserInfoBrief()
            {
                Name = "Darlene Robertson",
                AvatarUrl = "/img/userTable/avatar.svg"
            },
            Group = GroupDeveloper
        },
        new()
        {
            Id = 5,
            User = new UserInfoBrief()
            {
                Name = "Robert Fox",
                AvatarUrl = "/img/userTable/avatar.svg"
            },
            Group = GroupHrAdmin
        },
        new()
        {
            Id = 6,
            User = new UserInfoBrief()
            {
                Name = "Annette Black",
                AvatarUrl = "/img/userTable/avatar.svg"
            },
            Group = GroupSale
        },
    };

    public static List<GroupPermissionModel> GroupPermissions = new List<GroupPermissionModel>
    {
        GroupDeveloper,
        GroupHrAdmin,
        GroupSale
    };

    public static List<AccountBriefModal> CorporateAccounts = new List<AccountBriefModal>()
    {
        new()
        {
            AccountNumber = "00257020",
            AccountDescription = "Customer Fixed Loans"
        },
        new()
        {
            AccountNumber = "00257001",
            AccountDescription = "Bank Operational Account"
        },
        new()
        {
            AccountNumber = "00257002",
            AccountDescription = "Bank Operational Account"
        }
    };

}