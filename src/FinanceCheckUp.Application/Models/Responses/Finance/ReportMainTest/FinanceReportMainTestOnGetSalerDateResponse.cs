using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTest;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest
{
    public class FinanceReportMainTestOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public FinanceReportMainTestRequestInitialModel InitialModel { get; set; }
    }
}
