using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Customer;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Features.Admin.Pages;

public partial class CustomerMaintenance
{
    private EditContext? _searchEditContext;
    private SearchCustomerModel _searchModel = new();
    private List<CustomerTypeEnum> _listSelectedCustomerTypes = new();
    private bool _isSelectAllCustomerTypes = false;

    protected override async Task OnInitializedAsync()
    {
        _searchEditContext = new EditContext(_searchModel);
        _searchEditContext.SetFieldCssClassProvider(new CustomSearchFieldClassProvider());
        _searchEditContext.OnFieldChanged += EditContext_OnFieldChanged;
    }

    // Note: The OnFieldChanged event is raised for each field in the model
    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        
    }

    private async Task SelectedCustomerTypesValue(List<CustomerTypeEnum> selectedTypes)
    {
        _listSelectedCustomerTypes = selectedTypes;
    }

    private async Task SelectAllCustomerTypesValue(bool isRemoveItem = false)
    {
        _isSelectAllCustomerTypes = !_isSelectAllCustomerTypes;
        List<CustomerTypeEnum> listCustomerTypes = ((CustomerTypeEnum[])Enum.GetValues(typeof(CustomerTypeEnum))).Where(x => x != CustomerTypeEnum.All).ToList();
        if (isRemoveItem)
        {
            _listSelectedCustomerTypes.ForEach(x =>
            {
                if (!listCustomerTypes.Contains(x))
                {
                    _isSelectAllCustomerTypes = false;
                }
            });
        }

        if (_isSelectAllCustomerTypes)
        {
            _listSelectedCustomerTypes = new();

            foreach (var txnType in listCustomerTypes)
            {
                _listSelectedCustomerTypes.Add(txnType);
            }
        }
        else
        {
            _listSelectedCustomerTypes = new();
        }

        StateHasChanged();
    }

    private void RemoveSelectedCustomerType(CustomerTypeEnum selectedType)
    {
        _listSelectedCustomerTypes.Remove(selectedType);
    }

    private void ClearFilters()
    {
        _listSelectedCustomerTypes = new();
    }
}
