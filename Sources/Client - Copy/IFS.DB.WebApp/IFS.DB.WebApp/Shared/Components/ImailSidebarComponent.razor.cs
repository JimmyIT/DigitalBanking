using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.iMails;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ImailSidebarComponent
{
    [Parameter] public EventCallback<IMailMessageModel> OnSendMailClickChange { get; set; }
    [Parameter] public EventCallback<AnswerIMailMessageModel> OnAnswerMailClickChange { get; set; }
    private ValidationMessageStore _validateMsgStore;
    private EditContext _sendiMailContext;
    private SendMailRequestModel _sendMailRequestModel;
    private List<UserInfoModel> _listUsers;
    private List<IMailMessageModel> _listIMailMessages;

    private IMailMessageModel _selectediMailMessageItem;
    private int _AuthenticatedUserID = FakeData.AuthorisedUserID;
    private bool _isAnswer = false;
    protected override async Task OnInitializedAsync()
    {
        _listUsers = FakeData.UserInfos;
        _listIMailMessages = FakeData.iMailMessages;

        SetiMailMessageModelForm(new SendMailRequestModel());      
    }

    public async Task OnAnsweriMailMessageAsync(IMailMessageModel selectediMailMessageItem, bool isAnswer = false)
    {
        SetiMailMessageModelForm(new SendMailRequestModel());
        if (isAnswer)
        {
            _isAnswer = isAnswer;
            _selectediMailMessageItem = selectediMailMessageItem;
            if (selectediMailMessageItem != null)
            {
                _sendMailRequestModel.SenderID = _AuthenticatedUserID;
                _sendMailRequestModel.ReceiverID = selectediMailMessageItem.SenderID;
                _sendMailRequestModel.Priority = selectediMailMessageItem.Priority;
                _sendMailRequestModel.Subject = selectediMailMessageItem.Subject;

                StateHasChanged();
            }
        }
    }

    private async Task InvalidSubmit()
    {

    }
    
    private async Task SendAniMail()
    {        
        if(_isAnswer)
        {
            await OnAnswerMailClickChange.InvokeAsync(new AnswerIMailMessageModel
            {
                AnswerID = _selectediMailMessageItem.AnswerIMailMessages.Count() + 1,
                MailID = _selectediMailMessageItem.MailID,
                SenderID = _AuthenticatedUserID,
                CreatedDate = DateTime.Now,
                Message = _sendMailRequestModel.Message,
                Priority = (IMailPriorityEnum)_sendMailRequestModel.Priority,
                ReceiverID = (int)_sendMailRequestModel.ReceiverID,
                Status = IMailStatusEnum.New,
                Subject = _sendMailRequestModel.Subject
            });
        }
        else
        {
            await OnSendMailClickChange.InvokeAsync(new IMailMessageModel
            {
                SenderID = _AuthenticatedUserID,
                CreatedDate = DateTime.Now,
                MailID = _listIMailMessages.Count() + 1,
                Message = _sendMailRequestModel.Message,
                Priority = (IMailPriorityEnum)_sendMailRequestModel.Priority,
                ReceiverID = (int)_sendMailRequestModel.ReceiverID,
                Status = IMailStatusEnum.New,
                Subject = _sendMailRequestModel.Subject
            });
        }
    }

    private string GetPriorityEnumDescription(string enumValue)
    {
        IMailPriorityEnum mailPriorityEnum;
        if (Enum.TryParse(enumValue, out mailPriorityEnum))
        {
            return mailPriorityEnum.ToDescription();
        }

        return enumValue;
    }

    private void SetiMailMessageModelForm(SendMailRequestModel value)
    {
        _sendMailRequestModel = new SendMailRequestModel();
        _sendMailRequestModel.SenderID = FakeData.AuthorisedUserID;
        _sendiMailContext = new(_sendMailRequestModel);
        _sendiMailContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validateMsgStore = new ValidationMessageStore(_sendiMailContext);

        _sendiMailContext.OnFieldChanged += (_, args) => { _validateMsgStore.Clear(args.FieldIdentifier); };
    }
}
