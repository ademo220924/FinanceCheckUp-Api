using FinanceCheckUp.Application.Models.Requests.Finance.CashFlow;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.CashFlow
{
    public class FinanceCashFlowOnGetGraphYearResponse
    {
        public JsonResult Response { get; set; }
        public FinanceCashFlowRequestInitialModel InitialModel { get; set; }
    }
}
