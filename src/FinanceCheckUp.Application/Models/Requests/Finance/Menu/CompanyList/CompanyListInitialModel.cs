using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyList
{
    public class CompanyListInitialModel
    {
        public long UserID; 
        public int UserTypeID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqList;
    }
}
