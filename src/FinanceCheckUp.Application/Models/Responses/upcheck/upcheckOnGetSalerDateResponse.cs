using FinanceCheckUp.Application.Models.Requests.upcheck;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upcheck;
public class upcheckOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upcheckRequest InitialModel { get; internal set; }
}