using Blazored.LocalStorage;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace IFS.DB.WebApp.Helpers.AuthProviders;

public class ApplicationAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageSvc;

    public ApplicationAuthStateProvider(ILocalStorageService localStorageSvc)
    {
        _localStorageSvc = localStorageSvc;
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (!await _localStorageSvc.ContainKeyAsync("Identity"))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var userSignIn = await _localStorageSvc.GetItemAsync<UserSignInModel>("Identity");
        var userSignInClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSignIn.CustomerID),
                new Claim(ClaimTypes.Role, userSignIn.Role)
            };

        var anonymous = new ClaimsIdentity(userSignInClaims, "ApplicationAuthType");
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
}
