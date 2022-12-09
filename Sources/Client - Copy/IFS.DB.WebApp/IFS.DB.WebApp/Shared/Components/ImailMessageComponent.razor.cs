using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.iMails;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ImailMessageComponent
{
    [Parameter] public IMailMessageModel iMailMessageItem { get; set; }
    [Parameter] public EventCallback<IMailMessageModel> OnDeleteiMailMessageItem { get; set; }
    [Parameter] public EventCallback<IMailMessageModel> OnAnsweriMailMessageItem { get; set; }

    private int AuthenticatedUserID = FakeData.AuthorisedUserID;

    private async Task DeleteiMailMessage(IMailMessageModel imailMessageItem)
    {
        await OnDeleteiMailMessageItem.InvokeAsync(imailMessageItem);
    }

    private async Task AnsweriMailMessage(IMailMessageModel imailMessageItem)
    {
        await OnAnsweriMailMessageItem.InvokeAsync(imailMessageItem);
    }
}
