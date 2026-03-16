using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.DashBoard;
public class DashBoardRequest
{

    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public string CompName;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public HhvnUsers CurrentUser;
    public YearlyErrorResultView mrequestEntryView;
    public IEnumerable<Bulten> bultenList;
    public IEnumerable<Company> mreqListCompany;
    public DataViewerMain mrequestDataViewer;
    public TaxErrorCheck ttdashChk;
    public TaxErrorcheckTest ttdashTest;
    public TaxErrorcheckDataz ttdashDataz;
}