using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Mandates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class MandatesItemComponent
{
    [CascadingParameter] public MandatesMaintenanceEdit Owner { get; set; } = default!;
    [Parameter] public string MandatesItemID { get; set; }
    [Parameter] public MandatesItemModel MandatesItem { get; set; }
    [Parameter] public EventCallback<(MandatesItemComponent, EditContext, MandatesItemModel)> MandatesItem_OnDelete { get; set; }

    private EditContext _editContext;
    private ValidationMessageStore _validationMessageStore;

    private List<FormulaItemCreationComponent> _listFormulaItemComponent;

    private MandatesItemModel _mandatesItem;
    private SimpleValueItemModel _simpleValueItem;
    private FormulaItemsModel _formulaItems;

    private bool _isSimpleValueSection = false;
    private bool _isFormulaSection = false;

    internal async Task AddEditContextAsync(EditContext ctx) => await Owner.AddEditContextAsync(ctx);
    internal async Task AddFormulaItemComponentAsync(FormulaItemCreationComponent formulaItemComponent)
        => _listFormulaItemComponent.Add(formulaItemComponent);
    internal async Task RemoveEditContextAsync(EditContext ctx) => Owner.RemoveEditContextAsync(ctx);
    internal async Task SetUpdatedFormulaData(FormulaItemModel updatedFormulaItem)
    {
        _formulaItems.Items.ForEach(formulaItem =>
        {
            if(formulaItem.FormulaItemID.Equals(updatedFormulaItem.FormulaItemID))
            {
                formulaItem.CurrencyCode = updatedFormulaItem.CurrencyCode;
                formulaItem.Amount = updatedFormulaItem.Amount;
                formulaItem.FormulaValues = updatedFormulaItem.FormulaValues;
            }
        });

        _mandatesItem.Formula.Items = _formulaItems.Items.Select(x => x with { }).ToList();
        await Owner.SetMandatesItemAsync(_mandatesItem with { });
    }
    internal async Task ForceStateHasChanged() => StateHasChanged();

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        _mandatesItem = MandatesItem with { };        
        _simpleValueItem = _mandatesItem.SimpleValueItem;
        _formulaItems = _mandatesItem.Formula;

        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(MandatesItemID))
        {
            MandatesItemID = Guid.NewGuid().ToString("N");
        }

        await PrepareUIAsync();
    }

    private async Task PrepareUIAsync()
    {
        switch (_mandatesItem.ItemType)
        {
            case MandatesItemTypeEnum.Simple:
                {
                    await ActiveSimpleValueSectionAync();
                    break;
                }
            case MandatesItemTypeEnum.Formula:
                {
                    await ActiveFormulaSection();
                    break;
                }
        }
    }

    private async Task ActiveSimpleValueSectionAync()
    {
        if (_editContext != null)
        {
            await Owner.RemoveEditContextAsync(_editContext);
            await Owner.RemoveMandatesItemComponentAsync(this);
        }

        _mandatesItem.ItemType = MandatesItemTypeEnum.Simple;
        await GetAtiveOptionAsync(MandatesItemTypeEnum.Simple);
        if (_mandatesItem.SimpleValueItem != null)
        {
            _simpleValueItem = _mandatesItem.SimpleValueItem with { };
        }
        else
        {
            _simpleValueItem = new SimpleValueItemModel();
            _simpleValueItem.SimpleValueID = Guid.NewGuid().ToString("N");
            _mandatesItem.SimpleValueItem = _simpleValueItem;
        }
        _mandatesItem.Formula = null;
        await Owner.SetMandatesItemAsync(_mandatesItem);

        _editContext = new EditContext(_simpleValueItem);
        _editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_editContext);
        _editContext.OnFieldChanged += EditContext_OnFieldChanged;

        await Owner.AddEditContextAsync(_editContext);
        await Owner.AddMandatesItemComponentAsync(this);
    }

    private async Task ActiveFormulaSection()
    {
        if (_editContext != null)
        {
            await Owner.RemoveEditContextAsync(_editContext);
        }

        _mandatesItem.ItemType = MandatesItemTypeEnum.Formula;
        await GetAtiveOptionAsync(MandatesItemTypeEnum.Formula);
        if (_mandatesItem.Formula != null)
        {
            _formulaItems = _mandatesItem.Formula with { };
        }
        else
        {
            _formulaItems = new FormulaItemsModel()
            {
                Items = new List<FormulaItemModel>()
                {
                    new FormulaItemModel()
                    {
                        FormulaItemID = Guid.NewGuid().ToString("N")
                    }
                }
            };
            _mandatesItem.Formula = _formulaItems;
        }
        _mandatesItem.SimpleValueItem = null;

        await Owner.SetMandatesItemAsync(_mandatesItem with { });

        _listFormulaItemComponent = new List<FormulaItemCreationComponent>();
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        switch (_mandatesItem.ItemType)
        {
            case MandatesItemTypeEnum.Simple:
                {
                    _mandatesItem.SimpleValueItem = _simpleValueItem;
                    break;
                }
            case MandatesItemTypeEnum.Formula:
                {
                    _mandatesItem.Formula = _formulaItems;
                    break;
                }
        }

        await Owner.SetMandatesItemAsync(_mandatesItem with { });
    }

    private async Task GetAtiveOptionAsync(MandatesItemTypeEnum mandateItemType)
    {
        _isSimpleValueSection = mandateItemType.Equals(MandatesItemTypeEnum.Simple);
        _isFormulaSection = mandateItemType.Equals(MandatesItemTypeEnum.Formula);
    }

    /// <summary>
    ///  Delete mandate item
    /// </summary>
    /// <returns></returns>
    private async Task RemoveMandatesItemAsync()
    {
        await MandatesItem_OnDelete.InvokeAsync((this, _editContext, _mandatesItem));
    }
}
