using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.BaseComponents.Dropdown;

public partial class DropdownItemComponent<TItem> : ComponentBase
{
    private ElementReference _dropdownItemEle;
    private bool _isChecked =>
        (DropdownComponent._selectedItemsValue.Contains(TValue) || DropdownComponent._selectedDropdownItemComponents.Contains(this)) ||
        (this.SelectAll && DropdownComponent.IsSelectedAllOptions(DropdownComponent._dropdownItemComponents, DropdownComponent._selectedDropdownItemComponents));

    protected override async Task OnInitializedAsync()
    {
        if (DropdownComponent == null)
            throw new ArgumentNullException(nameof(DropdownComponent), "DropdownItemComponent must exist within a DropdownComponent");

        if (string.IsNullOrEmpty(ElementId))
        {
            ElementId = Guid.NewGuid().ToString("N");
        }
        DropdownComponent.AddDropdownItemComponent(this);
        DropdownComponent._DropdownItemsValue.Add(TValue);
    }    

    #region Properties 

    /// <summary>
    /// Element ID
    /// </summary>
    [Parameter] public string ElementId { get; set; }

    /// <summary>
    /// Flag to set the option to be select all option, select all options => the select all option will be checked
    /// </summary>
    [Parameter] public bool SelectAll { get; set; }

    /// <summary>
    /// Dropdown ChildContent
    /// </summary>
    [Parameter] public RenderFragment<TItem> ChildContent { get; set; }

    /// <summary>
    /// Value 
    /// </summary>
    [Parameter] public TItem TValue { get; set; }

    /// <summary>
    /// Captures all the custom attribute that are not part of blazor component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [CascadingParameter(Name = "DropdownComponent")] protected DropdownComponent<TItem>? DropdownComponent { get; set; }

    #endregion
}
