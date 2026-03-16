using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.ReportMain
{
    public class FinanceReportMainOnGetWorkingCapitalResponse
    {
        public JsonResult Response { get; set; }
        public FinanceReportMainRequestInitialModel InitialModel { get; set; }
    }
}
