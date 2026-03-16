using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashBilancoMlt;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoMlt
{
    public class MizanDashBilancoMltOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashBilancoMltRequestInitialModel InitialModel { get; set; }
    }
}
