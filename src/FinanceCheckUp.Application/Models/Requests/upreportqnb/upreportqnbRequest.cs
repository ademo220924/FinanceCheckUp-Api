using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.upreportqnb;
public class upreportqnbRequest
{


    public IOrderedEnumerable<CompanyQnbReport> reportList;

    public IEnumerable<YearResult> myearResult;
    public long UserID; public int YearCurrent;
    public long CompID;
    public int CompCount;
    public string CompName;
    public string NewRepName;
    public int YearCount;
    public long curcomID;
    public int curcomCount;
    public HhvnUsers CurrentUser;

    public IEnumerable<Nacecode> cNaceCodeUpload;

    public IEnumerable<Company> mreqListCompany;
    public Company curCompany;


    public string currentcompname { get; set; }
}