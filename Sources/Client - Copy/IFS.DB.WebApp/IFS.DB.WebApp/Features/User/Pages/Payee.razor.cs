using Blazored.Modal;
using Blazored.Modal.Services;
using IFS.DB.WebApp.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Features.User.Pages;

public partial class Payee
{
    [CascadingParameter] IModalService PayeeModalSvc { get; set; } = default!;


    private void onShowModalNewPayee()
    {
        var options = new ModalOptions()
        {
            UseCustomLayout = true
        };
        PayeeModalSvc.Show<NewPayeeModalComponent>("Create new payee", options);
    }
}
