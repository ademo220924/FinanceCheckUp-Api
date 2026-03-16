using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList
{
    public class MizanCompanyKonsolListRequestInitialModel
    {
        public int UserID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqList;
        public Company mrequest;
    }
}
