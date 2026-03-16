using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashRevenueKon;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashRevenueKon
{
    public class MizanDashRevenueKonOnGetGraphYearResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashRevenueKonRequestInitialModel InitialModel { get; set; }
    }
}
