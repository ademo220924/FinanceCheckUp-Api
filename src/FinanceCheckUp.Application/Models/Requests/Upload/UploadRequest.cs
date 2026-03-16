using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.Upload;
public class UploadRequest
{

    public IEnumerable<YearResult> myearResult;
    public IEnumerable<YearResult> mmonthResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public long curcomID;
    public int curcomCount;
    public HhvnUsers CurrentUser;
    public IEnumerable<SourceResult> mSourceResult;
    public YearlyUploadResult currentMonth;

    public IEnumerable<YearlyUploadResult> currentUploadM;
    public IEnumerable<YearlyUploadResult> currentUploadMOK;
    public IEnumerable<YearlyUploadResult> currentUploadMNoOK;
    public List<YearlyUploadResult> currentUploadMMonth;


    public IEnumerable<Company> mreqListCompany;
    public Company currenCompanie;
    public string CompName;
    public DataViewerMain mrequestDataViewer;

    public string currentcompname { get; set; }
}