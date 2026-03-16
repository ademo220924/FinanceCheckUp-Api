using FinanceCheckUp.Application.Models.Requests.upreportqnb;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upreportqnb;
public class upreportqnbOnGetSalerDateResponse
{
    public upreportqnbRequest InitialModel { get; set; }
    public JsonResult Result { get; internal set; }
}