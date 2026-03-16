using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Aktarma.DashCompare
{
    public class MizanAktarmaDashCompareRequestInitialModel
    {
        public IEnumerable<YearResult> myearResult;
        public long UserID;
        public long CompID;
        public int CompCount;
        public int nMonth;
        public int nnyear;
        public int YearCount;
        public HhvnUsers CurrentUser;
        public List<DashBilancoViewMznShort> nRequestList;
        public string CompName;
        public IEnumerable<Company> mreqListCompany;
        public string NetIsletme { get; set; }
        public string CariOran { get; set; }
        public decimal CariOranT { get; set; }
        public string NakitOran { get; set; }
        public long val1 { get; set; }
        public long val3 { get; set; }
    }
}
