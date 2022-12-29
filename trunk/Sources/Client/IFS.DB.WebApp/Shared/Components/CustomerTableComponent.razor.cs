using IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Customer;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class CustomerTableComponent
{
    [Parameter] public SearchCustomerModel SearchData { get; set; }

    private DataGridComponent<CustomerInfoModel> _dataSourceGrid;
    private List<ColumnDefinition<CustomerInfoModel>> _columnsDefinition;
    private PagingConfig _pagingConfig;
    private CustomerMaintenanceModel _customerMaintenance;

    protected override async Task OnParametersSetAsync()
    {
        _customerMaintenance = FakeData.CustomerMaintenance with { };
        if(SearchData != null)
        {
            List<CustomerInfoModel> _tempListCustomers = new List<CustomerInfoModel>();

            if (SearchData.Types.Count > 0)
            {
                SearchData.Types.ForEach(cusType =>
                {
                    _tempListCustomers.AddRange(_customerMaintenance.Customers.Where(cus => cus.Type == cusType).ToList());
                });

                if (!string.IsNullOrEmpty(SearchData.SearchString))
                {
                    _tempListCustomers = _tempListCustomers.Where(cus => cus.Address.ToLower().Contains(SearchData.SearchString.ToLower())).ToList();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(SearchData.SearchString))
                {
                    _tempListCustomers = _customerMaintenance.Customers.Where(cus => cus.Address.ToLower().Contains(SearchData.SearchString.ToLower())).ToList();
                }
                else
                {
                    _tempListCustomers = _customerMaintenance.Customers;
                }
            }

            _customerMaintenance.Customers = _tempListCustomers;
            _customerMaintenance.TotalRecords = _tempListCustomers.Count();
        }
        await base.OnParametersSetAsync();
    }

    protected override async Task OnInitializedAsync()
    {
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
