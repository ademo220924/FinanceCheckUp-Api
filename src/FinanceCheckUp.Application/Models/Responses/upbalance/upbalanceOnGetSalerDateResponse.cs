using FinanceCheckUp.Application.Models.Requests.upbalance;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upbalance;
public class upbalanceOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upbalanceRequest InitialModel { get; internal set; }
}