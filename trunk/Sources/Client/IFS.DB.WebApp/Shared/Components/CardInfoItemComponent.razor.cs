using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Models.Account;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CardInfoItemComponent
{
    [CascadingParameter] IModalService CardInfoItemComponentModalSvc { get; set; } = default!;

    [Parameter] public bool isActive { get; set; } = false;
    [Parameter, EditorRequired] public int CarouselItemIndex { get; set; }
    [Parameter, EditorRequired] public AccountModel AccountItem { get; set; }
    [Parameter] public EventCallback<int> OnActiveItem { get; set; }
    [Parameter] public EventCallback<AccountModel> OnFavouriteItem { get; set; }

    private async Task SelectedCarouselItem()
    {
        await OnActiveItem.InvokeAsync(CarouselItemIndex);
    }

    private async Task ViewMoreInfomation()
    {
        var parameters = new ModalParameters()
            .Add(nameof(AccountInfomationComponent.AccountItem), AccountItem);
        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };
        CardInfoItemComponentModalSvc.Show<AccountInfomationComponent>("Account Information", parameters, options);
    }

    private async Task SetFavouriteAccountInfo(bool isFavourite)
    {
        AccountItem.IsFavourite = isFavourite;
        await OnFavouriteItem.InvokeAsync(AccountItem);
    }
}
