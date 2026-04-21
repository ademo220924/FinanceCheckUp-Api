using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Reports;

public class CompanyReportHelperDenetimRaporuRequest
{
    public int Year { get; set; }
    public long CompanyId { get; set; }
    public int MonthId { get; set; }
    public List<DataViewer> Ncheck { get; set; }
}
