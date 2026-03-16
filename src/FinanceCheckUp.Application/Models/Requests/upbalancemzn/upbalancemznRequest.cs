using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Domain.Entities;



namespace FinanceCheckUp.Application.Models.Requests.upbalancemzn;
public class upbalancemznRequest
{
    public long UserID;
    public long CompID;
    public string header;
    public Company CCompany;
    public HhvnUsers CurrentUser;
    public IEnumerable<Company> mreqListCompany;
    public List<ReportSet> ncheck;
}