using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.upaccount;
public class upaccountOnGetSalerMainZetaRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public int monthid { get; set; }
}