using Blazored.Modal;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.PayeeTemplate;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class NewPayeeModalComponent
{
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;

    private EditContext _createPayeeContext;
    private ValidationMessageStore _messageStore;
    private CreatePayeeRequestModel _createPayeeModel = new();

    protected override async Task OnInitializedAsync()
    {
        _createPayeeContext = new EditContext(_createPayeeModel);
        _createPayeeContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _messageStore = new ValidationMessageStore(_createPayeeContext);
    }

    private async Task Close() => await BlazoredModal.CloseAsync();

    private async void CreatePayee()
    {
        await Close();
    }

    private void InvalidSubmit()
    {

    }
}
