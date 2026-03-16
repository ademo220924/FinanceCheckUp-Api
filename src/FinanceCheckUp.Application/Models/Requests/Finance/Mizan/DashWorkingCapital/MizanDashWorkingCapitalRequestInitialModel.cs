using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital
{
    public class MizanDashWorkingCapitalRequestInitialModel
    {
        public long UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public HhvnUsers CurrentUser;
        public List<DashBilancoViewMizan> nRequestList;
        public IEnumerable<Company> mreqListCompany;
        public IEnumerable<YearlyReportDashMizan> nRequestListViewChart;




        //public List<DashWCapitalShortViewChart> nRequestListViewChart;

        public string NetIsletme { get; set; }
        public string CariOran { get; set; }
        public string NakitOran { get; set; }
        public long val1 { get; set; }
        public string CompName;
        public long val3 { get; set; }
    }
}
