using IFS.DB.WebApp.Models;
using System.Globalization;
using System.Text.Json;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CultureSelectorComponent
{
    private CultureInfoModel[]? _listCulturesModel;
    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var uri = new Uri(_navigateManager.Uri)
                    .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var cultureEscaped = Uri.EscapeDataString(value.Name);
                var uriEscaped = Uri.EscapeDataString(uri);

                _navigateManager.NavigateTo(
                    $"culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                    forceLoad: true);
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        string jsonCultures = File.ReadAllText("wwwroot/default-data/CultureSettings.json");
        _listCulturesModel = JsonSerializer.Deserialize<CultureInfoModel[]>(jsonCultures);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    private string GetCountryEnglishName(string name)
    {
        var cultureInfo = new CultureInfo(name);
        RegionInfo ri = new RegionInfo(cultureInfo.Name);
        Console.WriteLine(@"{0} {1} {2} {3} {4}", name, ri.EnglishName, ri.Name, ri.NativeName, ri.DisplayName);
        return ri.EnglishName;
    }
}
