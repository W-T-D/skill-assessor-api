namespace SkillAssessor.Common.Models.Pagination;

public class PagedResult<T>
{
    public int PageSize { get; set; }

    public int CurrentPage { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

    public bool HasPrevious => CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;

    public IReadOnlyCollection<T> Items { get; set; }


    public PagedResult(IReadOnlyCollection<T> items,int pageSize, int currentPage, int totalItems)
    {
        PageSize = pageSize;
        CurrentPage = currentPage;
        Items = items;
        TotalItems = totalItems;
    }
}