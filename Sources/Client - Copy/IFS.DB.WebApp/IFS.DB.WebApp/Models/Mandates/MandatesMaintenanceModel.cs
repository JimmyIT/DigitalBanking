using IFS.DB.WebApp.Helpers.CustomAnnotationAttributes;
using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Resources;
using System.ComponentModel.DataAnnotations;

namespace IFS.DB.WebApp.Models.Mandates;

public record MandatesMaintenanceModel
{
    public decimal? MaximumAmount { get; set; }
    public List<MandatesItemModel>? MandatesItems { get; set; }
}

public record MandatesItemModel
{
    public MandatesItemModel()
    { }

    public MandatesItemModel(int mandatesId)
    {
        MandatesItemId = mandatesId;
    }

    public int? MandatesItemId { get; set; }
    public MandatesItemTypeEnum ItemType { get; set; }
    public SimpleValueItemModel? SimpleValueItem { get; set; }
    public FormulaItemsModel? Formula { get; set; }
}

public record SimpleValueItemModel
{
    public string CurrencyCode { get; set; } = "USD";

    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    [GreaterThanZero(ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }
    [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "required")]
    public int NumberOfSignatures { get; set; }
}

public record FormulaItemsModel()
{
    public List<FormulaItemModel> Items { get; set; }
}

public record FormulaItemModel
{
    public string CurrencyCode { get; set; } = "USD";
    public decimal Amount { get; set; }
    public List<FormulaValuesModel> FormulaValues { get; set; }
}

public record FormulaValuesModel
{
    public int ValueId { get; set; }
    public List<PairValueOfFormula> PairOfValues { get; set; }
}

public record PairValueOfFormula()
{
    public int NumberSignatures { get; set; }
    public LevelOfUserEnum? LevelOfUser { get; set; }
}