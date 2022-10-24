using Microsoft.AspNetCore.Components;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep3Component
{
    [Parameter] public Action<SigninStepsEnum> OnValueChanged { get; set; }

    private void ButtonNextOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged?.Invoke(SigninStepsEnum.FourthStep);
        }
    }

    private void ButtonBackOnClick()
    {
        bool isValid = true;
        if (isValid)
        {
            OnValueChanged?.Invoke(SigninStepsEnum.SecondStep);
        }
    }
}
