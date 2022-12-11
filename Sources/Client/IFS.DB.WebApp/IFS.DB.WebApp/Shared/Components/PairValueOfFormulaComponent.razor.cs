using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Mandates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class PairValueOfFormulaComponent
{
    [CascadingParameter] public FormulaValuesCreationComponent Owner { get; set; } = default!;
    [Parameter] public PairValueOfFormula PairValueOfFormula { get; set; }

    private EditContext _editContext;
    private ValidationMessageStore _validationMessageStore;
    private PairValueOfFormula _pairValueOfFormula;

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);
        return base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        _pairValueOfFormula = PairValueOfFormula with { };
        if(_pairValueOfFormula == null)
        {
            _pairValueOfFormula = new PairValueOfFormula();
        }

        _editContext = new EditContext(_pairValueOfFormula);
        _editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_editContext);
        _editContext.OnFieldChanged += EditContext_OnFieldChanged;

        await Owner.AddEditContextAsyn(_editContext);
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        await Owner.SetUpdatePairValueOfFormula(_pairValueOfFormula with { });
        await Owner.ForceStateHasChanged();
    }
}
