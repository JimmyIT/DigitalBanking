using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Helpers.AppHttpClient;

public class AppHttpClientService
{
    public AppHttpClientService(HttpClient httpClient, NavigationManager navigationManager)
    {
        HttpClient = httpClient;
        NavigationManager = navigationManager;
        HttpClient.BaseAddress = new Uri(NavigationManager.BaseUri);
    }
    public HttpClient HttpClient { get; }
    public NavigationManager NavigationManager { get; }
}
