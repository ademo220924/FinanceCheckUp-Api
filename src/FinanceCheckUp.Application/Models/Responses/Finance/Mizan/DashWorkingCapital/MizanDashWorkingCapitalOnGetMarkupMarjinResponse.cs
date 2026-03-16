using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashWorkingCapital
{
    public class MizanDashWorkingCapitalOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashWorkingCapitalRequestInitialModel InitialModel { get; set; }
    }
}
