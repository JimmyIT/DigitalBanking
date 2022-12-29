using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Mandates;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Z.Collections.Extensions;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class MandatesMaintenanceEdit
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;

    // Model to load current data
    private MandatesMaintenanceModel _mandateMaintenanceModel;

    // Model to request edit
    private MandatesMaintenanceRequestModel _mandateMaintenanceRequestModel;

    // To keep all added contexts 
    private List<EditContext> _mandatesContexts = new List<EditContext>();
    private List<MandatesItemComponent> _mandatesItemComponents = new List<MandatesItemComponent>();

    private ValidationMessageStore _messageStore;
    private EditContext _maxAmountEditContext;

    private bool isChanged = false;
    private int _editContextCount = 0;
    private int _updatedMandateItemsCount = 0;
    private List<MandatesItemModel> _updatedMandateItems;

    internal async Task AddEditContextAsync(EditContext ctx) => _mandatesContexts.Add(ctx);
    internal async Task AddMandatesItemComponentAsync(MandatesItemComponent mandateItemComponent) => _mandatesItemComponents.Add(mandateItemComponent);
    internal async Task RemoveEditContextAsync(EditContext ctx) => _mandatesContexts.Remove(ctx);
    internal async Task RemoveMandatesItemComponentAsync(MandatesItemComponent mandateItemComponent) => _mandatesItemComponents.Remove(mandateItemComponent);
    internal async Task SetMandatesItemAsync(MandatesItemModel updatedMandatesItem)
    {
        _updatedMandateItems.ForEach(item =>
        {
            if(item.MandatesItemId == updatedMandatesItem.MandatesItemId)
            {
                item.MandatesItemId = updatedMandatesItem.MandatesItemId;
                item.ItemType = updatedMandatesItem.ItemType;
                item.SimpleValueItem = updatedMandatesItem.SimpleValueItem;
                item.Formula = updatedMandatesItem.Formula;
            }
        });
    }
    internal async Task ForceStateHasChangeAsync() => StateHasChanged();

    protected override async Task OnInitializedAsync()
    {
        _mandateMaintenanceModel = FakeData.MandatesMaintenance with { };

        await PrepareRequestModelAsync();
    }

    private async Task PrepareRequestModelAsync()
    {
        // Map data from database to request model
        _mandateMaintenanceRequestModel = new MandatesMaintenanceRequestModel();
        _mandateMaintenanceRequestModel.MaximumAmount = _mandateMaintenanceModel.MaximumAmount;
        _mandateMaintenanceRequestModel.MandatesItems = _mandateMaintenanceModel.MandatesItems;

        // This object is used to work with child component, it gets all updates then map back to request model
        if(_mandateMaintenanceRequestModel.MandatesItems != null)
        {
            _updatedMandateItems = _mandateMaintenanceRequestModel.MandatesItems.Select(x => x with { }).ToList();
        }
        else
        {
            _updatedMandateItems = new List<MandatesItemModel>() { new MandatesItemModel() { MandatesItemId = 1 } };
        }
        _updatedMandateItemsCount = _updatedMandateItems.Count();

        // Prepare edit context
        _maxAmountEditContext = new EditContext(_mandateMaintenanceRequestModel);
        _maxAmountEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_maxAmountEditContext);
        _maxAmountEditContext.OnFieldChanged += HandleFieldChanged;

        _mandatesContexts.Add(_maxAmountEditContext);
    }

    private async Task SaveUpdatesAsync()
    {
        if (_mandatesContexts.Any(ctx => ctx.Validate() is false))
        {
            return;
        }

        // Map the updates to request model
        _mandateMaintenanceRequestModel.MandatesItems = _updatedMandateItems;

        // Save to database
        _mandateMaintenanceModel.MaximumAmount = _mandateMaintenanceRequestModel.MaximumAmount;
        _mandateMaintenanceModel.MandatesItems = _mandateMaintenanceRequestModel.MandatesItems;
        FakeData.MandatesMaintenance = _mandateMaintenanceModel;
        await ShowNotificationMessageAsync();
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {

    }

    private async Task AddValueItemAsync()
    {
        if (_mandatesContexts.Any(ctx => ctx.Validate() is false))
        {
            return;
        }

        _updatedMandateItems.Add(new MandatesItemModel() { MandatesItemId = ++_updatedMandateItemsCount });        
    }

    private async Task DeleteValueItemAsync((MandatesItemComponent itemComponent, EditContext ctx, MandatesItemModel mandateItem) args)
    {
        _mandatesItemComponents = new List<MandatesItemComponent>();
        _mandatesContexts = new List<EditContext>();
        _mandatesContexts.Add(_maxAmountEditContext);


        //_mandatesContexts.Remove(args.ctx);
        //_mandatesItemComponents.Remove(args.itemComponent);
        _updatedMandateItems.Remove(args.mandateItem);

        _updatedMandateItemsCount = 0;
        _updatedMandateItems.ForEach(item =>
        {
            item.MandatesItemId = ++_updatedMandateItemsCount;
        });

        isChanged = !isChanged;
    }

    private async Task RestartEditting()
    {
        await PrepareRequestModelAsync();

        isChanged = !isChanged;
    }

    private async Task ShowNotificationMessageAsync()
    {
        ModalParameters parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.HeaderLabel), $"Update successfully")
            .Add(nameof(CommonModalComponent.UseButtonOk), true)
            .Add(nameof(CommonModalComponent.EventOkClick), EventCallback.Factory.Create(this, NavigateTo));

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        ModalSvc.Show<CommonModalComponent>($"Update success", parameters, options);
    }

    private async Task NavigateTo() => _navigateManager.NavigateTo("/mandates-maintenance");
}
