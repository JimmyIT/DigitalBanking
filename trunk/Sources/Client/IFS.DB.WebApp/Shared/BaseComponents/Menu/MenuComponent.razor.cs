using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.BaseComponents.Menu;

public partial class MenuComponent : ComponentBase
{
    protected GlobalIconCss IconCss { get; set; } = new GlobalIconCss();
    protected override async Task OnParametersSetAsync()
    {
        if (ChildContent != null && MenuBuilder != null)
        {
            throw new InvalidOperationException($"Cannot use child content and menu builder together");
        }

        var isOpenAvailable = string.IsNullOrEmpty(IconClassToOpen);
        var isCloseAvailble = string.IsNullOrEmpty(IconClassToClose);
        if (isOpenAvailable ^ isCloseAvailble)
        {
            throw new ArgumentException($"{nameof(IconClassToClose)} or {nameof(IconClassToOpen)} not specified");
        }

        IconCss.IconClassToClose = IconClassToClose;
        IconCss.IconClassToOpen = IconClassToOpen;
    }

    #region Properties

    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public MenuBuilder MenuBuilder { get; set; }
    [Parameter] public string CssClass { get; set; }
    [Parameter] public string IconClassToClose { get; set; }
    [Parameter] public string IconClassToOpen { get; set; }

    #endregion
}
