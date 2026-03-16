using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailc;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailc
{
    public class FinanceDashCrmDetailcOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashCrmDetailcRequestInitialModel InitialModel { get; set; }
    }
}
