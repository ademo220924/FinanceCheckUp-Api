using FinanceCheckUp.Application.Models.Requests.upbalance;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upbalance;
public class upbalanceOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upbalanceRequest InitialModel { get; internal set; }
}