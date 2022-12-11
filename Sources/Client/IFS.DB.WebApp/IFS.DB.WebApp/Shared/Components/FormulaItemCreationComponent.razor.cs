using IFS.DB.WebApp.Features.Admin.Pages;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Helpers.FieldCssClassProviders;
using IFS.DB.WebApp.Models.Mandates;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Shared.Components;

public partial class FormulaItemCreationComponent
{
    [CascadingParameter] public MandatesItemComponent Owner { get; set; } = default!;
    [Parameter] public FormulaItemModel FormulaItem { get; set; }

    private List<EditContext> _formulaValuesCtxs = new List<EditContext>();
    private List<FormulaValuesCreationComponent> _formulaValuesCreationComponents = new List<FormulaValuesCreationComponent>();

    private EditContext _formulaItemAmountCxt;
    private ValidationMessageStore _validationMessageStore;

    private int _FormulaValuesIndex = 1;
    private FormulaItemModel _formulaItem;

    internal async Task AddFormulaValuesContext(EditContext editContext)
    {
        _formulaValuesCtxs.Add(editContext);
        await Owner.AddEditContextAsync(editContext);
    }

    internal async Task AddFormulaValuesComponent(FormulaValuesCreationComponent formulaValueComponent)
    {
        _formulaValuesCreationComponents.Add(formulaValueComponent);
    }

    internal async Task SetUpdatedFormulaValuesData(FormulaValuesModel updatedFormulaValues)
    {
        _formulaItem.FormulaValues.ForEach(x =>
        {
            if(x.ValueId == updatedFormulaValues.ValueId)
            {
                x.PairOfValues = updatedFormulaValues.PairOfValues;
            }
        });
        await Owner.SetUpdatedFormulaData(_formulaItem with { });
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);
        await base.SetParametersAsync(parameters);
    }

    protected override async Task OnInitializedAsync()
    {
        _formulaItem = FormulaItem with { };

        if (_formulaItem.FormulaValues == null)
        {
            _formulaItem.FormulaValues = new List<FormulaValuesModel>()
            {
                new FormulaValuesModel()
                {
                    ValueId = _FormulaValuesIndex,
                    PairOfValues = new List<PairValueOfFormula>()
                    {
                        new PairValueOfFormula()
                        {
                            LevelOfUser = LevelOfUserEnum.A
                        }
                    }
                }
            };
        }
        else
        {
            if (_formulaItem.FormulaValues.Count() > 0)
            {
                _FormulaValuesIndex = _formulaItem.FormulaValues.Count();
            }
            else
            {
                _formulaItem.FormulaValues.Add(new FormulaValuesModel()
                {
                    ValueId = _FormulaValuesIndex,
                    PairOfValues = new List<PairValueOfFormula>()
                        {
                            new PairValueOfFormula()
                        }
                });
            }
        }

        await Owner.SetUpdatedFormulaData(_formulaItem with { });
        _formulaItemAmountCxt = new EditContext(_formulaItem);
        _formulaItemAmountCxt.SetFieldCssClassProvider(new CustomFieldClassProvider());
        _validationMessageStore = new ValidationMessageStore(_formulaItemAmountCxt);
        _formulaItemAmountCxt.OnFieldChanged += EditContext_OnFieldChanged;

        await Owner.AddEditContextAsync(_formulaItemAmountCxt);
        await Owner.AddFormulaItemComponentAsync(this);
    }

    private async void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        await Owner.SetUpdatedFormulaData(_formulaItem with { });
        await Owner.ForceStateHasChanged();
    }

    private async Task AddNewFormulaValueItemAsync()
    {
        _FormulaValuesIndex = _formulaItem.FormulaValues.Count();
        _formulaItem.FormulaValues.Add(new FormulaValuesModel()
        {
            ValueId = ++_FormulaValuesIndex,
            PairOfValues = new List<PairValueOfFormula>()
                        {
                            new PairValueOfFormula()
                            {
                                LevelOfUser = LevelOfUserEnum.A
                            }
                        }
        });

        await Owner.SetUpdatedFormulaData(_formulaItem with { });
    }

    private async Task DeleteFormulaValuesAsync((FormulaValuesCreationComponent formulaValuesComp, List<EditContext> ctxs, FormulaValuesModel formulaValues) args)
    {
        _formulaValuesCreationComponents.Remove(args.formulaValuesComp);
        args.ctxs.ForEach(x =>
        {
            if(_formulaValuesCtxs.Contains(x))
            {
                _formulaValuesCtxs.Remove(x);
                Owner.RemoveEditContextAsync(x);
            }
        });
        _formulaItem.FormulaValues.Remove(args.formulaValues);
    }
}
