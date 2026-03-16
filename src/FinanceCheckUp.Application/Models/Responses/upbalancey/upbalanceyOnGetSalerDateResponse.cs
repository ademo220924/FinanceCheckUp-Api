using FinanceCheckUp.Application.Models.Requests.upbalancey;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upbalancey;
public class upbalanceyOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upbalanceyRequest InitialModel { get; internal set; }
}