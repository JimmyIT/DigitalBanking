using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ProfilePasswordComponent
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    private ChangeLoginInfoRequestModel _changeLoginInfoRequestModel;
    private EditContext _profileLoginAndPasswordEditContext;
    private ValidationMessageStore _validateMsgStore;
    private bool isSuccess = false;
    private bool _showPassword = false;

    protected override async Task OnInitializedAsync()
    {
        await EditContextConfiguration();
    }

    private async Task EditContextConfiguration()
    {
        _changeLoginInfoRequestModel = new ChangeLoginInfoRequestModel();
        _profileLoginAndPasswordEditContext = new EditContext(_changeLoginInfoRequestModel);
        _profileLoginAndPasswordEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validateMsgStore = new ValidationMessageStore(_profileLoginAndPasswordEditContext);
        _profileLoginAndPasswordEditContext.OnFieldChanged += (_, args) => { _validateMsgStore.Clear(args.FieldIdentifier); };
    }

    private async Task OnValidSubmit_Click()
    {
        isSuccess = true;
        if (!_changeLoginInfoRequestModel.CurrentPassword.Equals(FakeData.Password))
        {
            _validateMsgStore.Add(_profileLoginAndPasswordEditContext.Field("CurrentPassword"), "Password is not correct.");
            _profileLoginAndPasswordEditContext.NotifyValidationStateChanged();

            isSuccess = false;

            StateHasChanged();
        }

        await EditContextConfiguration();
    }

    private async Task OnInvalidSubmit_Click()
    {        
        isSuccess = false;
    }

    private async Task onClickVisiblePassword()
    {
        _showPassword = !_showPassword;
    }

    private void ResetValidation()
    {
        _profileLoginAndPasswordEditContext.OnFieldChanged += (_, args) => { _validateMsgStore.Clear(args.FieldIdentifier); };
        _profileLoginAndPasswordEditContext.NotifyValidationStateChanged();
    }

    private async Task ShowChangePasswordModalAsync()
    {
        ModalParameters parameters = new ModalParameters();

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        var modalResult = ModalSvc.Show<ChangePasswordModalComponent>($"Change Password", parameters, options);
        var result = await modalResult.Result;
        if(result.Confirmed)
        {
            isSuccess = true;
        }
    }
}
