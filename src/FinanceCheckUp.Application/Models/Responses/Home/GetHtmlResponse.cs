using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Home
{
    public class GetHtmlResponse
    {
        public JsonResult ResultText { get; set; }
    }
}