using FinanceCheckUp.Application.Models.Requests.upaccount;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upaccount;
public class upaccountOnGetSalerMainChkResponse
{
    public JsonResult Result { get; set; }
    public upaccountRequest InitialModel { get; set; }
}