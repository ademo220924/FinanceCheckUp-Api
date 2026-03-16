using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.CashFlow
{
    public class FinanceCashFlowRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public string CompName { get; set; }
        public long CompID;
        public int CompCount;
        public int YearCount;
        public HhvnUsers CurrentUser;
        public DashYearlyBilancoChart ncart;
        public List<DashBilancoView> nRequestList;
        public IEnumerable<Company> mreqListCompany;
        public string NetIsletme { get; set; }
        public string CariOran { get; set; }
        public decimal CariOranT { get; set; }
        public string NakitOran { get; set; }
        public long val1 { get; set; }
        public long val3 { get; set; }
    }
}
