using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.dashbilancojrnl;
public class dashbilancojrnlRequest
{

    public IEnumerable<YearResult> myearResult;
    public long UserID;
    public long CompID;
    public int CompCount;
    public int YearCount;
    public HhvnUsers CurrentUser;
    public IEnumerable<DashBilancoViewMznShort> nRequestList;
    public string CompName;

    public IEnumerable<DashBilancoViewMznShort> nRequestListChk;
    public IEnumerable<Company> mreqListCompany;
    public string NetIsletme { get; set; }
    public string CariOran { get; set; }
    public decimal CariOranT { get; set; }
    public string NakitOran { get; set; }
    public Int64 val1 { get; set; }
    public Int64 val3 { get; set; }
}