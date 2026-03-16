using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.upaccounty;
public class upaccountyOnGetSalerMainChkRequest
{
    public DataSourceLoadOptions Options { get; set; }
    public int monthid { get; set; }
}