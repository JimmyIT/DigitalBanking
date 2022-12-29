using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.BaseComponents.Dropdown;

public partial class DropdownComponent<TItem> : ComponentBase
{
    private ElementReference _dropdownButtonElem;
    private ElementReference _containerDropdownListElem;
    private ElementReference _defaultOptionElem;

    private FieldIdentifier _fieldIdentifier;

    private string DefaultOptionElemID;
    private bool _show = false;
    private bool _keepShowing = false;
    private bool _hasEditContext => CascadedEditContext != null;
    private bool _hasFieldError => _hasEditContext ? CascadedEditContext.GetValidationMessages(_fieldIdentifier).Any() : false;
    private RenderFragment _selectedDropdownItemFragment;

    internal DropdownDefaultItemComponent<TItem> _dropdownDefaultItemComponent = new();
    internal DropdownItemComponent<TItem> _selectedDropdownItemComponent;
    internal TItem? _selectedItemValue;
    internal List<TItem> _DropdownItemsValue = new();
    internal List<TItem> _selectedItemsValue = new();
    internal List<DropdownItemComponent<TItem>> _dropdownItemComponents = new();
    internal List<DropdownItemComponent<TItem>> _selectedDropdownItemComponents = new();

    protected override async Task OnInitializedAsync()
    {
        if(!MultiSelect)
        {
            if (_hasEditContext)
            {
                _fieldIdentifier = FieldId;
            }
        }        

        if (string.IsNullOrEmpty(ElementId))
        {
            ElementId = Guid.NewGuid().ToString("N");
        }

        if (string.IsNullOrEmpty(DefaultOptionElemID))
        {
            DefaultOptionElemID = Guid.NewGuid().ToString("N");
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (MultiSelect)
        {
            _selectedItemsValue = SelectedListData ?? new List<TItem>();
            var listRemoveElem = _DropdownItemsValue.Where(x => !_selectedItemsValue.Contains(x)).ToList();
            listRemoveElem.ForEach(x =>
            {
                _selectedDropdownItemComponents.RemoveAll(elem => elem.TValue.Equals(x));
            });

            StateHasChanged();
        }
        else
        {
            _selectedItemValue = SelectedValue;
            if (_selectedItemValue == null)
                _selectedDropdownItemFragment = null;
        }
    }

    #region Methods

    internal void AddDropdownDefaultItemComponent(DropdownDefaultItemComponent<TItem> dropdownItemComponent)
    {
        _dropdownDefaultItemComponent = dropdownItemComponent;
        _keepShowing = dropdownItemComponent.KeepState;
        StateHasChanged();
    }

    internal void AddDropdownItemComponent(DropdownItemComponent<TItem> dropdownItemComponent)
    {
        _dropdownItemComponents.Add(dropdownItemComponent);
        StateHasChanged();
    }

    internal async Task ToggleDropdownItemComponentAsync(DropdownItemComponent<TItem> selectedElem,
        RenderFragment<TItem> selectedDropdownItemFragment, TItem item, bool isChecked = false)
    {
        if (MultiSelect)
        {
            _keepShowing = true;
            await _containerDropdownListElem.FocusAsync();

            if (isChecked)
            {
                SelectedListData.Add(item);
            }
            else
            {
                SelectedListData.Remove(item);
            }
            await SelectedItems_Onclick.InvokeAsync(SelectedListData);

            StateHasChanged();
            _keepShowing = false;
        }
        else
        {
            _selectedDropdownItemFragment = selectedDropdownItemFragment.Invoke(item);
            _selectedItemValue = item;
            _selectedDropdownItemComponent = selectedElem;

            await SelectedItem_Onclick.InvokeAsync(item);
            CascadedEditContext.NotifyFieldChanged(_fieldIdentifier);

            await Task.Delay(200);
            _show = false;
        }
        StateHasChanged();
    }

    internal async Task ToggleDropdownDefaultItemComponentAsync(DropdownDefaultItemComponent<TItem> selectedElem,
        RenderFragment<TItem> selectedDropdownItemFragment, TItem item, bool isChecked = false)
    {
        if (MultiSelect)
        {

        }
        else
        {
            if (selectedElem.KeepState)
            {
                _keepShowing = true;

                await _containerDropdownListElem.FocusAsync();
                await Task.Delay(300);
                StateHasChanged();

                _keepShowing = false;
            }
            else
            {
                await Task.Delay(200);
                _show = false;
                _selectedDropdownItemFragment = null;
                await SelectedItem_Onclick.InvokeAsync();                
            }
        }
        StateHasChanged();
    }

    internal async Task ToggleSelectItemOfMultiSelectionDropdownAsync(DropdownItemComponent<TItem> selectedElem, TItem item, bool isChecked)
    {
        if (selectedElem.SelectAll)
        {
            _selectedDropdownItemComponents = new();
            _selectedItemsValue = new();
            if (isChecked)
            {
                _dropdownItemComponents.ForEach(x =>
                {
                    _selectedDropdownItemComponents.Add(x);
                });

                _DropdownItemsValue.ForEach(x =>
                {
                    _selectedItemsValue.Add(x);
                });
            }
        }
        else
        {            
            if (isChecked)
            {
                _selectedDropdownItemComponents.Add(selectedElem);
                _selectedItemsValue.Add(item);
            }
            else
            {
                if(_selectedDropdownItemComponents.Where(x => x.SelectAll == true) != null)
                {
                    _selectedDropdownItemComponents.RemoveAll(elem => elem.SelectAll == true);
                }
                _selectedDropdownItemComponents.RemoveAll(elem => elem.ElementId == selectedElem.ElementId);
                _selectedItemsValue.Remove(item);
            }
        }

        await SelectedItems_Onclick.InvokeAsync(_selectedItemsValue);
        StateHasChanged();
    }

    private async Task OutFocusAsync()
    {
        if (_keepShowing)
            return;

        await Task.Delay(200);
        _show = false;
    }

    internal Func<List<DropdownItemComponent<TItem>>, List<DropdownItemComponent<TItem>>, bool> IsSelectedAllOptions = InvestigateIsDropdownSelectAll;

    private static bool InvestigateIsDropdownSelectAll(List<DropdownItemComponent<TItem>> dropdownItems, List<DropdownItemComponent<TItem>> selectedItems)
    {
        List<DropdownItemComponent<TItem>> dropdownItemsWithoutSelectAllOption = dropdownItems.Where(x => x.SelectAll != true).ToList();
        List<DropdownItemComponent<TItem>> selectedDropdownItemsWithoutSelectAllOption = selectedItems.Where(x => x.SelectAll != true).ToList();

        var set1 = new HashSet<DropdownItemComponent<TItem>>(dropdownItemsWithoutSelectAllOption);
        var set2 = new HashSet<DropdownItemComponent<TItem>>(selectedDropdownItemsWithoutSelectAllOption);

        return set1.SetEquals(set2);
    }

    #endregion

    #region Properties 

    [CascadingParameter] private EditContext CascadedEditContext { get; set; }

    /// <summary>
    /// Element ID
    /// </summary>
    [Parameter] public string ElementId { get; set; }

    /// <summary>
    /// To enable multi-select 
    /// </summary>
    [Parameter] public bool MultiSelect { get; set; }

    /// <summary>
    /// Dropdown place holder
    /// </summary>
    [Parameter] public RenderFragment InitialPlaceHolder { get; set; }

    /// <summary>
    /// Dropdown ChildContent
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Dropdown DefaultOptionContent
    /// </summary>
    [Parameter] public RenderFragment DefaultOption { get; set; }

    /// <summary>
    /// additional classes, default: customSelector
    /// </summary>
    [Parameter] public string ContainerCssClass { get; set; }

    /// <summary>
    /// additional classes, default: customSelector
    /// </summary>
    [Parameter] public string ContainerInlineStyle { get; set; }

    /// <summary>
    /// additional classes, default: customSelector
    /// </summary>
    [Parameter] public string DropdownButtonCssClass { get; set; }

    /// <summary>
    /// additional classes, default: customSelector
    /// </summary>
    [Parameter] public string DropdownButtonInlineStyle { get; set; }

    [Parameter] public EventCallback<List<TItem>> SelectedItems_Onclick { get; set; }
    [Parameter] public EventCallback<TItem> SelectedItem_Onclick { get; set; }
    [Parameter] public EventCallback<Func<TItem>> ValueExpression { get; set; }

    /// <summary>
    /// use for multiple select
    /// </summary>
    [Parameter] public List<TItem> SelectedListData { get; set; }

    /// <summary>
    /// use for single select
    /// </summary>
    [Parameter] public TItem SelectedValue { get; set; }

    [Parameter] public FieldIdentifier FieldId { get; set; }

    #endregion
}
