using FinanceCheckUp.Application.Models.Requests.upaccounty;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upaccounty;
public class upaccountyOnGetSalerMainZetaResponse
{
    public JsonResult Result { get; set; }
    public upaccountyRequest InitialModel { get; set; }
}