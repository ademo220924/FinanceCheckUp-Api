namespace FinanceCheckUp.Application.Models.Requests.Finance.Reports;

public class ComReportGetreportRequest
{
    public int Year { get; set; }
    public long CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string NaceCode { get; set; }
}
