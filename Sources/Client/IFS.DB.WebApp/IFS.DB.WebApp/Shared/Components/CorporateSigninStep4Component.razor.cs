using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep4Component
{
    [Parameter] public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    private bool _isSubmitting = false;

    private Dictionary<int, string> _passwordDict = new();

    private List<string> _passCodes = new();

    private bool _showInvalid = false;

    private const string Password = "Aa12345678";
    private const string Code = "1234";

    private async Task ButtonSubmit_OnClick()
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
            if (!item.Value.Equals(Password[item.Key-1].ToString()))
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

        //UserSignInModel userSignInModel = new()
        //{
        //    Role = UserRoles.Admin,
        //    UserID = "Craig",
        //    ClientNumber = "00088",
        //    CustomerID = "Craig"
        //};
        //await _localStorageSvc.SetItemAsync<UserSignInModel>("Identity", userSignInModel);
        _navigateManager.NavigateTo(_navigateManager.Uri, forceLoad: true);

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
