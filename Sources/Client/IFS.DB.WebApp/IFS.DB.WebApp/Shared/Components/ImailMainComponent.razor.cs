using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.iMails;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ImailMainComponent
{
    private int _AuthenticatedUserID = FakeData.AuthorisedUserID;
    [Parameter] public EventCallback<IMailMessageModel> GetSelectediMailCallback { get; set; }

    private List<IMailMessageModel> _listiMailMessages;
    protected override async Task OnInitializedAsync()
    {
        _listiMailMessages = FakeData.iMailMessages;
    }

    private async Task AnsweriMail_Clicked(IMailMessageModel imailMessage)
    {
        await GetSelectediMailCallback.InvokeAsync(imailMessage);
    }

    private async Task DeleteiMail_Clicked(IMailMessageModel imailMessage)
    {
        _listiMailMessages.Remove(imailMessage);
    }

    public async Task AddNewiMailMessageAsync(IMailMessageModel edittediMailMessage)
    {
        _listiMailMessages.Add(edittediMailMessage);
        _listiMailMessages = _listiMailMessages.OrderBy(x => x.CreatedDate).ToList();

        StateHasChanged();
    }

    public async Task AmendiMailMessageAsync(AnswerIMailMessageModel answeriMailMessage)
    {
        _listiMailMessages.ForEach(x => 
        {
            if(x.MailID == answeriMailMessage.MailID)
            {
                x.AnswerIMailMessages.Add(answeriMailMessage);
            }
        });
    }
}
