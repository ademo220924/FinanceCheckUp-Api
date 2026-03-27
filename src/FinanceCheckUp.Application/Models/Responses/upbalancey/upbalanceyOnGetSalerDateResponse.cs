using FinanceCheckUp.Application.Models.Requests.upbalancey;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upbalancey;
public class upbalanceyOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upbalanceyRequest InitialModel { get; internal set; }
}