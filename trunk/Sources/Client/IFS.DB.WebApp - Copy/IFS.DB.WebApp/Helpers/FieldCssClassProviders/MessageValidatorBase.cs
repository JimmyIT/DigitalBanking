using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace IFS.DB.WebApp.Helpers.FieldCssClassProviders;

public class MessageValidatorBase<TValue> : ComponentBase, IDisposable
{
    private FieldIdentifier _fieldIdentifier;
    private EventHandler<ValidationStateChangedEventArgs> _stateChangedHandler
        => (sender, args) => StateHasChanged();
    [CascadingParameter] private EditContext EditContext { get; set; }
    [Parameter] public Expression<Func<TValue>> For { get; set; }
    [Parameter] public string Class { get; set; } = "input-error";
    protected IEnumerable<string> ValidationMessages 
        => EditContext.GetValidationMessages(_fieldIdentifier);

    private ValidationMessageStore _messageStore;

    protected override void OnInitialized()
    {
        _fieldIdentifier = FieldIdentifier.Create(For);
        EditContext.OnValidationStateChanged += _stateChangedHandler;
    }

    public void Dispose()
    {
        EditContext.OnValidationStateChanged -= _stateChangedHandler;
    }
}
