using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTestOld;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld
{
    public class FinanceReportMainTestOldOnGetCheckRepPdfResponse
    {
        public JsonResult Response { get; set; }
        public FinanceReportMainTestOldRequestInitialModel InitialModel { get; set; }
    }
}
