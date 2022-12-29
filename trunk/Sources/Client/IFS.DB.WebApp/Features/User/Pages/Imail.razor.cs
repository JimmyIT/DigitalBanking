using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.iMails;
using IFS.DB.WebApp.Models.Users;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Features.User.Pages;

public partial class Imail
{
    [CascadingParameter] IModalService iMailModalSvc { get; set; } = default!;
    [Parameter] public string SelectedTabPage { get; set; }

    private ImailMainComponent _imailMainComponent;
    private ImailSidebarComponent _imailSidebarComponent;
    public IMailTabPageEnum _selectedTabPage = IMailTabPageEnum.UnreadMails;
    private List<UserInfoModel> _listUsers;
    protected override async Task OnInitializedAsync()
    {
        _listUsers = FakeData.UserInfos;
        if(!string.IsNullOrEmpty(SelectedTabPage))
        {
            Enum.TryParse(SelectedTabPage, out _selectedTabPage);
        }
    }

    private async Task OnAnswerSendMailChange(AnswerIMailMessageModel answeriMailMessage)
    {
        await _imailMainComponent.AmendiMailMessageAsync(answeriMailMessage);

        ModalParameters parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.Message), $"Your mail was sent to {_listUsers.FirstOrDefault(x => x.UserID == answeriMailMessage.ReceiverID).UserName}")
            .Add(nameof(CommonModalComponent.HeaderLabel), "Mail was sent")
            .Add(nameof(CommonModalComponent.UseButtonOk), true);
        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        iMailModalSvc.Show<CommonModalComponent>("Mail was sent", parameters, options);
    }

    private async Task OnSendMailChange(IMailMessageModel edittediMailMessage)
    {
        await _imailMainComponent.AddNewiMailMessageAsync(edittediMailMessage);

        ModalParameters parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.Message), $"Your mail was sent to {_listUsers.FirstOrDefault(x => x.UserID == edittediMailMessage.ReceiverID).UserName}")
            .Add(nameof(CommonModalComponent.HeaderLabel), "Mail was sent")
            .Add(nameof(CommonModalComponent.UseButtonOk), true);
        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        iMailModalSvc.Show<CommonModalComponent>("Mail was sent", parameters, options);
    }

    private async Task OnSelectediMail_Click(IMailMessageModel selectediMail)
    {
        await _imailSidebarComponent.OnAnsweriMailMessageAsync(selectediMail, isAnswer: true);
    }

    private async Task ResetForm()
    {
        _navigateManager.NavigateTo(_navigateManager.Uri, forceLoad: true);
    }
}
