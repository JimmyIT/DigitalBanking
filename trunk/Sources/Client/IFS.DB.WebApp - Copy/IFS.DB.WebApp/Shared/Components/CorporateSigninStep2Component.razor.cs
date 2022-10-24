using Microsoft.AspNetCore.Components;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep2Component
{
    [Parameter] public Action<SigninStepsEnum> OnValueChanged { get; set; }

    private void ButtonNextOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged?.Invoke(SigninStepsEnum.ThirdStep);
        }
    }

    private void ButtonBackOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged?.Invoke(SigninStepsEnum.FirstStep);
        }
    }
}
