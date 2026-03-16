using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.DashLiquidity
{
    public class FinanceDashLiquidityRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public string CompName;
        public int CompCount;
        public int YearCount;
        public List<DashBilancoView> nRequestListChk;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public List<DashBilancoView> nRequestList;
        public List<DashWCapitalShortViewChart> nRequestListViewChart;
        public string NetIsletme { get; set; }
        public decimal NetIsletmeT { get; set; }
        public string CariOran { get; set; }
        public string NakitOran { get; set; }
    }
}
