using FinanceCheckUp.Application.Models.Requests.Finance.Aktarma.DashRevenue;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue
{
    public class AktarmaDashRevenueOnGetMarkupMarjinResponse
    {
        public AktarmaDashRevenueInitialModel InitialModel { get; set; }
        public JsonResult Response { get; set; }
    }
}
