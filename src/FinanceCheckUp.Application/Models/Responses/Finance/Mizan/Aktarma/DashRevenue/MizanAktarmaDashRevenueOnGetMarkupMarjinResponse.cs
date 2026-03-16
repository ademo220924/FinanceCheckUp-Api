using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashRevenue;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Aktarma.DashRevenue
{
    public class MizanAktarmaDashRevenueOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanAktarmaDashRevenueRequestInitialModel InitialModel { get; set; }
    }
}
