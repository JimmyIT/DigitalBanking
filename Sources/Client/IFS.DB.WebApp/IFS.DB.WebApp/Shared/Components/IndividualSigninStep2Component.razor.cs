using static IFS.DB.WebApp.Features.Identity.Pages.IndividualSignin;
using IFS.DB.OpenAPI.Client.Customers.IdentifySSE;
using Microsoft.AspNetCore.Components;
using IFS.DB.WebApp.Models.Identity;
using IFS.DB.WebApp.Models;

namespace IFS.DB.WebApp.Shared.Components;

public partial class IndividualSigninStep2Component
{
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

    protected override void OnInitialized()
    {
    }

    private async Task Signin()
    {
        _isSubmitting = true;

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
                _showInvalid = true;
                return;
            }
        }

        if (!string.Join(string.Empty, _passCodes).Equals(Code))
        {
            _showInvalid = true;
            return;
        }


        _navigateManager.NavigateTo("/user/dashboard", true);
    }

    private void Back()
    {
        OnValueChanged.InvokeAsync(SigninStepsEnum.FirstStep);
    }
}
