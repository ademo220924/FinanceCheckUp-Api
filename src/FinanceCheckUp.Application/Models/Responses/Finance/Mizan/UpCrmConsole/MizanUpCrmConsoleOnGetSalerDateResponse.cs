using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpCrmConsole;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole
{
    public class MizanUpCrmConsoleOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUpCrmConsoleRequestInitialModel InitialModel { get; set; }
    }
}
