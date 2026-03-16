using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.upreportmainy;
public class upreportmainyRequest
{

    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public string CompName;
    public int YearCount;
    public long curcomID;
    public int curcomCount;
    public HhvnUsers CurrentUser;



    public IEnumerable<Company> mreqListCompany;
    public Company curCompany;


    public string currentcompname { get; set; }
}