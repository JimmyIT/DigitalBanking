using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Account;
using Microsoft.AspNetCore.Components;
using WMBlazorSlickCarousel.WMBSC;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CardInfoComponent
{
    [Parameter] public EventCallback<AccountModel> OnSelectedCardChange { get; set; }
    [Parameter] public EventCallback OnSetFavouriteAccountChange { get; set; }

    public BlazorSlickCarousel theCarousel;
    public WMBSCInitialSettings configurations;

    private List<AccountModel> _listAccounts;
    private AccountModel _selectedAccountModel = new();
    private int _selectedItemIndex = 0;
    private bool _enableArrows = false;

    protected override async Task OnInitializedAsync()
    {
        _listAccounts = FakeData.Accounts.OrderByDescending(x => x.IsFavourite).ThenBy(x => x.AccountDescription).ToList();
        _selectedAccountModel = _listAccounts[0];
        await WMBSCCarouselConfiguration();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await OnSelectedCardChange.InvokeAsync(_selectedAccountModel);
        }
    }

    private async Task WMBSCCarouselConfiguration()
    {
        if (_listAccounts.Count > 1)
            _enableArrows = true;
        // the carousel configurations
        configurations = new WMBSCInitialSettings
        {
            arrows = _enableArrows,
            dots = false,
            slidesToShow = 3,
            slidesToScroll = 1,
            infinite = false,
            centerMode = false,
            variableWidth = true,
            touchMove = false,
            swipe = false 
        };

        await Task.CompletedTask;
    }

    private async Task<int> CurrentSlide()
    {
        return await theCarousel.CurrentSlide();
    }

    private async Task GoTo(int slideNumber)
    {
        await theCarousel.GoTo(slideNumber);
    }

    private async Task Next()
    {
        await theCarousel.Next();
    }

    private async Task Prev()
    {
        await theCarousel.Prev();
    }

    private async Task Add(ElementReference newItem)
    {
        await theCarousel.Add(newItem);
    }

    private async Task Add(string newItem)
    {
        await theCarousel.Add(newItem);
    }

    private async Task Remove(int slideNumber, bool removeBefore)
    {
        await theCarousel.Remove(slideNumber, removeBefore);
    }

    private async Task Destroy()
    {
        await theCarousel.Destroy();
    }

    private async Task Constroy(WMBSCInitialSettings configurations)
    {
        await theCarousel.Constroy(configurations);
    }

    private async Task SetActiveCarouselItem(int selectedIndex)
    {
        _selectedItemIndex = selectedIndex;
        _selectedAccountModel = _listAccounts[_selectedItemIndex];
        await OnSelectedCardChange.InvokeAsync(_selectedAccountModel);
        await GoTo(_selectedItemIndex);
        StateHasChanged();
    }

    private async Task SetFavouriteItem(AccountModel changedAccountModel)
    {
        _listAccounts.ForEach(x =>
        {
            if (x.AccountNumber == changedAccountModel.AccountNumber)
            {
                x.IsFavourite = changedAccountModel.IsFavourite;                
            }
        });
        FakeData.Accounts = _listAccounts;
        await OnSetFavouriteAccountChange.InvokeAsync();
        
    }
}
