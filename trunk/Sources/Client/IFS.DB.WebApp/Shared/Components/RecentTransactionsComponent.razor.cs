using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Transactions;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Helpers.Enums;

namespace IFS.DB.WebApp.Shared.Components;

public partial class RecentTransactionsComponent
{
    [Parameter, EditorRequired] public string AccountNumber { get; set; }
    [Parameter] public bool AllowClientSearch { get; set; } = false;
    [Parameter] public bool AllowServerSearch { get; set; } = false;
    [Parameter] public bool IsPagination { get; set; } = false;
    [Parameter] public bool IsCustomPager { get; set; } = false;
    [Parameter] public RenderFragment CustomPager { get; set; }
    [Parameter] public bool IsCustomColumnsDefinition { get; set; } = false;
    [Parameter] public List<ColumnDefinition<TransactionModel>> CustomColumnsDefinition { get; set; }
    [Parameter] public string Title { get; set; }
    [Parameter] public bool ChangablePageSize { get; set; } = false;

    private DataGridComponent<TransactionModel> _dataSourceGrid;
    private List<ColumnDefinition<TransactionModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;

    private RecentTransactionModel? _recentTransactionModel;
    private int _pageIndex = 1;
    private int _pageSize = 5;
    private string _searchString = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await InitializeDataSourceGrid();
        await GetTransactions();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {

        }
    }

    private async Task InitializeDataSourceGrid()
    {
        if (_columnsDefinition == null)
        {
            if (IsCustomColumnsDefinition)
            {
                _columnsDefinition = CustomColumnsDefinition;
            }
            else
            {
                _columnsDefinition = new List<ColumnDefinition<TransactionModel>>();
                _columnsDefinition.AddRange(
                new ColumnDefinition<TransactionModel>[]{
                    new () { DataField = "ProductType", Caption="Type", FragmentTemplateFunc = IconTypeTemplate},
                    new () { DataField = "CreatedDate", Caption="DATE", Sortable = true, SortDirection = SortDirection.Desc, DataType = DataType.DateTime, Format = "MMMM dd, yyyy"},
                    new () { DataField = "Reference", Caption="REFERENCE", Sortable = true, SortDirection = SortDirection.NotSet},
                    new () { DataField = "Narrative", Caption="NARRATIVE" },
                    new () { DataField = "CreditAmount", Caption="IN", HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, CssClass = "custom-header-amount-column", ShowValueFunc = ReturnCreditAmountValue },
                    new () { DataField = "DebitAmount", Caption="OUT", HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, CssClass = "custom-header-amount-column", ShowValueFunc = ReturnDebitAmountValue },
                    new () { DataField = "Balance", Caption="BALANCE", HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, CssClass = "custom-header-amount-column", DataType = DataType.Currency, Format = "N2" }
                    });

            }
        }

        _pagingConfig = new PagingConfig()
        {
            Enabled = IsPagination,
            PageSize = @_pageSize,
            CustomPager = IsCustomPager
        };

        await Task.CompletedTask;
    }

    private async Task GetTransactions(bool isSearching = false)
    {
        if (isSearching)
        {
            _recentTransactionModel = FakeData.RecentTransaction_All with { };
        }
        else
        {
            if (_pageIndex == 1)
                _recentTransactionModel = FakeData.RecentTransaction_Page1 with { };

            if (_pageIndex == 2)
                _recentTransactionModel = FakeData.RecentTransaction_Page2 with { };

            if (_pageIndex == 3)
                _recentTransactionModel = FakeData.RecentTransaction_Page3 with { };
        }
    }

    #region Invoke Pagination CallBack

    private async Task OnPrevPageChanged()
    {
        _pageIndex = _dataSourceGrid.GotoPrevPage();
        await GetTransactions();
    }

    private async Task OnNextPageChanged()
    {
        _pageIndex = _dataSourceGrid.GotoNextPage();
        await GetTransactions();
    }

    private async Task OnPageSizeChanged(int pageSize)
    {
        _pageSize = pageSize;
        await GetTransactions(true);
        _recentTransactionModel.TotalRecords = _recentTransactionModel.RecentTransactions.Count();
        _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions.Take(_pageSize).ToList();
    }

    private async Task OnPageIndexChanged(int pageIndex)
    {
        _pageIndex = pageIndex;
        await GetTransactions();
    }

    private async void OnSortDataChanged(ColumnDefinition<TransactionModel> columnDefinition)
    {
        await GetTransactions();

        if (columnDefinition.SortDirection == SortDirection.Desc)
        {
            _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                .OrderByDescending(x => x.GetType().GetProperty(columnDefinition.DataField).GetValue(x, null)).ToList();

        }

        if (columnDefinition.SortDirection == SortDirection.Asc)
        {
            _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                .OrderBy(x => x.GetType().GetProperty(columnDefinition.DataField).GetValue(x, null)).ToList();
        }

        StateHasChanged();
    }

    private async void OnSearchDataChanged(ChangeEventArgs e)
    {
        _searchString = e.Value.ToString();
        await GetTransactions();

        if (!string.IsNullOrEmpty(_searchString))
        {
            _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                .Where(x => x.Reference.ToLower().Contains(_searchString.ToLower()) || x.Narrative.ToLower().Contains(_searchString.ToLower())).ToList();
        }

        StateHasChanged();
    }

    #endregion

    private string ReturnCreditAmountValue(TransactionModel transactionModel)
    {
        return transactionModel.CreditAmount.Equals(0) ? "" : transactionModel.CreditAmount.ToNumberFormat();
    }

    private string ReturnDebitAmountValue(TransactionModel transactionModel)
    {
        return transactionModel.DebitAmount.Equals(0) ? "" : transactionModel.DebitAmount.ToNumberFormat();
    }

    public async Task SearchAsync(SearchTransactionModel searchModel)
    {
        _pageIndex = 1;
        _pageSize = 5;

        if (!string.IsNullOrEmpty(searchModel.AccountNumber))
        {
            await GetTransactions(isSearching: true);

            _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
               .Where(x => x.AccountNumber.ToLower().Equals(searchModel.AccountNumber.ToLower())).ToList();

            if (searchModel.ProductType != ProductTypeEnum.All)
            {
                _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                    .Where(x => x.ProductType == searchModel.ProductType).ToList();
            }

            if (searchModel.TransactionType != TransactionTypeEnum.All)
            {
                _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                    .Where(x => x.TransactionType == searchModel.TransactionType).ToList();
            }

        }
        else
        {
            await GetTransactions();             
        }

        if (!string.IsNullOrEmpty(searchModel.SearchString))
        {
            _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                .Where(x => x.Reference.Contains(searchModel.SearchString) || x.Narrative.Contains(searchModel.SearchString)).ToList();
        }

        if(searchModel.FromAmount.HasValue && searchModel.ToAmount.HasValue)
        {
            _recentTransactionModel.RecentTransactions = _recentTransactionModel.RecentTransactions
                .Where(x => x.CreditAmount >= searchModel.FromAmount && x.CreditAmount <= searchModel.ToAmount).ToList();
        }

        _recentTransactionModel.TotalRecords = _recentTransactionModel.RecentTransactions.Count();
        StateHasChanged();
    }
}
