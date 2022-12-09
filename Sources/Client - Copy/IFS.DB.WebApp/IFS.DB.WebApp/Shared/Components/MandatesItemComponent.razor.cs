using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Mandates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class MandatesItemComponent
{
    [CascadingParameter] public MandatesMaintenance Owner { get; set; } = default!;
    [Parameter] public string MandatesItemID { get; set; }
    [Parameter] public MandatesItemModel MandatesItem { get; set; }

    private EditContext _editContext;
    private ValidationMessageStore _validationMessageStore;

    private MandatesItemModel _mandatesItemModel;
    private SimpleValueItemModel _simpleValueItemModel;
    private FormulaItemsModel _formulaItemsModel;
    private List<FormulaItemModel> _formulaItemListModel;

    private bool _isSimpleValueSection = false;
    private bool _isFormulaSection = false;

    internal async Task ForeceStateHasChanged()
    {
        StateHasChanged();
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        await PrepareUIAsync();

        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if(string.IsNullOrEmpty(MandatesItemID))
        {
            MandatesItemID = Guid.NewGuid().ToString("N");
        }

        await PrepareUIAsync();
    }

    private async Task PrepareUIAsync()
    {
        _mandatesItemModel = MandatesItem;
        switch (_mandatesItemModel.ItemType)
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
        _mandatesItemModel.ItemType = MandatesItemTypeEnum.Simple;
        await GetAtiveOptionAsync(_mandatesItemModel.ItemType);

        if(_mandatesItemModel.SimpleValueItem == null)
        {
            _simpleValueItemModel = new SimpleValueItemModel();
        }
        else
        {
            _simpleValueItemModel = _mandatesItemModel.SimpleValueItem;
        }

        _editContext = new EditContext(_simpleValueItemModel);
        _editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_editContext);
        _editContext.OnFieldChanged += EditContext_OnFieldChanged;

        await Owner.AddEditContextAsync(_editContext, this);
    }

    private async Task ActiveFormulaSection()
    {        
        _mandatesItemModel.ItemType = MandatesItemTypeEnum.Formula;
        await GetAtiveOptionAsync(_mandatesItemModel.ItemType);

        if (_mandatesItemModel.Formula != null)
        {
            _formulaItemsModel = _mandatesItemModel.Formula;
        }
        else
        {
            _formulaItemsModel = new FormulaItemsModel()
            {
                Items = new List<FormulaItemModel>()
                {
                    new FormulaItemModel()
                }
            };
        }

        _formulaItemListModel = _formulaItemsModel.Items;
        //_editContext = new EditContext(_formulaItemModel);
        //_editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        //_validationMessageStore = new ValidationMessageStore(_editContext);
        //await Owner.AddEditContextAsync(_editContext);
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        switch (_mandatesItemModel.ItemType)
        {
            case MandatesItemTypeEnum.Simple:
                {
                    _mandatesItemModel.SimpleValueItem = _simpleValueItemModel;
                    break;
                }
            case MandatesItemTypeEnum.Formula:
                {
                    _mandatesItemModel.Formula = _formulaItemsModel;
                    break;
                }
        }

        await Owner.SetMandatesItemAsync(_mandatesItemModel);
    }

    private async Task GetAtiveOptionAsync(MandatesItemTypeEnum mandateItemType)
    {
        _isSimpleValueSection = mandateItemType.Equals(MandatesItemTypeEnum.Simple);
        _isFormulaSection = mandateItemType.Equals(MandatesItemTypeEnum.Formula);
    }

    private async Task RemoveMandatesItemAsync()
    {
        await Owner.RemoveEditContextAsync(_editContext, MandatesItem);
        await Owner.ForceStateHasChangeAsync();
    }

}
