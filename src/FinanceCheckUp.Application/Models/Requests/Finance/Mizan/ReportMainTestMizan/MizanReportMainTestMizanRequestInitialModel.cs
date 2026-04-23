using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMainTestMizan
{
    public class MizanReportMainTestMizanRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult { get; set; }
        public long UserID { get; set; }
        public long CompID { get; set; }
        public int CompCount { get; set; }
        public string CompName { get; set; }
        public int YearCount { get; set; }
        public long curcomID { get; set; }
        public int curcomCount { get; set; }
        public HhvnUsers CurrentUser { get; set; }
        public int YearCurrent { get; set; }
        public List<CompanyReport> reportList { get; set; }
        public IEnumerable<Company> mreqListCompany { get; set; }
        public Company curCompany { get; set; }
        public string currentcompname { get; set; }
    }
}
