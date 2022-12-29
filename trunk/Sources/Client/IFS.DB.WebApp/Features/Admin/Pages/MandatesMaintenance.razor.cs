using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Mandates;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class MandatesMaintenance
{
    private MandatesMaintenanceModel _mandatesMaintenanceModel = new();
    protected override async Task OnInitializedAsync()
    {
        _mandatesMaintenanceModel = FakeData.MandatesMaintenance with { };
        await base.OnInitializedAsync();
    }

}
