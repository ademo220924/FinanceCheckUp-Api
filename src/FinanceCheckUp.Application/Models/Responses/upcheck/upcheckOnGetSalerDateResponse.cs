using FinanceCheckUp.Application.Models.Requests.upcheck;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upcheck;
public class upcheckOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upcheckRequest InitialModel { get; internal set; }
}