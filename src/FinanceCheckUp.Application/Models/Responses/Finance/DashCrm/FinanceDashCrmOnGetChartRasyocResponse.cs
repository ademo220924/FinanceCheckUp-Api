using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashCrm
{
    public class FinanceDashCrmOnGetChartRasyocResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashCrmRequestInitialModel InitialModel { get; set; }
    }
}
