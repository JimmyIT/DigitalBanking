using Blazored.LocalStorage;
using Blazored.Modal;
using IFS.DB.WebApp.Helpers.AuthProviders;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Shared.Layouts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, ApplicationAuthStateProvider>();
builder.Services.AddBlazoredLocalStorage(); 
builder.Services.AddBlazoredModal();
builder.Services.AddLocalization();

var host = builder.Build();
await host.SetDefaultCulture();

await builder.Build().RunAsync();

