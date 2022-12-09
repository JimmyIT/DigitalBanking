using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components.Base;

public partial class ProfileMenuTabControlComponent : ComponentBase
{
    [Parameter] public RenderFragment ProfileTabControlContent { get; set; }
    public ProfileMenuTabContentComponent ActiveTabContent { get; set; }

    private List<ProfileMenuTabContentComponent> TabContents = new();

    internal void AddPage(ProfileMenuTabContentComponent tabContent)
    {
        TabContents.Add(tabContent);
        if (TabContents.Count == 1)
            ActiveTabContent = tabContent;
        StateHasChanged();
    }

    private string GetButtonClass(ProfileMenuTabContentComponent tabContent)
    {
        return tabContent == ActiveTabContent ? "active" : "";
    }

    private void ActivatePage(ProfileMenuTabContentComponent tabContent)
    {
        ActiveTabContent = tabContent;
    }
}
