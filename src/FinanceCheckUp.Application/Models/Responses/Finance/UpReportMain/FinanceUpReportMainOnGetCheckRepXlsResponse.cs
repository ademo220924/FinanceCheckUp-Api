using FinanceCheckUp.Application.Models.Requests.Finance.UpReportMain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.UpReportMain
{
    public class FinanceUpReportMainOnGetCheckRepXlsResponse
    {
        public JsonResult Response { get; set; }
        public FinanceUpReportMainRequestInitialModel InitialModel { get; set; }
    }
}
