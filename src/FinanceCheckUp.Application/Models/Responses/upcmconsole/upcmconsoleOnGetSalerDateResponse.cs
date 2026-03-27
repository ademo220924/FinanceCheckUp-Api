using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upcmconsole;
public class upcmconsoleOnGetSalerDateResponse
{
    public LoadResult Result { get; set; }
    public upcmconsoleRequest InitialModel { get; internal set; }
}