using IFS.DB.WebApp.Helpers.CompnentConfiguration;
using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Models.Transactions;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using IFS.DB.WebApp.Helpers.Extensions;

namespace IFS.DB.WebApp.Shared.Components;

public partial class UpcomingTransactionsComponent
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

    private DataGridComponent<TransactionModel> _dataSourceGrid;
    private List<ColumnDefinition<TransactionModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;

    private UpcomingTransactionModel? _upcomingTransactionModel;
    private int _pageIndex = 1;
    private int _pageSize = 5;
    private string _searchString = string.Empty;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
    }

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
            if(IsCustomColumnsDefinition)
            {
                _columnsDefinition = CustomColumnsDefinition;
            }
            else
            {
                _columnsDefinition = new List<ColumnDefinition<TransactionModel>>();
                _columnsDefinition.AddRange(
                new ColumnDefinition<TransactionModel>[]{
                    new ColumnDefinition<TransactionModel>{ DataField = "ProductType", Caption="Type", FragmentTemplateFunc = IconTypeTemplate},
                    new ColumnDefinition<TransactionModel>{ DataField = "CreatedDate", Caption="DATE", Sortable = true, SortDirection = SortDirection.Desc, DataType = DataType.DateTime, Format = "MMMM dd, yyyy"},
                    new ColumnDefinition<TransactionModel>{ DataField = "Reference", Caption="REFERENCE", Sortable = true,SortDirection = SortDirection.NotSet},
                    new ColumnDefinition<TransactionModel>{ DataField = "Narrative", Caption="NARRATIVE" },
                    new ColumnDefinition<TransactionModel>{ DataField = "CreditAmount", Caption="IN", HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, CssClass = "custom-header-amount-column", ShowValueFunc = ReturnCreditAmountValue },
                    new ColumnDefinition<TransactionModel>{ DataField = "DebitAmount", Caption="OUT", HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, CssClass = "custom-header-amount-column", ShowValueFunc = ReturnDebitAmountValue },
                    new ColumnDefinition<TransactionModel>{ DataField = "Balance", Caption="BALANCE", HeaderAlignment = Alignment.Right, BodyAlignment = Alignment.Right, CssClass = "custom-header-amount-column", DataType = DataType.Currency, Format = "N2" }
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

    private async Task GetTransactions()
    {
        string jsonSize5Page1 = File.ReadAllText("wwwroot/default-data/pagesize5_upcomingtxns_page1.json");
        if (_pageIndex == 1)
            _upcomingTransactionModel = JsonSerializer.Deserialize<UpcomingTransactionModel>(jsonSize5Page1);
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

        StateHasChanged();
    }

    private string ReturnCreditAmountValue(TransactionModel transactionModel)
    {
        return transactionModel.CreditAmount.Equals(0) ? "" : transactionModel.CreditAmount.ToNumberFormat();
    }

    private string ReturnDebitAmountValue(TransactionModel transactionModel)
    {
        return transactionModel.DebitAmount.Equals(0) ? "" : transactionModel.DebitAmount.ToNumberFormat();
    }
}
