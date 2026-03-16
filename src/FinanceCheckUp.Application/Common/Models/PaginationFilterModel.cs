using FinanceCheckUp.Application.Common.Constants;

namespace FinanceCheckUp.Application.Common.Models;

public class PaginationFilterModel
{
    public int Skip { get; set; } = AppConst.DefaultPageSkip;
    public int Limit { get; set; } = AppConst.DefaultPageLimit;
}