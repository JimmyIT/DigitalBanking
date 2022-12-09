using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Mandates;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class MandatesMaintenanceEdit
{
    // Model to load current data
    private MandatesMaintenanceModel _mandateMaintenanceModel;

    // Model to request edit
    private MandatesMaintenanceRequestModel _mandateMaintenanceRequestModel;

    // To keep all added contexts 
    private Dictionary<int, EditContext> _mandatesContexts = new Dictionary<int, EditContext>();
    private List<MandatesItemComponent> _mandatesItemComponents = new List<MandatesItemComponent>();

    private ValidationMessageStore _messageStore;
    private EditContext _maxAmountEditContext;

    private int _editContextCount = 0;
    private int _updatedMandateItemsCount = 0;
    private List<MandatesItemModel> _updatedMandateItems;

    internal async Task AddEditContextAsync(int index, EditContext ctx) => _mandatesContexts.Add(index, ctx);
    internal async Task AddMandatesItemComponentAsync(MandatesItemComponent mandateItemComponent) => _mandatesItemComponents.Add(mandateItemComponent);
    internal async Task RemoveEditContextAsync(int index, EditContext ctx) => _mandatesContexts.Remove(index);
    internal async Task RemoveMandatesItemComponentAsync(MandatesItemComponent mandateItemComponent) => _mandatesItemComponents.Remove(mandateItemComponent);
    internal async Task SetMandatesItemAsync(MandatesItemModel updatedMandatesItem)
    {
        _updatedMandateItems.ForEach(mandatesItem =>
        {
            if (mandatesItem.MandatesItemId == updatedMandatesItem.MandatesItemId)
            {
                mandatesItem.ItemType = updatedMandatesItem.ItemType;
                mandatesItem.SimpleValueItem = updatedMandatesItem.SimpleValueItem;
                mandatesItem.Formula = updatedMandatesItem.Formula;
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
            _updatedMandateItems = new List<MandatesItemModel>() { new MandatesItemModel(1) };
        }
        _updatedMandateItemsCount = _updatedMandateItems.Count();

        // Prepare edit context
        _maxAmountEditContext = new EditContext(_mandateMaintenanceRequestModel);
        _maxAmountEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_maxAmountEditContext);
        _maxAmountEditContext.OnFieldChanged += HandleFieldChanged;

        _mandatesContexts.Add(1, _maxAmountEditContext);
    }

    private async Task SaveUpdatesAsync()
    {
        if (_mandatesContexts.Any(ctx => ctx.Value.Validate() is false))
        {
            return;
        }

        // Map the updates to request model
        _mandateMaintenanceRequestModel.MandatesItems = _updatedMandateItems;

        // Save to database
        _mandateMaintenanceModel.MaximumAmount = _mandateMaintenanceRequestModel.MaximumAmount;
        _mandateMaintenanceModel.MandatesItems = _mandateMaintenanceRequestModel.MandatesItems;
        FakeData.MandatesMaintenance = _mandateMaintenanceModel;
    }

    private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
    {

    }

    private async Task AddValueItemAsync()
    {
        if (_mandatesContexts.Any(ctx => ctx.Value.Validate() is false))
        {
            return;
        }

        _updatedMandateItems.Add(new MandatesItemModel(++_updatedMandateItemsCount));
        _editContextCount = 1 + _updatedMandateItems.Count();

    }

    private async Task DeleteValueItemAsync((MandatesItemComponent itemComponent, int ctxIndex, MandatesItemModel mandateItem) args)
    {
        _mandatesItemComponents.RemoveAll(x => x.MandatesItemID == args.itemComponent.MandatesItemID);
        _mandatesContexts.Remove(args.ctxIndex);
        _updatedMandateItems.RemoveAll(x => x.MandatesItemId == args.mandateItem.MandatesItemId);
        
        //StateHasChanged();

        //// Re-calculate index
        //var tempListMandatesItems = _updatedMandateItems;
        //var tempListMandatesItemComponents = _mandatesItemComponents;

        //_updatedMandateItemsCount = 0;
        //tempListMandatesItemComponents.ForEach(mandateItemComp =>
        //{
        //    mandateItemComp.MandatesItemID = (++_updatedMandateItemsCount).ToString();
        //});

        //_updatedMandateItemsCount = 0;
        //tempListMandatesItems.ForEach(mandItem =>
        //{
        //    mandItem.MandatesItemId = ++_updatedMandateItemsCount;
        //    mandItem.SimpleValueItem = mandItem.SimpleValueItem;
        //    mandItem.Formula = mandItem.Formula;

        //    _mandatesItemComponents.ForEach(mandateItemComp =>
        //    {
        //        if(mandateItemComp.MandatesItemID == mandItem.MandatesItemId.GetValueOrDefault().ToString())
        //        {
        //            mandateItemComp.UpdateItemModelAsync(mandItem);
        //            mandateItemComp.ForeceStateHasChanged();
        //        }
        //    });
        //});

        //_updatedMandateItems = tempListMandatesItems;
        //_mandatesItemComponents = tempListMandatesItemComponents;
        //StateHasChanged();
    }

    //protected async void RenderAsync(object sender, EventArgs e) => await this.InvokeAsync(StateHasChanged);
    private async Task RestartEditting() => await PrepareRequestModelAsync();
}
