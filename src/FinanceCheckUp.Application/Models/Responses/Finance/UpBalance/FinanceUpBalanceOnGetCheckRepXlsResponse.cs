using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpBalance
{
    public class FinanceUpBalanceOnGetCheckRepXlsResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUpBalanceRequestInitialModel InitialModel { get; set; }
    }
}
