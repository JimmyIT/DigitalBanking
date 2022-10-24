using static IFS.DB.WebApp.Helpers.Enums.CorporateSignInEnum;

namespace IFS.DB.WebApp.Features.Identity.Pages;

public partial class CorporateSignin
{
    private SigninStepsEnum _currentSignInStep = SigninStepsEnum.FirstStep;


    private void ValidationOnValueChange(SigninStepsEnum signinStepsEnum)
    {
        _currentSignInStep = signinStepsEnum;
        StateHasChanged();
    }    
}
