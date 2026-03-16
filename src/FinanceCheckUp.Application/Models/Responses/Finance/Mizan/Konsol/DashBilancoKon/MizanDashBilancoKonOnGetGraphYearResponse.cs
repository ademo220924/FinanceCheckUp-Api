using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Konsol.DashBilancoKon;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Konsol.DashBilancoKon
{
    public class MizanDashBilancoKonOnGetGraphYearResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashBilancoKonRequestInitialModel InitialModel { get; set; }
    }
}

