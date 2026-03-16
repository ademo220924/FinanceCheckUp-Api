using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserList
{
    public class MizanUserListRequestInitialModel
    {
        public long UserID;
        public HhvnUsers CurrentUser;
        public IEnumerable<HhvnUsers> mreqList;
    }
}
