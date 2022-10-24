using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace IFS.DB.WebApp.Shared.Components;

public partial class DataGridComponent<TItem> : ComponentBase
{
    #region Components properties

    [Parameter] public PagingConfig PagingConfig { get; set; }
    [Parameter] public List<TItem> DataItems { get; set; }
    [Parameter] public List<ColumnDefinition> Columns { get; set; }
    [Parameter] public List<string> CustomPageSize { get; set; } = new List<string> { "10", "20", "50", "100" };
    [Parameter] public RenderFragment CustomHtmlPager { get; set; }
    [Parameter] public RenderFragment CustomTableFooter { get; set; }
    [Parameter] public int CurrentPageNumber { get; set; } = 1;
    [Parameter] public int TotalItems { get; set; }
    [Parameter] public EventCallback OnPrevPageClickCallback { get; set; }
    [Parameter] public EventCallback OnNextPageClickCallback { get; set; }
    [Parameter] public EventCallback OnFirstPageClickCallback { get; set; }
    [Parameter] public EventCallback OnLastPageClickCallback { get; set; }
    [Parameter] public EventCallback<int> OnPageSizeChangedCallback { get; set; }
    [Parameter] public EventCallback<ColumnDefinition> OnSortDataChangedCallback { get; set; }

    #endregion

    #region Pagination properties

    public int PageSize { get => PagingConfig.NumberOfItemToTake(TotalItems); }
    public int PageIndex { get => PagingConfig.NumberOfItemToTake(TotalItems); }   
    public int FirstPage { get => 1; }
    public int LastPage { get => PagingConfig.MaxPageNumber(TotalItems); }
    public int TotalPages { get => PagingConfig.MaxPageNumber(TotalItems); }

    #endregion

    #region Pagination Callback Event Functions

    /// <summary>
    /// event mouse click call back to go to the back prev page index
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    protected async Task PrevPageChanged(MouseEventArgs e)
    {
        await OnPrevPageClickCallback.InvokeAsync();
    }

    /// <summary>
    /// event mouse click call back to go to the next page index
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    protected async Task NextPageChanged(MouseEventArgs e)
    {
        await OnNextPageClickCallback.InvokeAsync();
    }

    /// <summary>
    /// event mouse click call back to go to the first page index
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    protected async Task FirstPageChanged(MouseEventArgs e)
    {
        await OnFirstPageClickCallback.InvokeAsync();
    }

    /// <summary>
    /// event mouse click call back to go to the last page index
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    protected async Task LastPageChanged(MouseEventArgs e)
    {
        await OnLastPageClickCallback.InvokeAsync();
    }

    /// <summary>
    /// event mouse click call back to load grid when the page size is changed
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    protected async Task PageSizeChanged(ChangeEventArgs e)
    {
        await OnPageSizeChangedCallback.InvokeAsync(int.Parse(e.Value.ToString()));
    }

    /// <summary>
    /// event mouse click call back to load grid when the page size is changed
    /// </summary>
    /// <param name="clumnDefinition"></param>
    /// <returns></returns>
    protected async Task SortDataChanged(ColumnDefinition clumnDefinition)
    {
        await OnSortDataChangedCallback.InvokeAsync(clumnDefinition);
    }

    #endregion

    #region Function For Custom Pagination

    public int GotoPrevPage()
    {
        CurrentPageNumber = PagingConfig.PrevPageNumber(CurrentPageNumber);
        return CurrentPageNumber;
    }

    public int GotoNextPage()
    {
        CurrentPageNumber = PagingConfig.NextPageNumber(CurrentPageNumber, TotalItems);
        return CurrentPageNumber;
    }

    public int GotoFirstPage()
    {
        CurrentPageNumber = FirstPage;
        return CurrentPageNumber;
    }

    public int GotoLastPage()
    {
        CurrentPageNumber = LastPage;
        return CurrentPageNumber;
    }

    public int GotoSelectedPage(int selectedPageIndex)
    {
        CurrentPageNumber = selectedPageIndex;
        return CurrentPageNumber;
    }

    public void OnStateHasChanged(SortDirection sortDirection)
    {
        foreach (var item in Columns)
        {
            if(item.SortDirection != SortDirection.NotSet)
            {
                switch (sortDirection)
                {
                    case SortDirection.Asc:
                        {
                            item.SortDirection = SortDirection.Desc;
                            break;
                        }
                    case SortDirection.Desc:
                    case SortDirection.NotSet:
                    default:
                        {
                            item.SortDirection = SortDirection.Asc;
                            break;
                        }
                }
            }            
        }
        StateHasChanged();
    }

    #endregion

    #region Add Sort CssClass

    private string SortClass(ColumnDefinition columnDefinition)
    {
        if (columnDefinition.SortDirection != SortDirection.NotSet)
        {
            return $"sort {columnDefinition.SortDirection.ToString().ToLower()}";
        }
        return "no-sort";
    }

    #endregion
}
