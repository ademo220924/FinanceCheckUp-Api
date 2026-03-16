using FinanceCheckUp.Application.Models.Requests.Finance.Konsol.DashRevenueKon;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Konsol.DashRevenueKon
{
    public class DashRevenueKonOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public DashRevenueKonInitialModel InitialModel { get; set; }

    }
}
