using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizanOld
{
    public class MizanReportMainTestMizanOldOnGetCheckRepPdfResponse
    {
        public JsonResult Response { get; set; }
        public List<int> CurCompanyYearList { get; set; }
        public string? FilePath { get; set; }
        public long CompanyId { get; set; }
        public string Nacceco { get; set; }
        public long UserId { get; set; }
        public string Ncccode  { get; set; }
    }
}
