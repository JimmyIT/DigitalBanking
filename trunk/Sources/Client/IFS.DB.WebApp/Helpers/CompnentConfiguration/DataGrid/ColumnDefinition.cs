using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;

public class ColumnDefinition<T> where T: class
{
    public ColumnDefinition()
    {
        DataType = DataType.NotSet;
        HeaderAlignment = Alignment.NotSet;
        BodyAlignment = Alignment.NotSet;
        SortDirection = SortDirection.NotSet;
    }

    public string DataField { get; set; }
    public string Caption { get; set; }
    public DataType DataType { get; set; }
    public Alignment HeaderAlignment { get; set; }
    public Alignment BodyAlignment { get; set; }
    public SortDirection SortDirection { get; set; }
    public string Format { get; set; }
    public string CssClass { get; set; }
    public bool Sortable { get; set; } 
    
    public Func<T, string>? ShowValueFunc { get; set; }
    public Func<T, RenderFragment>? FragmentTemplateFunc { get; set; }
    
}
