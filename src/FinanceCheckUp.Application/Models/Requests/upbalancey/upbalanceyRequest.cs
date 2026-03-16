using FinanceCheckUp.Domain.Entities;


namespace FinanceCheckUp.Application.Models.Requests.upbalancey;
public class upbalanceyRequest
{

    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public long curcomID;
    public int curcomCount;

    public HhvnUsers CurrentUser;



    public IEnumerable<Company> mreqListCompany;
    public Company curCompany;

    public string CompName;

    public string currentcompname { get; set; }
}