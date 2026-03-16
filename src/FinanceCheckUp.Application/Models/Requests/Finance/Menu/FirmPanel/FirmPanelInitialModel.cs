using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Menu.FirmPanel
{
    public class FirmPanelInitialModel
    {
        public long UserID;
        public int UserTypeID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqList;
    }
}
