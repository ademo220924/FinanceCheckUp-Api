using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrt;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrt
{
    public class MizanFinanceHrtOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanFinanceHrtRequestInitialModel InitialModel { get; set; }
    }
}
