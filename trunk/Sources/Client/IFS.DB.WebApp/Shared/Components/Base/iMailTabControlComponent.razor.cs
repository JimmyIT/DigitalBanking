using IFS.DB.WebApp.Helpers.Attributes;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.Extensions;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components.Base;

public partial class IMailTabControlComponent : ComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [QueryStringParameter] public string SelectedTabPage { get; set; }

    private List<IMailTabPageComponent> TabPages = new();
    public IMailTabPageComponent ActivePage { get; set; }
    private IMailTabPageEnum _selectedTabPage = IMailTabPageEnum.UnreadMails;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        // 👇 Read the value of each property decorated by [QueryStringParameter] from the query string
        this.SetParametersFromQueryString(_navigateManager);

        return base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(SelectedTabPage))
        {
            Enum.TryParse(SelectedTabPage, out _selectedTabPage);
        }
    }

    internal void AddPage(IMailTabPageComponent tabPage)
    {
        TabPages.Add(tabPage);
        if (tabPage.ContentName == _selectedTabPage)
            ActivePage = tabPage;
        StateHasChanged();
    }

    private string GetButtonClass(IMailTabPageComponent tabPage)
    {
        return tabPage == ActivePage ? "active" : "";
    }

    private void ActivatePage(IMailTabPageComponent tabPage)
    {
        ActivePage = tabPage;

        SelectedTabPage = tabPage.ContentName.ToString();
        // 👇 Update the URL to set the new value in the query string
        this.UpdateQueryString(_navigateManager);
    }
}
