using FinanceCheckUp.Application.Models.Requests.Finance.Menu.FirmPanel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Menu.FirmPanel
{
    public class FirmPanelOnGetResponse
    {
        public FirmPanelInitialModel InitialModel { get; set; }
        public string RedirecrUrl { get; set; }
    }
}
