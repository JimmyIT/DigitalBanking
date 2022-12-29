using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models;
using IFS.DB.WebApp.Models.Account;
using IFS.DB.WebApp.Models.Transactions;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components.Forms;
using TransactionTypeEnum = IFS.DB.WebApp.Helpers.Enums.TransactionTypeEnum;

namespace IFS.DB.WebApp.Features.User.Pages;

public partial class History
{
    private RecentTransactionsComponent _recentTransactionsComponent;
    private EditContext? _searchEditContext;
    private ValidationMessageStore _messageStore;
    private SearchTransactionModel _searchTransactionModel = new();
    private string _selectedAccountNumber = string.Empty;
    private string _searchString = string.Empty;
    private bool _isSettingFilter = false;
    private bool _isSettingAction = false;
    private string _styleToDisplayFilter = "display: none;";
    private string _styleToDisplayAction = "display: none;";
    private List<AccountModel> _listAccounts;
    private List<ProductTypeEnum> _listSelectedProductSearchTypes = new();
    private List<TransactionTypeEnum> _listSelectedTransactionSearchTypes = new();
    private AccountModel _selectedAccount = new();
    private bool _selectAllProductType = false;
    private bool _selectAllTransactionType = false;
    private bool _isClearFilter = false;

    private bool _isCorrectRangeAmount = true;

    protected override async Task OnInitializedAsync()
    {
        _searchEditContext = new EditContext(_searchTransactionModel);
        _searchEditContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_searchEditContext);
        _searchEditContext.OnFieldChanged += EditContext_OnFieldChanged;

        _listAccounts = FakeData.Accounts;
    }

    private async Task OnValidSubmit()
    {

    }

    private async Task OnInValidSubmit()
    {

    }

    private async Task OnClickFilterIcon()
    {
        _isSettingFilter = !_isSettingFilter;
        if (_isSettingFilter)
            _styleToDisplayFilter = "display: block;";
        else
        { 
            _styleToDisplayFilter = "display: none;";
            ClearFilters();
        }
    }

    private async Task OnClickActionIcon()
    {
        _isSettingAction = !_isSettingAction;
        if (_isSettingAction)
            _styleToDisplayAction = "display: block;";
        else
            _styleToDisplayAction = "display: none;";
    }

    private async Task OutfocusClickActionIcon()
    {
        _isSettingAction = false;
        _styleToDisplayAction = "display: none;";
    }


    // Note: The OnFieldChanged event is raised for each field in the model
    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        _messageStore.Clear();
        if (!string.IsNullOrEmpty(_searchTransactionModel.AccountNumber))
        {
            _selectedAccount = _listAccounts.FirstOrDefault(x => x.AccountNumber == _searchTransactionModel.AccountNumber);
        }
        else
        {
            //_isSettingFilter = false;
            //_styleToDisplayFilter = "display: none;";
            _selectedAccount = new();
        }

        if(_searchTransactionModel.FromAmount.HasValue && !_searchTransactionModel.ToAmount.HasValue)
        {
            _isCorrectRangeAmount = false;
            _messageStore.Add(_searchEditContext.Field("ToAmount"), "To amount is required.");
            _searchEditContext.NotifyValidationStateChanged();
            StateHasChanged();
        }
        else if (_searchTransactionModel.ToAmount.HasValue && !_searchTransactionModel.FromAmount.HasValue)
        {
            _isCorrectRangeAmount = false;
            _messageStore.Add(_searchEditContext.Field("FromAmount"), "From amount is required.");
            _searchEditContext.NotifyValidationStateChanged();
            StateHasChanged();
        }
        else if (_searchTransactionModel.ToAmount.HasValue && _searchTransactionModel.FromAmount.HasValue)
        {
            if(_searchTransactionModel.ToAmount.Value < _searchTransactionModel.FromAmount.Value)
            {
                _isCorrectRangeAmount = false;
                _messageStore.Add(_searchEditContext.Field("ToAmount"), "To amount could not be less than From amount.");
                _searchEditContext.NotifyValidationStateChanged();
                StateHasChanged();
            }
            else
            {
                _isCorrectRangeAmount = true;
                StateHasChanged();
            }
        }        

        if (_searchEditContext.GetValidationMessages().Any())
        {
            return;
        }

        await _recentTransactionsComponent.SearchAsync(_searchTransactionModel);
    }

    private async Task Search()
    {
        if (_searchEditContext.GetValidationMessages().Any())
        {
            return;
        }
        _searchTransactionModel.SearchString = _searchString;
        await _recentTransactionsComponent.SearchAsync(_searchTransactionModel);
    }

    private void RemoveSelectedProductTypes(ProductTypeEnum selectedType)
    {
        _listSelectedProductSearchTypes.Remove(selectedType);
    }

    private void RemoveSelectedTransactionType(TransactionTypeEnum selectedType)
    {
        _listSelectedTransactionSearchTypes.Remove(selectedType);
    }

    private void ClearFilters()
    {
        _isClearFilter = !_isClearFilter;
        _selectAllProductType = false;
        _listSelectedProductSearchTypes = new List<ProductTypeEnum>();
        _listSelectedTransactionSearchTypes = new List<TransactionTypeEnum>();
        _searchTransactionModel.FromAmount = null;
        _searchTransactionModel.ToAmount = null;
    }
    private async Task SelectedTransactionTypesValue(List<TransactionTypeEnum> selectedTypes)
    {
        _listSelectedTransactionSearchTypes = selectedTypes;
    }

    private async Task SelectAllTransactionTypesValue(bool isRemoveItem = false)
    {
        _selectAllTransactionType = !_selectAllTransactionType;
        List<TransactionTypeEnum> listTxnTypesEnums = ((TransactionTypeEnum[])Enum.GetValues(typeof(TransactionTypeEnum))).Where(x => x != TransactionTypeEnum.All).ToList();
        if (isRemoveItem)
        {
            _listSelectedTransactionSearchTypes.ForEach(x =>
            {
                if (!listTxnTypesEnums.Contains(x))
                {
                    _selectAllTransactionType = false;
                }
            });
        }

        if (_selectAllTransactionType)
        {
            _listSelectedTransactionSearchTypes = new();

            foreach (var txnType in listTxnTypesEnums)
            {
                _listSelectedTransactionSearchTypes.Add(txnType);
            }
        }
        else
        {
            _listSelectedTransactionSearchTypes = new();
        }

        StateHasChanged();
    }

    private async Task SelectedProductTypesValue(List<ProductTypeEnum> selectedTypes)
    {
        _listSelectedProductSearchTypes = selectedTypes;
    }

    private async Task SelectAllProductTypesValue(bool isRemoveItem = false)
    {
        _selectAllProductType = !_selectAllProductType;
        List<ProductTypeEnum> listProductTypeEnums = ((ProductTypeEnum[])Enum.GetValues(typeof(ProductTypeEnum))).Where(x => x != ProductTypeEnum.All).ToList();
        if (isRemoveItem)
        {
            _listSelectedProductSearchTypes.ForEach(x =>
            {
                if (!listProductTypeEnums.Contains(x))
                {
                    _selectAllProductType = false;
                }
            });
        }

        if (_selectAllProductType)
        {
            _listSelectedProductSearchTypes = new();

            foreach(var productType in listProductTypeEnums)
            {
                _listSelectedProductSearchTypes.Add(productType);
            }
        }
        else
        {
            _listSelectedProductSearchTypes = new();
        }

        StateHasChanged();
    }
}
