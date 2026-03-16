using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizan;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan
{
    public class MizanReportMainTestMizanOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanReportMainTestMizanRequestInitialModel InitialModel { get; set; }
    }
}
