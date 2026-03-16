using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailc
{
    public class FinanceDashCrmDetailcRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public int UserID;
        public long CompID;
        public int CompCount;
        public int YearCount;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public List<DashYearlyResultCRMMain> RasyoAnalizCRM;
        public DashYearlyResultChartCRM RasyoAnalizViewCrm;
        public string CompName;
        public string NetIsletme { get; set; }
        public string CariOran { get; set; }
        public decimal CariOranT { get; set; }
        public string NakitOran { get; set; }
        public long val1 { get; set; }
        public long val3 { get; set; }
    }
}
