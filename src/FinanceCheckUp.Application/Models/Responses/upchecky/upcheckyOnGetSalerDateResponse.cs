using FinanceCheckUp.Application.Models.Requests.upchecky;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upchecky;
public class upcheckyOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upcheckyRequest InitialModel { get; internal set; }
}