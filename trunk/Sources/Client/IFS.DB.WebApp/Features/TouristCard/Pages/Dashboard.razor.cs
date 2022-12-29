using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Features.TouristCard.Pages;

public partial class Dashboard
{
    #region component lifecycle

    // Create instance
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
    }

    // 
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    #endregion
}
