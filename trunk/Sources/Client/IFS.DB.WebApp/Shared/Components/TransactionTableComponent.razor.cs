using System.Text.Json;
using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Transactions;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class TransactionTableComponent
{
    private DataGridComponent<TransactionModel> _dataSourceGridRef;
    private List<ColumnDefinition<TransactionModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;

    private PaginatedModel<TransactionModel>? _paginatedTrans;
    private int _pageIndex = 1;
    private int _pageSize = 5;
    private string _searchString = string.Empty;
    private List<string> CustomPageSize { get; set; } = new() { "5", "10" };

    protected override async Task OnInitializedAsync()
    {
        ConfigGrid();
        await GetTransactions();
    }

    private void ConfigGrid()
    {
        _columnsDefinition = new List<ColumnDefinition<TransactionModel>>();
        _columnsDefinition.AddRange(
            new ColumnDefinition<TransactionModel>[]
            {
                new()
                {
                    DataField = "CreatedDate", Caption = "DATE", SortDirection = SortDirection.Desc, Sortable = true,
                    DataType = DataType.DateTime, Format = "MMMM dd, yyyy"
                },
                new() { DataField = "Reference", Caption = "REFERENCE", Sortable = false },
                new() { DataField = "Narrative", Caption = "NARRATIVE", Sortable = false },
                new()
                {
                    DataField = "CreditAmount", Caption = "IN", SortDirection = SortDirection.NotSet, Sortable = true,
                    HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right,
                    ShowValueFunc = (trans) =>
                    {
                        if (trans.CreditAmount == decimal.Zero)
                            return string.Empty;
                        return trans.CreditAmount.ToNumberFormat();
                    }
                },
                new()
                {
                    DataField = "DebitAmount", Caption = "OUT", SortDirection = SortDirection.NotSet, Sortable = true,
                    HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right,
                    ShowValueFunc = (trans) =>
                    {
                        if (trans.DebitAmount == decimal.Zero)
                            return string.Empty;
                        return trans.DebitAmount.ToNumberFormat();
                    }
                },
                new()
                {
                    DataField = "Balance", Caption = "BALANCE", SortDirection = SortDirection.NotSet, Sortable = true,
                    DataType = DataType.Currency, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right,
                    Format = "N2"
                }
            });

        _pagingConfig = new PagingConfig
        {
            Enabled = true,
            PageSize = _pageSize,
            CustomPager = false
        };
    }

    private async Task GetTransactions()
    {
        string jsonSize5Page1 = File.ReadAllText("wwwroot/default-data/txns.json");
        var result = JsonSerializer.Deserialize<PaginatedModel<TransactionModel>>(jsonSize5Page1);
        
        if (!string.IsNullOrEmpty(_searchString))
        {
            result.Items = result.Items
                .Where(x => x.Reference.ToLower().Contains(_searchString.ToLower()) ||
                            x.Narrative.ToLower().Contains(_searchString.ToLower())).ToList();
        }

        result.Items = result.Items.Skip((_pageIndex-1) * _pageSize).Take(_pageSize).ToList();

        _paginatedTrans = result;
    }

    private async Task GotoTransactionPage()
    {
        //_navigateManager.NavigateTo("/");
    }

    #region Invoke Pagination CallBack

    private async Task OnPrevPageChanged()
    {
        _pageIndex = _dataSourceGridRef.GotoPrevPage();
        await GetTransactions();
    }

    private async Task OnNextPageChanged()
    {
        _pageIndex = _dataSourceGridRef.GotoNextPage();
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
            _paginatedTrans.Items = _paginatedTrans.Items
                .OrderByDescending(x => x.GetType().GetProperty(columnDefinition.DataField).GetValue(x, null)).ToList();
        }

        if (columnDefinition.SortDirection == SortDirection.Asc)
        {
            _paginatedTrans.Items = _paginatedTrans.Items
                .OrderBy(x => x.GetType().GetProperty(columnDefinition.DataField).GetValue(x, null)).ToList();
        }

        // _dataSourceGridRef.OnStateHasChanged(columnDefinition.SortDirection);
        StateHasChanged();
    }

    private async void OnSearchDataChanged(ChangeEventArgs e)
    {
        _searchString = e.Value.ToString();
        await GetTransactions();

        if (!string.IsNullOrEmpty(_searchString))
        {
            _paginatedTrans.Items = _paginatedTrans.Items
                .Where(x => x.Reference.ToLower().Contains(_searchString.ToLower()) ||
                            x.Narrative.ToLower().Contains(_searchString.ToLower())).ToList();
        }

        StateHasChanged();
    }

    #endregion
}