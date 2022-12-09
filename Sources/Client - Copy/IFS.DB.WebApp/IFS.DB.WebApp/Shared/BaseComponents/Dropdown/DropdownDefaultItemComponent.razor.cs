using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.BaseComponents.Dropdown;

public partial class DropdownDefaultItemComponent<TItem> : ComponentBase
{
    internal ElementReference _dropdownItemEle;

    protected override async Task OnInitializedAsync()
    {
        if (DropdownComponent == null)
            throw new ArgumentNullException(nameof(DropdownComponent), "DropdownItemComponent must exist within a DropdownComponent");

        if (string.IsNullOrEmpty(ElementId))
        {
            ElementId = Guid.NewGuid().ToString("N");
        }
        DropdownComponent.AddDropdownDefaultItemComponent(this);
    }


    #region Properties 

    /// <summary>
    /// Element ID
    /// </summary>
    [Parameter] public string ElementId { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string CssClass { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string InlineStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public bool KeepState { get; set; }

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
