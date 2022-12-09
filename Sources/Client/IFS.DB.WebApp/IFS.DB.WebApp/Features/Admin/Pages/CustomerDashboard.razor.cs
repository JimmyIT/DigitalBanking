using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Helpers.Attributes;
using IFS.DB.WebApp.Helpers.Extensions;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Account;
using IFS.DB.WebApp.Models.Customer;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class CustomerDashboard
{
    [CascadingParameter] IModalService ModalSvc { get; set; } = default!;
    [QueryStringParameter] public string CustomerID { get; set; }

    private CustomerMaintenanceModel _customerMaintenance = FakeData.CustomerMaintenance;
    private string? _selectedCustomerID;
    private CustomerInfoModel? _selectedCustomer;
    private AccountModel _accountModel = new();

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        // 👇 Read the value of each property decorated by [QueryStringParameter] from the query string
        this.SetParametersFromQueryString(_navigateManager);
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if (!await IsCustomerExist())
        {
            await ErrorMessageShow("Error", $"The customer {CustomerID} is not exist");
            return;
        }

        _selectedCustomerID = CustomerID;
        _selectedCustomer = _customerMaintenance.Customers.Where(cus => cus.CustomerID == _selectedCustomerID).FirstOrDefault();
    }

    private async Task<bool> IsCustomerExist()
    {
        if(string.IsNullOrEmpty(CustomerID))
            return false;

        if (_customerMaintenance.Customers.Where(cus => cus.CustomerID == _selectedCustomerID) == null)
            return false;

        return true;
    }

    private async Task SelectedCardChange(AccountModel accountModel)
        => _accountModel = accountModel;

    private async Task SetFavouriteAccountChange()
        => _navigateManager.NavigateTo(_navigateManager.Uri, forceLoad: true);


    private async Task ErrorMessageShow(string modalTitle, string modalMsg)
    {
        ModalParameters parameters = new ModalParameters()
            .Add(nameof(CommonModalComponent.Message), $"{modalTitle}")
            .Add(nameof(CommonModalComponent.HeaderLabel), $"{modalTitle}")
            .Add(nameof(CommonModalComponent.UseButtonOk), true)
            .Add(nameof(CommonModalComponent.EventOkClick), EventCallback.Factory.Create(this, NavigateTo));

        var options = new ModalOptions
        {
            UseCustomLayout = true
        };
        ModalSvc.Show<CommonModalComponent>($"{modalTitle}", parameters, options);
    }

    private async Task NavigateTo()
        => _navigateManager.NavigateTo("/customer-maintenance");
}