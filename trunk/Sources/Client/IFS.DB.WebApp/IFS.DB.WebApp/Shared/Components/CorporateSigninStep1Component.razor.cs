using Microsoft.AspNetCore.Components;
using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CorporateSigninStep1Component
{
    [Parameter] public Action<SigninStepsEnum> OnValueChanged { get; set; }

    private void ButtonOnClick()
    {
        bool isValid = true;
        if(isValid)
        {
            OnValueChanged?.Invoke(SigninStepsEnum.SecondStep);
        }
    }
}
