using System.Text.Json;
using Blazored.LocalStorage;
using Blazored.Modal;
using FluentValidation;
using IFS.DB.Resources.EF;
using IFS.DB.WebApp.Helpers.AppHttpClient;
using IFS.DB.WebApp.Helpers.AuthProviders;
using IFS.DB.WebApp.Helpers.Constants;
using IFS.DB.WebApp.Helpers.MessageHandler;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.StandingOrder;
using IFS.DB.WebApp.Services;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services
    .AddServerSideBlazor()
    .AddCircuitOptions(opt => opt.DetailedErrors = builder.Environment.IsDevelopment());

builder.Services.AddScoped<AddIdempotencyKeyHeaderMessageHandler>();
builder.Services.AddHttpClient(AppConstant.DigitalBankClientName, client =>
{
    client.BaseAddress = new Uri(builder.Configuration[ConfigureConstant.ApiUrl]);
}).AddHttpMessageHandler<AddIdempotencyKeyHeaderMessageHandler>();

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient(AppConstant.DigitalBankClientName));


builder.Services.AddDbContext<DigitalBankingDBContext>(options => options.UseSqlServer(builder.Configuration[ConfigureConstant.DigitalBankConnectionString]));
builder.Services.AddScoped<IGetUiTextService, GetUiTextService>();

builder.Services.AddScoped<AppStore>();

builder.Services.AddScoped<AppHttpClientService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApplicationAuthStateProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();
builder.Services.AddLocalization();
builder.Services.AddControllers();
builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Shared");
builder.Services.AddWMBSC(false);

builder.Services.AddValidatorsFromAssemblyContaining<StandingOrderModelValidator>(ServiceLifetime.Transient);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
        .Enrich.FromLogContext()
        //Error Log
        .WriteTo.File(path: @"logs\DBR_Error_.log", rollingInterval: RollingInterval.Day,
            outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level}] {SourceContext} **** {Message:lj} **** {Exception}{NewLine}",
            restrictedToMinimumLevel: LogEventLevel.Error)
        //Event log
        .WriteTo.File(path: @"logs\DBR_Event_.log", rollingInterval: RollingInterval.Day,
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] **** {Message:lj} {NewLine}",
            restrictedToMinimumLevel: LogEventLevel.Information);
});

builder.Services.AddMediatR(typeof(Program).Assembly);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

string jsonSupportedCultures = File.ReadAllText("wwwroot/default-data/CultureSettings.json");
CultureInfoModel[] supportedCultures = JsonSerializer.Deserialize<CultureInfoModel[]>(jsonSupportedCultures);
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0].CultureInfoCode)
    .AddSupportedCultures(supportedCultures.Select(c => c.CultureInfoCode).ToArray())
    .AddSupportedUICultures(supportedCultures.Select(c => c.CultureInfoCode).ToArray());
app.UseRequestLocalization(localizationOptions);
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();