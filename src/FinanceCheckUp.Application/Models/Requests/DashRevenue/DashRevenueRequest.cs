
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.DashRevenue;
public class DashRevenueRequest
{
    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public HhvnUsers CurrentUser;
    public List<DashBilancoView> nRequestList;
    public string CompName;
    public IEnumerable<Company> mreqListCompany;


    public DashYearlyRevenueChart ncart;
    public IEnumerable<YearlyReportDash> dashEbitMarjin;
    public IEnumerable<YearlyReportDash> dashGrossProfit;
    public IEnumerable<YearlyReportDash> dashRevenue;
    public IEnumerable<YearlyReportDash> dashDonemselKarzarar;
    public DashRep NetEbitMarjin { get; set; }
    public DashRep NetGrossProfit { get; set; }
    public DashRep NetRevenue { get; set; }
    public DashRep NetDonemselKarzarar { get; set; }


    public string brutkarzararstr { get; set; }
    public string ebitstr { get; set; }
    public string donemkarzararstr { get; set; }
}