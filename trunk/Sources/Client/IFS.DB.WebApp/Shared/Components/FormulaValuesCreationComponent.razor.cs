using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Mandates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Z.Collections.Extensions;

namespace IFS.DB.WebApp.Shared.Components;

public partial class FormulaValuesCreationComponent
{
    [CascadingParameter] public FormulaItemCreationComponent Owner { get; set; } = default!;
    [Parameter] public FormulaValuesModel FormulaValues { get; set; }
    [Parameter] public EventCallback<(FormulaValuesCreationComponent, List<EditContext>, FormulaValuesModel)> FormulaValuesCreation_OnDelete { get; set; }

    private List<EditContext> _listPairValuesContexts = new List<EditContext>();
    private FormulaValuesModel _formulaValues;
    private int _countPairOfValues = 0;
    internal async Task AddEditContextAsyn(EditContext editContext)
    {
        _listPairValuesContexts.Add(editContext);
        await Owner.AddFormulaValuesContext(editContext);
    }
    internal async Task SetUpdatePairValueOfFormula(PairValueOfFormula updatedpairValueOfFormula)
    {
        _formulaValues.PairOfValues.ForEach(x => {
            if(x.PairValueID == updatedpairValueOfFormula.PairValueID)
            {
                x.NumberSignatures = updatedpairValueOfFormula.NumberSignatures;
                x.LevelOfUser = updatedpairValueOfFormula.LevelOfUser;
            }
        });

        await Owner.SetUpdatedFormulaValuesData(_formulaValues with { });
    }
    internal async Task ForceStateHasChanged() => StateHasChanged();

    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        _formulaValues = FormulaValues with { };

        return base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        if(_formulaValues == null)
        {
            _formulaValues = new FormulaValuesModel()
            {
                ValueId = ++_countPairOfValues,
                PairOfValues = new List<PairValueOfFormula>()
                {
                    new PairValueOfFormula()
                    {
                        PairValueID = Guid.NewGuid().ToString("N"),
                        LevelOfUser = LevelOfUserEnum.A
                    }
                }
            };
        }
        else
        {
            if(_formulaValues.PairOfValues == null)
            {
                _formulaValues.PairOfValues = new List<PairValueOfFormula>()
                {
                    new PairValueOfFormula()
                    {
                        PairValueID = Guid.NewGuid().ToString("N"),
                        LevelOfUser = LevelOfUserEnum.A
                    }
                };
            }
        }

        await base.OnInitializedAsync();
    }

    private async Task AddNewPairOfFormulaValueItemAsync()
    {
        _formulaValues.PairOfValues.Add(new PairValueOfFormula()
        {
            PairValueID = Guid.NewGuid().ToString("N"),
            LevelOfUser = LevelOfUserEnum.A,
        });
    }
    
    private async Task DeleteFormulaValueItemAsync()
    {
        await FormulaValuesCreation_OnDelete.InvokeAsync((this, _listPairValuesContexts, FormulaValues));
    }
}
