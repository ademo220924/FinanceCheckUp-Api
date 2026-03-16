using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtFiba
{
    public class MizanFinanceHrtFibaRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public HhvnUsers CurrentUser;
        public DashYearlyBilancoChart ncart;
        public List<DashPivotView> nRequestList;
        public List<ReportSet> nRequestListReport;
        public List<DashPivotView> nRequestListChk;
        public IEnumerable<Company> mreqListCompany;
        public string NetIsletme { get; set; }
        public string CompName { get; set; }
        public string CompNameNorm { get; set; }
        public string CariOran { get; set; }
        public decimal CariOranT { get; set; }
        public string NakitOran { get; set; }
        public double val1 { get; set; }
        public double val3 { get; set; }
    }
}
