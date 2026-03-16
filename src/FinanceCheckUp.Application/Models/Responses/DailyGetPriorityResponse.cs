using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses;

public class DailyGetPriorityResponse
{
    //public IEnumerable<PriorityResource> PriorityResources { get; set; }
    public LoadResult LoadResult { get; set; }
}