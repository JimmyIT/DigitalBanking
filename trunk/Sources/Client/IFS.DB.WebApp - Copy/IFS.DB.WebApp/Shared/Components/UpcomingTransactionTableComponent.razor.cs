﻿using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models.Transactions;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Reflection;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UpcomingTransactionTableComponent
{
    private DataGridComponent<TransactionModel> _dataSourceGrid;
    private List<ColumnDefinition> _columnsDefinition;
    private PagingConfig _pagingConfig;

    private UpcomingTransactionModel _upcomingTransactionModel;
    private int _pageIndex = 1;
    private int _pageSize = 5;
    private string _searchString = string.Empty;
    private List<string> CustomPageSize { get; set; } = new List<string> { "5", "10" };

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await InitializeDataSourceGrid();
        await GetTransactions();
    }

    private async Task InitializeDataSourceGrid()
    {
        await Task.Run(() =>
        {
            if (_columnsDefinition == null)
            {
                _columnsDefinition = new List<ColumnDefinition>();
                _columnsDefinition.AddRange(
                new ColumnDefinition[]{
                    new ColumnDefinition{ DataField = "CreatedDate", Caption="DATE", SortDirection = SortDirection.Asc, DataType = DataType.DateTime, Format = "MMMM dd, yyyy"},
                    new ColumnDefinition{ DataField = "Reference", Caption="REFERENCE", SortDirection = SortDirection.Asc},
                    new ColumnDefinition{ DataField = "Narrative", Caption="NARRATIVE"},
                    new ColumnDefinition{ DataField = "CreditAmount", Caption="IN", DataType = DataType.Currency, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, Format = "c"},
                    new ColumnDefinition{ DataField = "DebitAmount", Caption="OUT", DataType = DataType.Currency, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, Format = "c" },
                    new ColumnDefinition{ DataField = "Balance", Caption="BALANCE", DataType = DataType.Currency, HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, Format = "c" }
                    });

            }

            _pagingConfig = new PagingConfig()
            {
                Enabled = true,
                PageSize = @_pageSize,
                CustomPager = true
            };
        });
    }

    private async Task GetTransactions()
    {
        try
        {
            if (_pageSize == 5)
            {
                if (_pageIndex == 1)
                    _upcomingTransactionModel = await _httpClient.GetFromJsonAsync<UpcomingTransactionModel>("sample-data/pagesize5_upcomingtxns_page1.json");

                if (_pageIndex == 2)
                    _upcomingTransactionModel = await _httpClient.GetFromJsonAsync<UpcomingTransactionModel>("sample-data/pagesize5_upcomingtxns_page2.json");

                if (_pageIndex == 3)
                    _upcomingTransactionModel = await _httpClient.GetFromJsonAsync<UpcomingTransactionModel>("sample-data/pagesize5_upcomingtxns_page3.json");
            }

            if (_pageSize == 10)
            {
                if (_pageIndex == 1)
                    _upcomingTransactionModel = await _httpClient.GetFromJsonAsync<UpcomingTransactionModel>("sample-data/pagesize10_upcomingtxns_page1.json");

                if (_pageIndex == 2)
                    _upcomingTransactionModel = await _httpClient.GetFromJsonAsync<UpcomingTransactionModel>("sample-data/pagesize10_upcomingtxns_page2.json");
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
        _pageIndex = _dataSourceGrid.GotoSelectedPage(pageIndex);
        await GetTransactions();
    }

    private async void OnSortDataChanged(ColumnDefinition columnDefinition)
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
