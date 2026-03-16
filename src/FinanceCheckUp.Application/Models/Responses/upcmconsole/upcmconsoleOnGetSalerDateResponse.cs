using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upcmconsole;
public class upcmconsoleOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upcmconsoleRequest InitialModel { get; internal set; }
}