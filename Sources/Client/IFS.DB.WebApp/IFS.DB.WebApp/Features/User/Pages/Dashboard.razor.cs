using IFS.DB.WebApp.Models.Account;

namespace IFS.DB.WebApp.Features.User.Pages;

public partial class Dashboard
{
    private string _selectedAccountNumber = string.Empty;
    private AccountModel _accountModel = new();
    private async Task SelectedCardChange(AccountModel accountModel)
        => _accountModel = accountModel;

    private async Task SetFavouriteAccountChange()
        => _navigateManager.NavigateTo(_navigateManager.Uri, forceLoad:true);
}
