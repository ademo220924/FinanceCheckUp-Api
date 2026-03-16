using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetaila;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetaila
{
    public class FinanceDashCrmDetailaOnGetChartRasyoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashCrmDetailaRequestInitialModel InitialModel { get; set; }
    }
}
