using FinanceCheckUp.Application.Models.Requests.upreportqnbtest;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
public class upreportqnbtestOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upreportqnbtestRequest InitialModel { get; internal set; }
}