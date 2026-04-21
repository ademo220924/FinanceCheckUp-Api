using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue
{
    public class MizanDashRevenueRequestInitialMopdel
    {
        public IEnumerable<YearResult> myearResult{ get; set; }
        public long UserID{ get; set; }
        public long CompID{ get; set; }
        public int CompCount{ get; set; }
        public int YearCount{ get; set; }
        public HhvnUsers CurrentUser{ get; set; }
        public DashYearlyBilancoChart ncart{ get; set; }
        public string CompNameNorm { get; set; }
        public List<DashBilancoViewMulti> nRequestList;

        public List<DashBilancoViewMulti> nRequestListChk;
        public IEnumerable<Company> mreqListCompany;
        public string NetIsletme { get; set; }
        public string CompName { get; set; }
        public string CariOran { get; set; }
        public decimal CariOranT { get; set; }
        public string NakitOran { get; set; }
        public double val1 { get; set; }
        public double val3 { get; set; }
    }
}
