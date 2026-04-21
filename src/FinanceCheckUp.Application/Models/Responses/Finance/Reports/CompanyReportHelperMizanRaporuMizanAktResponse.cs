using FinanceCheckUp.Application.Models.ViewModel.Reports;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Reports;

public class CompanyReportHelperMizanRaporuMizanAktResponse
{
    public string Header { get; set; }
    public List<ReportSet> BilancoAktarma { get; set; }
}
