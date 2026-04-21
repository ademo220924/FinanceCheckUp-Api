using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Models.ViewModel.Reports;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Reports;

public class CompanyReportHelperMizanRaporuResponse
{
    public string Header { get; set; }
    public ReportMizan MainReportText { get; set; }
    public List<ReportSet> Bilanco { get; set; }
    public List<DashMizanResult> MizanResult { get; set; }
    public List<DashDonukView> DonukChk { get; set; }
    public List<DashMizanResult> TicariAlici { get; set; }
    public List<DashMizanResult> TicariBorclu { get; set; }
}
