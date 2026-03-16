using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserEdit
{
    public class UserEditInitialModel
    {
        public long UserID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public List<UserType> mreqListUserType;
        public IEnumerable<City> mreqListCitiy;
        public IEnumerable<YearResult> myearResult;

        public HhvnUsers mrequest;

        public string mreqListCitiystr { get; set; }
    }
}
