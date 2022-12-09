using IFS.DB.WebApp.Helpers.Enums;
using IFS.DB.WebApp.Models.Mandates;

namespace IFS.DB.WebApp.Models;

public partial class FakeData
{
    public static MandatesMaintenanceModel MandatesMaintenance = new MandatesMaintenanceModel()
    {
        //MaximumAmount = 0,
        //MandatesItems = new List<MandatesItemModel>()
        //{
        //    new MandatesItemModel()
        //    {
        //        MandatesItemId = 1,
        //        ItemType = MandatesItemTypeEnum.Simple,
        //        SimpleValueItem = new SimpleValueItemModel()
        //        {
        //            CurrencyCode = "USD",
        //            Amount = 100000,
        //            NumberOfSignatures = 20
        //        }
        //    },
        //    new MandatesItemModel()
        //    {
        //        MandatesItemId = 2,
        //        ItemType = MandatesItemTypeEnum.Formula,
        //        Formula = new FormulaItemsModel(){
        //            Items = new List<FormulaItemModel>()
        //            {
        //                new FormulaItemModel()
        //                {
        //                    CurrencyCode = "USD",
        //                    Amount = 50000000,
        //                    FormulaValues = new List<FormulaValuesModel>()
        //                    {
        //                        new FormulaValuesModel()
        //                        {
        //                            ValueId = 1,
        //                            PairOfValues = new List<PairValueOfFormula>()
        //                            {
        //                                new PairValueOfFormula()
        //                                {
        //                                    LevelOfUser = LevelOfUserEnum.A,
        //                                    NumberSignatures = 20
        //                                },
        //                                new PairValueOfFormula()
        //                                {
        //                                    LevelOfUser = LevelOfUserEnum.B,
        //                                    NumberSignatures = 2
        //                                }
        //                            }
        //                        },
        //                        new FormulaValuesModel()
        //                        {
        //                            ValueId = 2,
        //                            PairOfValues = new List<PairValueOfFormula>()
        //                            {
        //                                new PairValueOfFormula()
        //                                {
        //                                    LevelOfUser = LevelOfUserEnum.C,
        //                                    NumberSignatures = 3
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    },
        //    new MandatesItemModel()
        //    {
        //        MandatesItemId = 3,
        //        ItemType = MandatesItemTypeEnum.Simple,
        //        SimpleValueItem = new SimpleValueItemModel()
        //        {
        //            CurrencyCode = "USD",
        //            Amount = 25000,
        //            NumberOfSignatures = 5
        //        }
        //    },
        //}
    };
}
