using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.upaccount;
public class upaccountRequest
{

    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public string TotalRowCount;
    public string TotalErrorCount;
    public long curcomID;
    public int curcomCount;
    public int YearCurrent;
    public HhvnUsers CurrentUser;

    public IEnumerable<YearlyErrorResult> currentUploadError;

    public Company slctompany;
    public IEnumerable<Company> mreqListCompany;
    public DataViewerMain mrequestDataViewer;

    public string CompName;
    public string currentcompname { get; set; }
}