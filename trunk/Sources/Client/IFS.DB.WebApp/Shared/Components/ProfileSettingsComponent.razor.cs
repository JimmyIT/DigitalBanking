using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Features.User;
using IFS.DB.WebApp.Features.User.Pages;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.FileUpload;
using IFS.DB.WebApp.Models.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace IFS.DB.WebApp.Shared.Components;

public partial class ProfileSettingsComponent
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    private UserInfoModel _AuthorisedUser = FakeData.AuthorisedUser;
    private ChangeProfileSettingsRequestModel _changeProfileSettingsRequestModel;

    private List<CultureInfoModel> _listCulturesModel = new List<CultureInfoModel>();
    
    private EditContext _profileSettingsEditContext;
    private ValidationMessageStore _validateMsgStore;
    private bool isSuccess = false;
    private string _styleToShowDropdown = "display:none;";
    private UploadPhotoModel _uploadedPhotoModel = new();

    protected override async Task OnInitializedAsync()
    {
        await EditContextConfiguration();
        await GetListCulture();
    }

    private async Task GetListCulture()
    {
        string jsonCultures = File.ReadAllText("wwwroot/default-data/CultureSettings.json");
        _listCulturesModel = JsonSerializer.Deserialize<List<CultureInfoModel>>(jsonCultures);
    }

    private async Task OnValidSubmit_Click()
    {
        _AuthorisedUser.AvartaUrl = _changeProfileSettingsRequestModel.AvartaUrl;
        _AuthorisedUser.PhoneNumberIDD = _changeProfileSettingsRequestModel.PhoneNumberIDD;
        _AuthorisedUser.PhoneNumber = _changeProfileSettingsRequestModel.PhoneNumber;
        _AuthorisedUser.Email = _changeProfileSettingsRequestModel.Email;
        FakeData.AuthorisedUser = _AuthorisedUser;
        isSuccess = true;
        await EditContextConfiguration();
    }

    private async Task OnInvalidSubmit_Click()
    {
        isSuccess = false;
    }

    private async Task EditContextConfiguration()
    {
        _changeProfileSettingsRequestModel = new()
        {
            FirstName = _AuthorisedUser.FirstName,
            MiddleName = _AuthorisedUser.MiddleName,
            LastName = _AuthorisedUser.LastName,
            Email = _AuthorisedUser.Email,
            DateOfBirth = _AuthorisedUser.DateOfBirth,
            AvartaUrl = _AuthorisedUser.AvartaUrl,
            PhoneNumber = _AuthorisedUser.PhoneNumber,
            PhoneNumberIDD = _AuthorisedUser.PhoneNumberIDD,
        };

        _profileSettingsEditContext = new EditContext(_changeProfileSettingsRequestModel);
        _profileSettingsEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validateMsgStore = new ValidationMessageStore(_profileSettingsEditContext);
        _profileSettingsEditContext.OnFieldChanged += (_, args) => { _validateMsgStore.Clear(args.FieldIdentifier); };
    }

    private async Task OnSelectedPhoneNumberIDD(CultureInfoModel selectedCulture)
        => _changeProfileSettingsRequestModel.PhoneNumberIDD = selectedCulture.PhoneNumberIDD;

    private async Task<string> ShowDropdownAction()
    {
        if (_styleToShowDropdown == "display:block;")
            _styleToShowDropdown = "display:none;";
        else
            _styleToShowDropdown = "display:block;";

        return _styleToShowDropdown;
    }
    private async Task<string> HideDropdownAction()
        => _styleToShowDropdown = "display:none;";
    private async Task DeleteAvarta()
        => _changeProfileSettingsRequestModel.AvartaUrl = string.Empty;

    private async Task ShowChangePhotoModalAsync()
    {
        ModalParameters parameters = new ModalParameters();
        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        var modalResult = ModalSvc.Show<UploadPhotoComponent>($"Upload photo", parameters, options);
        var result = await modalResult.Result;
        if(result.Confirmed)
        {
            _uploadedPhotoModel = (UploadPhotoModel)result.Data;
        }
    }
}
