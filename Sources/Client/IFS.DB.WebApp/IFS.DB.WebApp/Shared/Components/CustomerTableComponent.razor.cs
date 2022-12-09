using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Customer;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CustomerTableComponent
{
    private DataGridComponent<CustomerInfoModel> _dataSourceGrid;
    private List<ColumnDefinition<CustomerInfoModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;
    private CustomerMaintenanceModel _customerMaintenance;

    protected override async Task OnInitializedAsync()
    {
        _customerMaintenance = FakeData.CustomerMaintenance with { };
        await InitializeDataSourceGrid();
        await base.OnInitializedAsync();
    }

    private async Task InitializeDataSourceGrid()
    {
        if (_columnsDefinition == null)
        {
            _columnsDefinition = new List<ColumnDefinition<CustomerInfoModel>>();
            _columnsDefinition.AddRange(
            new ColumnDefinition<CustomerInfoModel>[]{
                    new() { Caption="Group Name", DataField = "CustomerName" },
                    new() 
                    { 
                        Caption="Type", 
                        ShowValueFunc = (customer) => 
                        {                            
                            return customer.Type.ToDescription();
                        }
                    },
                    new() { Caption="Address", DataField = "Address" },
                    new() 
                    { 
                        Caption="Number of Accounts",
                        ShowValueFunc = (customer) =>
                        {
                            return (customer.Accounts.Count()).ToString();
                        }
                    },
                    new() 
                    {
                        Caption="Issues", 
                        ShowValueFunc = (customer) =>
                        {
                            return string.Empty;
                        } 
                    },
                    new() 
                    { 
                        Caption="",
                        FragmentTemplateFunc = ButtonActionTemplate
                    },
            });
        }

        _pagingConfig = new PagingConfig()
        {
            Enabled = true,
            PageSize = 10,
            CustomPager = false
        };

        await Task.CompletedTask;
    }
}
