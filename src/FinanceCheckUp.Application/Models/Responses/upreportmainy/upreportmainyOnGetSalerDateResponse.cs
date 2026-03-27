using FinanceCheckUp.Application.Models.Requests.upreportmainy;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upreportmainy;
public class upreportmainyOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upreportmainyRequest InitialModel { get; set; }
}