using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyList
{
    public class MizanCompanyListRequestInitialModel
    {
        public long UserID; 
        public int UserTypeID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqList;
    }
}
