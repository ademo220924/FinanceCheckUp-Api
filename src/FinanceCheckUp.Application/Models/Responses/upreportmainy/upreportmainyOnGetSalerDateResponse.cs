using FinanceCheckUp.Application.Models.Requests.upreportmainy;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upreportmainy;
public class upreportmainyOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upreportmainyRequest InitialModel { get; set; }
}