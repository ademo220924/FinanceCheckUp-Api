namespace FinanceCheckUp.Application.Common;

public class PagedListResponse<T>
{
    public int TotalCount { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public List<T>? Items { get; set; }
}