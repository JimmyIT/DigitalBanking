using Blazored.Modal;
using IFS.DB.WebApp.Models.Account;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class AccountInfomationComponent
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;
    [Parameter, EditorRequired] public AccountModel AccountItem { get; set; }

    private async Task Cancel() => await BlazoredModal.CancelAsync();
}
