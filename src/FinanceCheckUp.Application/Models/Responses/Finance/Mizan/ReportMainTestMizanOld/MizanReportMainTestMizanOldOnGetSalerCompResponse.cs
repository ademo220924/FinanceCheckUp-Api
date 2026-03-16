using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizanOld;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld
{
    public class MizanReportMainTestMizanOldOnGetSalerCompResponse
    {
        public JsonResult Response { get; set; }
        public MizanReportMainTestMizanOldRequestInitialModel InitialModel { get; set; }
    }
}
