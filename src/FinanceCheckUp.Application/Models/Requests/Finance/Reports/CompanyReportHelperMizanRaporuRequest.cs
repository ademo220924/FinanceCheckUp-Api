namespace FinanceCheckUp.Application.Models.Requests.Finance.Reports;

public class CompanyReportHelperMizanRaporuRequest
{
    public int Year { get; set; }
    public long CompanyId { get; set; }
    public string CompanyName { get; set; }
}
