using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.UserList;

public class UserListRequestInitialModel
{
    public long UserID;
    public HhvnUsers CurrentUser;
    public IEnumerable<HhvnUsers> mreqList;
}
