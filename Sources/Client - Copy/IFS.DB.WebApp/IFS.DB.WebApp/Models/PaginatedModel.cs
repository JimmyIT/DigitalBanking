namespace IFS.DB.WebApp.Models;

public class PaginatedModel<T> where T : class
{
    public List<T> Items { get; set; } = new List<T>();
    public int TotalRecord { get; set; }
}