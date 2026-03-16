using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetail;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetail
{
    public class FinanceDashCrmDetailOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashCrmDetailRequestInitialModel Request { get; set; }
    }
}
