using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Mandates;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class MandatesMaintenance
{
    private List<EditContext> _mandatesContexts = new List<EditContext>();
    private List<MandatesItemComponent> _listMandatesItemComponents = new List<MandatesItemComponent>();

    private EditContext _maxAmountEditContext;

    private MandatesMaintenanceModel _mandatesMaintenanceModel = new();
    private MandatesMaintenanceRequestModel _mandatesMaintenanceRequestModel;
    private List<MandatesItemModel> _mandateItems = new();

    private int _totalMandatesItemsCount = 0;
    private bool isEditMode = false;

    internal async Task AddEditContextAsync(EditContext ctx, MandatesItemComponent mandateItemComponent)
    {
        _mandatesContexts.Add(ctx);
        _listMandatesItemComponents.Add(mandateItemComponent);
    }
    internal async Task RemoveEditContextAsync(EditContext ctx, MandatesItemModel mandatesItem)
    {
        await RemoveValueItem(mandatesItem);
        _mandatesContexts.Remove(ctx);

        // Re - calculate items index
        int i = 0;
        _mandateItems.ForEach(x =>
        {
            x.MandatesItemId = i = i + 1;
        });
    }
    internal async Task ForceStateHasChangeAsync() => StateHasChanged();
    internal async Task SetMandatesItemAsync(MandatesItemModel mandatesItem)
    {
        _mandateItems.ForEach(x =>
        {
            if(x.MandatesItemId == mandatesItem.MandatesItemId)
            {
                x.SimpleValueItem = mandatesItem.SimpleValueItem;
                x.Formula = mandatesItem.Formula;
            }
        });
    }

    protected override async Task OnInitializedAsync()
    {
        _mandatesMaintenanceModel = FakeData.MandatesMaintenance with { };
        await base.OnInitializedAsync();
    }

    private async Task EnableEditModeAsync(bool isEnable)
    {
        isEditMode = isEnable;
        if (isEnable)
        {
            _mandatesMaintenanceRequestModel = new MandatesMaintenanceRequestModel()
            {
                MaximumAmount = _mandatesMaintenanceModel.MaximumAmount,
                MandatesItems = _mandatesMaintenanceModel.MandatesItems,
            };

            _maxAmountEditContext = new EditContext(_mandatesMaintenanceRequestModel);
            _maxAmountEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
            _mandatesContexts.Add(_maxAmountEditContext);

            _mandateItems = _mandatesMaintenanceRequestModel.MandatesItems != null ? _mandatesMaintenanceRequestModel.MandatesItems : new List<MandatesItemModel>();            
        }
        else
        {
            _mandatesMaintenanceRequestModel = null;
        }
    }

    private async Task AddValueItemAsync()
    {
        if (_mandatesContexts.Any(ctx => ctx.Validate() is false))
        {
            return;
        }

        _totalMandatesItemsCount = _mandateItems.Count + 1;
        _mandateItems.Add(new MandatesItemModel(_totalMandatesItemsCount));

    }

    private async Task RemoveValueItem(MandatesItemModel mandatesItem)
        => _mandateItems.Remove(mandatesItem);

    private async Task SaveUpdatesAsync()
    {
        if (_mandatesContexts.Any(ctx => ctx.Validate() is false))
        {            
            return;
        }

        // Prepare request model
        _mandatesMaintenanceRequestModel.MandatesItems = _mandateItems;

        // Save updates to database
        _mandatesMaintenanceModel.MaximumAmount = _mandatesMaintenanceRequestModel.MaximumAmount;
        _mandatesMaintenanceModel.MandatesItems = _mandatesMaintenanceRequestModel.MandatesItems;

        FakeData.MandatesMaintenance = _mandatesMaintenanceModel;
        isEditMode = false;
        StateHasChanged();
    }
}
