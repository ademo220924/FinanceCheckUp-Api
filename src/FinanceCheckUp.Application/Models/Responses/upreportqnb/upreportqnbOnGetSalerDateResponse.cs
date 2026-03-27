using FinanceCheckUp.Application.Models.Requests.upreportqnb;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upreportqnb;
public class upreportqnbOnGetSalerDateResponse
{
    public upreportqnbRequest InitialModel { get; set; }
    public LoadResult Result { get; internal set; }
}