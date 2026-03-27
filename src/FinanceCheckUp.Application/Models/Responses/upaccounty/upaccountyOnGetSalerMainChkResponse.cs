using FinanceCheckUp.Application.Models.Requests.upaccounty;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upaccounty;
public class upaccountyOnGetSalerMainChkResponse
{
    public LoadResult Result { get; set; }
    public upaccountyRequest InitialModel { get; internal set; }
}