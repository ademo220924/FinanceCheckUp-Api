using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtHor;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor
{
    public class FinanceFinanceHrtHorOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceFinanceHrtHorRequestInitialModel InitialModel { get; set; }
    }
}
