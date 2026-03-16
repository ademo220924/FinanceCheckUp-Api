using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsolList
{
    public class CompanyKonsolListInitialModel
    {
        public int UserID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqList;
        public Company mrequest;
    }
}
