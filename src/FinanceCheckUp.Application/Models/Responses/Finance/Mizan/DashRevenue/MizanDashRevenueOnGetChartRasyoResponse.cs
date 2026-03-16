using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue
{
    public class MizanDashRevenueOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashRevenueRequestInitialMopdel InitialModel { get; set; }
    }
}
