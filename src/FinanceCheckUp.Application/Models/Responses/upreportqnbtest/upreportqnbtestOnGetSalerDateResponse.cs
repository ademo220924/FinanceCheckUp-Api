using FinanceCheckUp.Application.Models.Requests.upreportqnbtest;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
public class upreportqnbtestOnGetSalerDateResponse
{
    public JsonResult Result { get; set; }
    public upreportqnbtestRequest InitialModel { get; internal set; }
}