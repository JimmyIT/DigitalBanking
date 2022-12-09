using IFS.DB.OpenAPI.Client.Customers.IdentifySSE;
using IFS.DB.WebApp.Models.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FluentResults;
using IFS.DB.WebApp.Helpers.Extensions;
using static IFS.DB.WebApp.Features.Identity.Pages.IndividualSignin;
using IFS.DB.WebApp.Helpers.Constants;

namespace IFS.DB.WebApp.Shared.Components;

public partial class IndividualSigninStep1Component
{
    [Parameter, EditorRequired]
    public EventCallback<SigninStepsEnum> OnValueChanged { get; set; }

    [Parameter, EditorRequired]
    public EventCallback<IdentifySSECustomerResponse> SetSseCustomerIdentify { get; set; }

    [CascadingParameter(Name = "SseCustomerIdentify")]
    public IdentifySSECustomerResponse? SseCustomerIdentify { get; set; }

    private readonly UserSignInModel _userSignInModel;
    private readonly EditContext _editContext;
    private readonly ValidationMessageStore _messageStore;
    private InputText _txtCustomerIdRef = default!;
    public IndividualSigninStep1Component()
    {
        _userSignInModel = new UserSignInModel();
        _editContext = new EditContext(_userSignInModel);
        _messageStore = new ValidationMessageStore(_editContext);
    }

    protected override async Task OnInitializedAsync()
    {      
        _editContext.OnFieldChanged += delegate (object? sender, FieldChangedEventArgs args)
        {
            if (args.FieldIdentifier.Equals(_editContext.Field(nameof(_userSignInModel.CustomerID))))
            {
                _messageStore.Clear(_editContext.Field(nameof(_userSignInModel.CustomerID)));
            }
        };
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (_txtCustomerIdRef.Element != null)
                await _txtCustomerIdRef.Element.Value.FocusAsync();
        }
    }

    private async Task ProcessStep()
    {
        if (!_editContext.Validate())
            return;

        if (!_userSignInModel.CustomerID.Equals("customer"))
        {
            _messageStore.Clear();
            _messageStore.Add(_editContext.Field(nameof(_userSignInModel.CustomerID)), "You have entered an invalid Customer ID.");
            _editContext.NotifyValidationStateChanged();
            return;
        }

        var identifyRes = Result.Ok(new IdentifySSECustomerResponse
        {
            InternalId = "e68ec290-db23-4100-960e-dede8ffc2b1a",
            PasswordLength = 10
        });

        if (identifyRes.IsFailed)
        {
            _messageStore.Clear();
            _messageStore.Add(_editContext.Field(nameof(_userSignInModel.CustomerID)), L[identifyRes.Errors.FirstOrDefault().Metadata[ResultExtension.ErrorCode].ToString()]);
            _editContext.NotifyValidationStateChanged();
            return;
        }

        _userSignInModel.Role = UserRoles.SSECustomer;
        _userSignInModel.UserID = "user_01";
        _userSignInModel.ClientNumber = "00067";
        _userSignInModel.CustomerID = "sse_user";
    
        await _localStorageSvc.SetItemAsync("Identity", _userSignInModel);

        await SetSseCustomerIdentify.InvokeAsync(identifyRes.Value);

        await OnValueChanged.InvokeAsync(SigninStepsEnum.SecondStep);
    }
}
