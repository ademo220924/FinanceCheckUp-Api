using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpReportMain;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpReportMain
{
    public class MizanUpReportMainOnGetSalerDateResponse
    {
        public JsonResult Response { get; set; }
        public MizanUpReportMainRequestInitialModel InitialModel { get; set; }
    }
}
