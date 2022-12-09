using IFS.DB.WebApp.Models.Mandates;
using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Shared.Components;

public partial class FormulaItemCreationComponent
{
    [Parameter] public FormulaItemModel FormulaItem { get; set; }

    private int _FormulaValuesIndex = 1;

    protected override async Task OnInitializedAsync()
    {
        if (FormulaItem.FormulaValues == null)
        {
            FormulaItem.FormulaValues = new List<FormulaValuesModel>()
            {
                new FormulaValuesModel()
                {
                    ValueId = _FormulaValuesIndex,
                    PairOfValues = new List<PairValueOfFormula>()
                    {
                        new PairValueOfFormula()
                    }
                }
            };
        }
        else
        {
            if (FormulaItem.FormulaValues.Count() > 0)
            {
                _FormulaValuesIndex = FormulaItem.FormulaValues.Count();
            }
            else
            {
                FormulaItem.FormulaValues.Add(new FormulaValuesModel()
                {
                    ValueId = _FormulaValuesIndex,
                    PairOfValues = new List<PairValueOfFormula>()
                        {
                            new PairValueOfFormula()
                        }
                });
            }
        }
    }

    private async Task AddNewPairOfFormulaValueItemAsync(FormulaValuesModel selectedFormulaValue)
    {
        FormulaItem.FormulaValues.ForEach(pairOfFormulaValue =>
        {
            if(pairOfFormulaValue.ValueId == selectedFormulaValue.ValueId)
            {
                pairOfFormulaValue.PairOfValues.Add(new PairValueOfFormula());
            }
        });
    }

    private async Task AddNewFormulaValueItemAsync()
    {
        _FormulaValuesIndex = _FormulaValuesIndex + 1;
        FormulaItem.FormulaValues.Add(new FormulaValuesModel()
        {
            ValueId = _FormulaValuesIndex,
            PairOfValues = new List<PairValueOfFormula>()
                        {
                            new PairValueOfFormula()
                        }
        });
    }

    private async Task RemoveFormulaValueItemAsync(FormulaValuesModel formulaValuesModel)
    {        
        FormulaItem.FormulaValues.Remove(formulaValuesModel);
        _FormulaValuesIndex = 1;
        // Re-calculate index
        FormulaItem.FormulaValues.ForEach(formulaValue =>
        {
            formulaValue.ValueId = _FormulaValuesIndex;
            _FormulaValuesIndex = _FormulaValuesIndex + 1;
        });
    }
}
