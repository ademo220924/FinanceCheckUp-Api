using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance
{
    public class MizanUpBalanceOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUpBalanceRequestInitialModel InitialModel { get; set; }
    }
}
