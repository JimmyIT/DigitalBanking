namespace IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;

public class ColumnDefinition
{
    public ColumnDefinition()
    {
        this.DataType = DataType.NotSet;
        this.HeaderAlignment = Alignment.NotSet;
        this.BodyAlignment = Alignment.NotSet;
        this.SortDirection = SortDirection.NotSet;
    }

    public string DataField { get; set; }
    public string Caption { get; set; }
    public DataType DataType { get; set; }
    public Alignment HeaderAlignment { get; set; }
    public Alignment BodyAlignment { get; set; }
    public SortDirection SortDirection { get; set; }
    public string Format { get; set; }
    public string CssClass { get; set; }
}
