using IFS.DB.WebApp.Models;
using Microsoft.JSInterop;
using System.Globalization;
using System.Net.Http.Json;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CultureSelectorComponent
{
    private List<CultureInfo> _listCultures = new List<CultureInfo>();
    private CultureInfoModel[] _listCulturesModel;
    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)_jsRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);
                _navigateManager.NavigateTo(_navigateManager.Uri, forceLoad: true);
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        _listCulturesModel = await _httpClient.GetFromJsonAsync<CultureInfoModel[]>("sample-data/allowedcultures.json");
        foreach(var item in _listCulturesModel)
        {
            _listCultures.Add(new CultureInfo(item.CultureInfoCode));
        }
    }

    private string GetCountryEnglishName(string name)
    {
        var cultureInfo = new CultureInfo(name);
        RegionInfo ri = new RegionInfo(cultureInfo.Name);
        Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", name, ri.EnglishName, ri.Name, ri.NativeName, ri.DisplayName));
        return ri.EnglishName;
    }
}
