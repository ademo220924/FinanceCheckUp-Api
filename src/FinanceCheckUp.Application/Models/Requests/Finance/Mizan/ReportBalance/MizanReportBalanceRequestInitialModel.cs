using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportBalance
{
    public class MizanReportBalanceRequestInitialModel
    {
        public long UserID;
        public long CompID;
        public string header;
        public Company CCompanies;
        public ReportMizan mainreporttext;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public List<ReportSet> ncheck;
        public List<DashMizanResult> ncheck1;
        public List<DashDonukView> ncheck2;
        public List<DashMizanResult> ncheck3;
        public List<DashMizanResult> ncheck4;
    }
}
