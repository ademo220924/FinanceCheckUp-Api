using FinanceCheckUp.Application.Models.Requests.Finance.UpCrmConsole;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpCrmConsole
{
    public class FinanceUpCrmConsoleOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUpCrmConsoleRequestInitialModel InitialModel { get; set; }
    }
}
