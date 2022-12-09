namespace IFS.DB.WebApp.Helpers.CompnentConfiguration.DataGrid;

public class PagingConfig
{
    /// <summary>
    /// to enable pagination config
    /// </summary>
    public bool Enabled { get; set; }
    /// <summary>
    /// to allow developer sets their own pagination list of page size
    /// </summary>
    public bool CustomPageSize { get; set; }
    /// <summary>
    /// to allow developer can design their own search box
    /// </summary>
    public bool CustomConfigSearch { get; set; }
    /// <summary>
    /// to allow developer can design their own pagination
    /// </summary>
    public bool CustomPager { get; set; }
    /// <summary>
    /// page size
    /// </summary>
    public int PageSize { get; set; }
    /// <summary>
    /// total of records
    /// </summary>
    public int TotalOfRecords { get; set; }

    public int NumberOfItemToSkip(int pageNumber)
    {
        if (Enabled)
        {
            return (pageNumber - 1) * PageSize;
        }
        return 0;
    }

    /// <summary>
    /// return the total of records depend on page size or all of item if enable = false
    /// </summary>
    /// <param name="totalItemsCount"></param>
    /// <returns></returns>
    public int NumberOfItemToTake(int totalItemsCount)
    {
        if (Enabled)
        {
            return PageSize;
        }
        return totalItemsCount;
    }

    /// <summary>
    /// return current page index
    /// </summary>
    /// <param name="currentPageNumber"></param>
    /// <returns></returns>
    public int PrevPageNumber(int currentPageNumber)
    {
        if (currentPageNumber > 1)
        {
            return currentPageNumber - 1;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// return the next page index 
    /// </summary>
    /// <param name="currentPageNumber"></param>
    /// <param name="totalItemsCount"></param>
    /// <returns></returns>
    public int NextPageNumber(int currentPageNumber, int totalItemsCount)
    {
        if (currentPageNumber < MaxPageNumber(totalItemsCount))
        {
            return currentPageNumber + 1;
        }
        else
        {
            return currentPageNumber;
        }
    }

    /// <summary>
    /// return the total of pages base on total of records
    /// </summary>
    /// <param name="totalItemsCount"></param>
    /// <returns></returns>
    public int MaxPageNumber(int totalItemsCount)
    {
        int maxPageNumber;
        double numberOfPages = (double)totalItemsCount / (double)PageSize;
        if (numberOfPages == Math.Floor(numberOfPages))
        {
            maxPageNumber = (int)numberOfPages;
        }
        else
        {
            maxPageNumber = (int)numberOfPages + 1;
        }
        return maxPageNumber;
    }
}
