using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep4Component
{
    
    [CascadingParameter(Name = "UserSignInModel")]
    public UserSignInModel UserSignInModel { get; set; }
    
    [CascadingParameter(Name = "MseAuth")]
    public MseAuth MseAuth { get; set; }
    
    [CascadingParameter(Name = "UserIdModel")]
    public UserIdModel UserIdModel { get; set; }
    
    [CascadingParameter]
    public IModalService ModalSvc { get; set; }
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private bool _isSubmitting = false;

    private Dictionary<int, string> _passwordDict = new();

    private List<string> _passCodes = new();

    private bool _showInvalid = false;

    private const string Password = "Aa12345678";
    private const string Code = "1234";

    private PasswordComponent _passwordComponentRef = null!;

    private async Task ButtonSubmit_OnClick()
    {
        _isSubmitting = true;
        var isValid = true;

        if (_passwordDict.Count == 0 || _passwordDict.Any(x => string.IsNullOrEmpty(x.Value)))
        {
            return;
        }

        if (_passCodes.Count < 4)
        {
            return;
        }

        foreach (var item in _passwordDict)
        {
            if (!item.Value.Equals(Password[item.Key-1].ToString()))
            {
                isValid = false;
            }
        }

        if (!string.Join(string.Empty, _passCodes).Equals(Code))
        {
            isValid = false;
        }

        if (isValid is false)
        {
            _showInvalid = true;
            
            ModalSvc.Show<SimpleAnnouncementModalComponent>(
                title: string.Empty,
                new ModalParameters
                {
                    { nameof(SimpleAnnouncementModalComponent.HeaderTitle), "Incorrect password or security code." },
                    { nameof(SimpleAnnouncementModalComponent.OnClose), EventCallback.Factory.Create(this, () =>
                        {
                            _isSubmitting = false;
                            _showInvalid = false;
                            _passwordComponentRef.RerenderPassword();
                            _passwordDict.Clear();
                            _passCodes.Clear();
                        }) 
                    }
                },
                new ModalOptions
                {
                    UseCustomLayout = true
                });
            return;
        }

        var url = string.Empty;
        
        if (UserSignInModel.CustomerID.ToLower().Contains("customer"))
        {
            UserSignInModel userSignInModel = new()
            {
                Role = UserRoles.MSECustomer,
                UserID = "Craig",
                ClientNumber = "00088",
                CustomerID = "Craig"
            };
            await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
            url = "/user/dashboard";
        }

        if (UserSignInModel.CustomerID.ToLower().Contains("admin"))
        {
            UserSignInModel userSignInModel = new()
            {
                Role = UserRoles.Admin,
                UserID = "Craig",
                ClientNumber = "00088",
                CustomerID = "Craig"
            };
            await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
            url = "/admin/dashboard";
        }
        
        if (UserSignInModel.CustomerID.ToLower().Contains("host"))
        {
            UserSignInModel userSignInModel = new()
            {
                Role = UserRoles.Host,
                UserID = "Craig",
                ClientNumber = "00088",
                CustomerID = "Craig"
            };
            await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
            url = "/customer-maintenance";
        }
        
        _navigateManager.NavigateTo(url, forceLoad: true);
    }

    private void ButtonBack_OnClick()
    {
        OnValueChanged.InvokeAsync(SigninStepsEnum.ThirdStep);
    }

    private Func<SigninStepsEnum, Action> GoToStep => step => async () =>
    {
        if (OnValueChanged.HasDelegate)
            await OnValueChanged.InvokeAsync(step);
    };
}
