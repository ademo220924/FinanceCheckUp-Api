using FinanceCheckUp.Application.Models.Requests.upchecky;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upchecky;
public class upcheckyOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upcheckyRequest InitialModel { get; internal set; }
}