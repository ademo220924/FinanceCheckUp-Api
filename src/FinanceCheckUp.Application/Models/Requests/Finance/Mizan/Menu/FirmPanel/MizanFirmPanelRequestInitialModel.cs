using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.FirmPanel
{
    public class MizanFirmPanelRequestInitialModel
    {
        public long UserID;
        public int UserTypeID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqList;
    }
}
