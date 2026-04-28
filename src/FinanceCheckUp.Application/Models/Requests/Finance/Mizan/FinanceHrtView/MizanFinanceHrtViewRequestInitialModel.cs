using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtView
{
    public class MizanFinanceHrtViewRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount { get; set; }
        public string CompName;
        public HhvnUsers CurrentUser;
        public YearlyErrorResultView mrequestEntryView;
        public IEnumerable<Company> mreqListCompany;
        public IEnumerable<YearlyReportDash> dashEbitMarjin;
        public IEnumerable<YearlyReportDash> dashGrossProfit;
        public IEnumerable<YearlyReportDash> dashFinancialDebit;
        public IEnumerable<YearlyReportDash> dashFinancialDebitMulti;
        public IEnumerable<YearlyReportDash> ResultWorkingCapital;
        public IEnumerable<DashBilancoViewMarj> dashFinancialOzkaynakAktif;
        public IEnumerable<YearlyReportDash> dashFinancialCariOran;
        public IEnumerable<YearlyReportDash> dashRevenue;
        public IEnumerable<YearlyReportDash> dashNetSatisByYear;
        public IEnumerable<YearlyReportDash> dashDonemselKarzarar;
        public IEnumerable<DashYearlyResultMain> dashWorkingCapital;
        public IEnumerable<YearlyReportDashGraphic> dDashFrossViewMarjBrut;
        public IEnumerable<ReportMainItem> dDashReportMain;
        public IEnumerable<BWarn> mreqList;
        public DashRep NetEbitMarjin { get; set; }
        public List<DashDepth> NetDashDepth { get; set; }
        public DashRep NetGrossProfit { get; set; }
        public DashRep NetFinancialDebit { get; set; }
        public DashRep NetRevenue { get; set; }
        public DashRep NetDonemselKarzarar { get; set; }
        public DashRep NetWorkingCapital { get; set; }
        public DashRep NetGrossProfitGraphic { get; set; }
        public string RetValGross;
        public string RetValScore;
        //  public ReportDashViewMarkupMarjin dashMarkupMarjin;
        public DashBilancoViewMarj dDashBilancoViewMarjBrut;
        public DashBilancoViewMarj dDashBilancoViewMarjNet;
    }
}
