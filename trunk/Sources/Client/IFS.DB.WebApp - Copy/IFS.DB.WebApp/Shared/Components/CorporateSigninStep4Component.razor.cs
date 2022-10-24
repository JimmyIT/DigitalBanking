using Microsoft.AspNetCore.Components;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep4Component
{
    [Parameter] public Action<SigninStepsEnum> OnValueChanged { get; set; }

    private void ButtonSubmit_OnClick()
    {
        bool isValid = true;
        if (isValid)
        {

        }
    }

    private void ButtonBack_OnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged?.Invoke(SigninStepsEnum.ThirdStep);
        }
    }
}
