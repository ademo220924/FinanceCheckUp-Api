using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalanceAkt
{
    public class MizanUpBalanceAktRequestInitialModel
    {
        public long UserID;
        public long CompID;
        public string header;
        public Company CCompanies;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public List<ReportSet> ncheck;
    }
}
