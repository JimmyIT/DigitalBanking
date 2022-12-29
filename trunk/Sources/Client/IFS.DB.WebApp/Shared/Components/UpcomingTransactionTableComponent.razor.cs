using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models.Transactions;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UpcomingTransactionTableComponent
{
    private DataGridComponent<TransactionModel> _dataSourceGrid;
    private List<ColumnDefinition<TransactionModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;

    private UpcomingTransactionModel? _upcomingTransactionModel;
    private int _pageIndex = 1;
    private int _pageSize = 5;
    private string _searchString = string.Empty;
    private List<string> CustomPageSize { get; set; } = new List<string> { "5", "10" };

    protected override async Task OnInitializedAsync()
    {
        await InitializeDataSourceGrid();
        await GetTransactions();
    }

    private async Task InitializeDataSourceGrid()
    {
        if (_columnsDefinition == null)
        {
            _columnsDefinition = new List<ColumnDefinition<TransactionModel>>();
            _columnsDefinition.AddRange(
            new ColumnDefinition<TransactionModel>[]{
                    new () { DataField = "CreatedDate", Caption="DATE", SortDirection = SortDirection.Asc, DataType = DataType.DateTime, Format = "MMMM dd, yyyy"},
                    new () { DataField = "Reference", Caption="REFERENCE", SortDirection = SortDirection.Asc},
                    new () { DataField = "Narrative", Caption="NARRATIVE", SortDirection = SortDirection.Asc,},
                    new () { DataField = "CreditAmount", Caption="IN", SortDirection = SortDirection.Asc, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right },
                    new () { DataField = "DebitAmount", Caption="OUT", SortDirection = SortDirection.Asc, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right },
                    new () { DataField = "Balance", Caption="BALANCE", SortDirection = SortDirection.Asc,  DataType = DataType.Currency, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, Format = "N2" }
                });

        }

        _pagingConfig = new PagingConfig()
        {
            Enabled = false,
            PageSize = @_pageSize,
            CustomPager = true
        };

        await Task.CompletedTask;
    }

    private async Task GetTransactions()
    {
        try
        {
            if (_pageSize == 5)
            {
                string jsonSize5Page1 = File.ReadAllText("wwwroot/default-data/pagesize5_upcomingtxns_page1.json");
                string jsonSize5Page2 = File.ReadAllText("wwwroot/default-data/pagesize5_upcomingtxns_page2.json");
                string jsonSize5Page3 = File.ReadAllText("wwwroot/default-data/pagesize5_upcomingtxns_page3.json");
                if (_pageIndex == 1)
                    _upcomingTransactionModel = JsonSerializer.Deserialize<UpcomingTransactionModel>(jsonSize5Page1);

                if (_pageIndex == 2)
                    _upcomingTransactionModel = JsonSerializer.Deserialize<UpcomingTransactionModel>(jsonSize5Page2);

                if (_pageIndex == 3)
                    _upcomingTransactionModel = JsonSerializer.Deserialize<UpcomingTransactionModel>(jsonSize5Page3);
            }

            if (_pageSize == 10)
            {
                string jsonSize10Page1 = File.ReadAllText("wwwroot/default-data/pagesize10_upcomingtxns_page1.json");
                string jsonSize10Page2 = File.ReadAllText("wwwroot/default-data/pagesize10_upcomingtxns_page2.json");
                if (_pageIndex == 1)
                    _upcomingTransactionModel = JsonSerializer.Deserialize<UpcomingTransactionModel>(jsonSize10Page1);

                if (_pageIndex == 2)
                    _upcomingTransactionModel = JsonSerializer.Deserialize<UpcomingTransactionModel>(jsonSize10Page2);
            }

            if (!string.IsNullOrEmpty(_searchString))
            {
                _upcomingTransactionModel.UpcomingTransactions = _upcomingTransactionModel.UpcomingTransactions
                    .Where(x => x.Reference.ToLower().Contains(_searchString.ToLower()) || x.Narrative.ToLower().Contains(_searchString.ToLower())).ToList();
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }

    private async Task GotoTransactionPage()
    {
        //_navigateManager.NavigateTo("/");
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
        await GetTransactions();
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
            _upcomingTransactionModel.UpcomingTransactions = _upcomingTransactionModel.UpcomingTransactions
                .OrderByDescending(x => x.GetType().GetProperty(columnDefinition.DataField).GetValue(x, null)).ToList();

        }

        if (columnDefinition.SortDirection == SortDirection.Asc)
        {
            _upcomingTransactionModel.UpcomingTransactions = _upcomingTransactionModel.UpcomingTransactions
                .OrderBy(x => x.GetType().GetProperty(columnDefinition.DataField).GetValue(x, null)).ToList();
        }

        _dataSourceGrid.OnStateHasChanged(columnDefinition.SortDirection);
        StateHasChanged();
    }

    private async void OnSearchDataChanged(ChangeEventArgs e)
    {
        _searchString = e.Value.ToString();
        await GetTransactions();

        if (!string.IsNullOrEmpty(_searchString))
        {
            _upcomingTransactionModel.UpcomingTransactions = _upcomingTransactionModel.UpcomingTransactions
                .Where(x => x.Reference.ToLower().Contains(_searchString.ToLower()) || x.Narrative.ToLower().Contains(_searchString.ToLower())).ToList();
        }

        StateHasChanged();
    }

    #endregion
}
