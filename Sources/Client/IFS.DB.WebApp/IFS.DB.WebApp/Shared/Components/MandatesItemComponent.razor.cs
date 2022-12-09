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
    [Parameter] public int EditContextIndex { get; set; }
    [Parameter] public MandatesItemModel MandatesItem { get; set; }
    [Parameter] public EventCallback<(MandatesItemComponent, int, MandatesItemModel)> MandatesItem_OnDelete { get; set; }

    private EditContext _editContext;
    private ValidationMessageStore _validationMessageStore;

    private MandatesItemModel _mandatesItemModel = new MandatesItemModel();
    private SimpleValueItemModel _simpleValueItemModel = new SimpleValueItemModel();
    private FormulaItemsModel _formulaItemsModel = new FormulaItemsModel();
    private List<FormulaItemModel> _formulaItemListModel;

    private bool _isSimpleValueSection = false;
    private bool _isFormulaSection = false;

    internal async Task ForeceStateHasChanged()
    {
        StateHasChanged();
    }

    internal async Task UpdateItemModelAsync(MandatesItemModel mandatesItemModel)
    {
        switch (mandatesItemModel.ItemType)
        {
            case MandatesItemTypeEnum.Simple:
                {
                    _simpleValueItemModel = mandatesItemModel.SimpleValueItem;
                    break;
                }
            case MandatesItemTypeEnum.Formula:
                {
                    break;
                }
        }
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);        

        await base.SetParametersAsync(parameters);
    }

    protected override void OnParametersSet()
    {                
        base.OnParametersSet();
    }

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(MandatesItemID))
        {
            MandatesItemID = Guid.NewGuid().ToString("N");
        }

        await PrepareUIAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            
        }
    }

    private async Task PrepareUIAsync()
    {
        _mandatesItemModel = MandatesItem with { };
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
        await GetAtiveOptionAsync(MandatesItemTypeEnum.Simple);

        if (_mandatesItemModel.SimpleValueItem != null)
        {
            _simpleValueItemModel.CurrencyCode = _mandatesItemModel.SimpleValueItem.CurrencyCode;
            _simpleValueItemModel.Amount = _mandatesItemModel.SimpleValueItem.Amount;
            _simpleValueItemModel.NumberOfSignatures = _mandatesItemModel.SimpleValueItem.NumberOfSignatures;
        }
        else
        {
            _simpleValueItemModel = new SimpleValueItemModel(); 
        }

        if (_editContext != null)
        {
            //await Owner.RemoveEditContextAsync(_editContext);
            //await Owner.RemoveMandatesItemComponentAsync(this);
            _editContext.Validate();
            return;
        }       

        _editContext = new EditContext(_simpleValueItemModel);
        _editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_editContext);
        _editContext.OnFieldChanged += EditContext_OnFieldChanged;

        await Owner.AddEditContextAsync(EditContextIndex, _editContext);
        await Owner.AddMandatesItemComponentAsync(this);
    }

    private async Task ActiveFormulaSection()
    {
        //_mandatesItemModel.ItemType = MandatesItemTypeEnum.Formula;
        //await GetAtiveOptionAsync(_mandatesItemModel.ItemType);

        //if (_mandatesItemModel.Formula != null)
        //{
        //    _formulaItemsModel = _mandatesItemModel.Formula;
        //}
        //else
        //{
        //    _formulaItemsModel = new FormulaItemsModel()
        //    {
        //        Items = new List<FormulaItemModel>()
        //        {
        //            new FormulaItemModel()
        //        }
        //    };
        //}

        //_formulaItemListModel = _formulaItemsModel.Items;
        //_editContext = new EditContext(_formulaItemModel);
        //_editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        //_validationMessageStore = new ValidationMessageStore(_editContext);
        //await Owner.AddEditContextAsync(_editContext);
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        switch (MandatesItem.ItemType)
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

    /// <summary>
    ///  Delete mandate item
    /// </summary>
    /// <returns></returns>
    private async Task RemoveMandatesItemAsync()
    {
        await MandatesItem_OnDelete.InvokeAsync((this, EditContextIndex, _mandatesItemModel));
    }

}
