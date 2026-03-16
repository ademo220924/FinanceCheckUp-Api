using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoRevenueMlt;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueMlt
{
    public class MizanDashBilancoRevenueMltOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashBilancoRevenueMltRequestInitialModel InitialModel { get; set; }
    }
}
