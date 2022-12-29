using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.iMails;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ImailMessageComponent
{
    [Parameter] public IMailMessageModel iMailMessageItem { get; set; }
    [Parameter] public EventCallback<IMailMessageModel> OnDeleteiMailMessageItem { get; set; }
    [Parameter] public EventCallback<IMailMessageModel> OnAnsweriMailMessageItem { get; set; }

    private List<UserInfoModel> _userInfos = FakeData.UserInfos;
    private int AuthenticatedUserID = FakeData.AuthorisedUserID;
    private bool _isActiveAnswerMsgs = false;
    private bool _hasAnswerMsgs => iMailMessageItem.AnswerIMailMessages.Count > 0;
    private int _totalAnswerMsgs => iMailMessageItem.AnswerIMailMessages.Count();

    private async Task DeleteiMailMessage(IMailMessageModel imailMessageItem)
    {
        await OnDeleteiMailMessageItem.InvokeAsync(imailMessageItem);
    }

    private async Task AnsweriMailMessage(IMailMessageModel imailMessageItem)
    {
        await OnAnsweriMailMessageItem.InvokeAsync(imailMessageItem);
    }
}
