using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTestOld
{
    public class FinanceReportMainTestOldRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public string CompName;
        public int YearCount;
        public long curcomID;
        public int curcomCount;
        public HhvnUsers CurrentUser;
        public int YearCurrent;
        public List<CompanyReport> reportList;

        public IEnumerable<Company> mreqListCompany;
        public Company curCompany;
        public Nacecode codde;
        public List<int> curCompanyYearList;
        public IEnumerable<int> curCompanyNonYearList;


        public string currentcompname { get; set; }
        public string FilePath { get; set; }
        public string FileDocz { get; set; }
    }
}
