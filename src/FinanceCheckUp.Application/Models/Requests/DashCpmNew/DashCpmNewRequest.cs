
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.DashCpmNew;
public class DashCpmNewRequest
{
    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public string CompName;
    public List<DashYearlyResultCRMMain> RasyoAnalizCRM;
    public DashYearlyResultChartCRM RasyoAnalizViewCrm102;
    public List<DashYearlyResultCRMMain> RasyoAnalizCRM102;
    public List<DashYearlyResultCRM> RasyoAnalizCRM102t;
    public DashYearlyResultChartCRM RasyoAnalizViewCRM120;
    public List<DashYearlyResultCRMMain> RasyoAnalizCRM120;
    public List<DashYearlyResultCRM> RasyoAnalizCRM120t;
    public DashYearlyResultChartCRM RasyoAnalizViewCRM103;
    public List<DashYearlyResultCRMMain> RasyoAnalizCRM103;
    public List<DashYearlyResultCRM> RasyoAnalizCRM103t;
    public DashYearlyResultChartCRM RasyoAnalizViewCRM101;
    public List<DashYearlyResultCRMMain> RasyoAnalizCRM101;
    public List<DashYearlyResultCRM> RasyoAnalizCRM101t;
    public DashYearlyResultChartCRM RasyoAnalizViewCRM320;
    public List<DashYearlyResultCRMMain> RasyoAnalizCRM320;
    public List<DashYearlyResultCRM> RasyoAnalizCRM320t;
    public List<DashYearlyResult> OzetMali;
    public List<DashYearlyResult> LikiditeRiskTrend;
    public HhvnUsers CurrentUser;
    public IEnumerable<Models.DashBoard> dash;
    public IEnumerable<DashBoardRasyo> dashrasyo;
    public DashYearlyResultChart RasyoAnalizView;
    public DashYearlyResultChartCRM RasyoAnalizViewCrm;
    public IEnumerable<BWarn> mreqList;
    public DashYearlyResultChart OzetMaliView;
    public DashYearlyResultChart LikiditeRiskTrendView;
    public IEnumerable<Company> mreqListCompany;
    public int StartQuestions { get; set; }
    public int AQuestions { get; set; }
    public int BQuestions { get; set; }
    public int CQuestions { get; set; }
}