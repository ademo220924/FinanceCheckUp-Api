using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity
{
    public class MizanDashLiquidityRequestInitialModel
    {
        public long UserID { get; set; }
        public long CompID { get; set; }
        public int CompCount { get; set; }
        public int YearCount { get; set; }
        public List<DashBilancoViewMizan> nRequestListChk { get; set; }
        public List<DashYearlyResultMizan> nRequestChart { get; set; }
        public string CompName { get; set; }
        public HhvnUsers CurrentUser { get; set; }
        public IEnumerable<Company> mreqListCompany { get; set; }
        public List<DashBilancoViewMizan> nRequestList { get; set; }
        public string NetIsletme { get; set; }
        public decimal NetIsletmeT { get; set; }
        public string CariOran { get; set; }
        public string NakitOran { get; set; }
    }
}
