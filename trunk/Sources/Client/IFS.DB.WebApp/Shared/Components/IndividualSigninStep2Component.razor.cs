using Blazored.Modal;
using Blazored.Modal.Services;
using static IFS.DB.WebApp.Features.Identity.Pages.IndividualSignin;
using IFS.DB.OpenAPI.Client.Customers.IdentifySSE;
using IFS.DB.WebApp.Helpers.Constants;
using Microsoft.AspNetCore.Components;
using IFS.DB.WebApp.Models.Identity;
using IFS.DB.WebApp.Models;

namespace IFS.DB.WebApp.Shared.Components;

public partial class IndividualSigninStep2Component
{
    [CascadingParameter(Name = "UserSignInModel")]
    public UserSignInModel UserSignInModel { get; set; }
    
    [CascadingParameter]
    public IModalService ModalSvc { get; set; }
    
    [Parameter]
    public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    [Parameter]
    public IdentifySSECustomerResponse? SseCustomerIdentify { get; set; }

    private bool _isSubmitting = false;

    private Dictionary<int, string> _passwordDict = new();
    private List<string> _passCodes = new();

    private bool _showInvalid = false;

    private string Password = FakeData.Password;
    private string Code = FakeData.Code;
    
    private PasswordComponent _passwordComponentRef = null!;

    protected override void OnInitialized()
    {
    }

    private async Task Signin()
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
            if (!item.Value.Equals(Password[item.Key - 1].ToString()))
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

        var userSignInModal = new UserSignInModel
        {
            Role = UserRoles.SSECustomer,
            UserID = "user_01",
            ClientNumber = "00067",
            CustomerID = "sse_user"
        };

        await _localStorageSvc.SetItemAsync("Identity", userSignInModal);

        _navigateManager.NavigateTo("/user/dashboard", forceLoad: true);
    }

    private void Back()
    {
        OnValueChanged.InvokeAsync(SigninStepsEnum.FirstStep);
    }
}
