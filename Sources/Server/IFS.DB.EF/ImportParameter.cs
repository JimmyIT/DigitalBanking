using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class ImportParameter
    {
        public string? ImportFileFormat { get; set; }
        public string? ImportFilesLocation { get; set; }
        public string? PositionofDrcrind { get; set; }
        public string? NegativeAmountsRepresent { get; set; }
        public string? ImportFileDateFormat { get; set; }
        public string? FullImportMethod { get; set; }
        public DateTime? FullImportAt { get; set; }
        public bool? ImpliedDecimalPlaces { get; set; }
        public bool? CalculateLastStatementDate { get; set; }
        public int? LastStatementDateDaysBack { get; set; }
        public int ImportParametersId { get; set; }
        public Guid? HostId { get; set; }

        public virtual Host? Host { get; set; }
    }
}
