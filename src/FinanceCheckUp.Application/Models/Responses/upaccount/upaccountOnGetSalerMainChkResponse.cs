using FinanceCheckUp.Application.Models.Requests.upaccount;
using DevExtreme.AspNet.Data.ResponseModel;


namespace FinanceCheckUp.Application.Models.Responses.upaccount;
public class upaccountOnGetSalerMainChkResponse
{
    public LoadResult Result { get; set; }
    public upaccountRequest InitialModel { get; set; }
}