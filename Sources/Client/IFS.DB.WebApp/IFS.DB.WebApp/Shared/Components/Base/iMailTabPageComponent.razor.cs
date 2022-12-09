using IFS.DB.WebApp.Helpers.Enums;
using Microsoft.AspNetCore.Components;
using System;

namespace IFS.DB.WebApp.Shared.Components.Base;

public partial class IMailTabPageComponent : ComponentBase
{
    [CascadingParameter] private IMailTabControlComponent Parent { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public string TabPageHeaderIcon { get; set; }
    [Parameter] public string Text { get; set; }
    [Parameter] public string ElementID { get; set; }
    [Parameter] public IMailTabPageEnum ContentName { get; set; }


    protected override void OnInitialized()
    {
        if (Parent == null)
            throw new ArgumentNullException(nameof(Parent), "TabPageComponent must exist within a TabControlComponent");
        base.OnInitialized();

        ElementID = Guid.NewGuid().ToString("N");
        Parent.AddPage(this);
    }
}
