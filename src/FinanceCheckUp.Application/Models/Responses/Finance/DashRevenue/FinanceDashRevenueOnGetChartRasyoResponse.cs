using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenue;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashRevenue
{
    public class FinanceDashRevenueOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashRevenueRequestInitialModel InitialModel { get; set; }
    }
}
