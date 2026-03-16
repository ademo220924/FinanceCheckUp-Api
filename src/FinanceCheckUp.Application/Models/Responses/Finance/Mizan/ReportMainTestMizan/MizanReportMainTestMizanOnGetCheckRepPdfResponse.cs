using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizan;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan
{
    public class MizanReportMainTestMizanOnGetCheckRepPdfResponse
    {
        public JsonResult Response { get; set; }
        public MizanReportMainTestMizanRequestInitialModel InitialModel { get; set; }
    }
}
