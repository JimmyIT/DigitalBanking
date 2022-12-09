using IFS.DB.WebApp.Models.Security;

namespace IFS.DB.WebApp.Models;

public partial class FakeData
{
    public static MseAuthorityCodeModel? MseAuthorityCode = new MseAuthorityCodeModel
    {
        AuthorityCode = "12345678910",
        Status = MseAuthorityCodeStatus.WaitingReview,
        LastAccessOn = new DateTime(2022, 10, 29, 10, 37, 0),
    };

    public static List<PasswordBatchModel> PasswordBatches = new List<PasswordBatchModel>
    {
        new()
        {
            Id = 1,
            UserReference = "[User reference 1]",
            Status = PasswordBatchStatus.Locked,
            LastProcessOn = new DateTime(2022, 11, 8, 10, 36, 00),
            LassAccessBy = "Admin 1"
        },
        new()
        {
            Id = 2,
            UserReference = "[User reference 2]",
            Status = PasswordBatchStatus.Locked,
            LastProcessOn = new DateTime(2022, 11, 8, 10, 36, 00),
            LassAccessBy = "Admin 1"
        },
        new()
        {
            Id = 3,
            UserReference = "[User reference 3]",
            Status = PasswordBatchStatus.Locked,
            LastProcessOn = new DateTime(2022, 11, 8, 10, 36, 00),
            LassAccessBy = "Admin 1"
        },
        new()
        {
            Id = 4,
            UserReference = "[User reference 4]",
            Status = PasswordBatchStatus.Unlocked,
            LastProcessOn = new DateTime(2022, 11, 8, 10, 36, 00),
            LassAccessBy = "Admin 1"
        },
    };
}