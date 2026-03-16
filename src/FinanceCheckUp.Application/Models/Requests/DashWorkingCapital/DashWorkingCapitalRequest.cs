
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.DashWorkingCapital;
public class DashWorkingCapitalRequest
{
    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public HhvnUsers CurrentUser;
    public List<DashBilancoView> nRequestList;
    public IEnumerable<Company> mreqListCompany;
    public IEnumerable<DashYearlyResultMain> nRequestListViewChart;
    public IEnumerable<DashYearlyResultMain> nRequestListViewMain;

    public DashRep NetWorkingCapital { get; set; }


    //public List<DashWCapitalShortViewChart> nRequestListViewChart;

    public string NetIsletme { get; set; }
    public string CariOran { get; set; }
    public string NakitOran { get; set; }
    public long val1 { get; set; }
    public string CompName;
    public long val3 { get; set; }
}