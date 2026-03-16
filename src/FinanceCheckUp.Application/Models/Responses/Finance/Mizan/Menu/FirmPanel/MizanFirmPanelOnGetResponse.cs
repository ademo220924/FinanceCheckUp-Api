using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.FirmPanel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.FirmPanel
{
    public class MizanFirmPanelOnGetResponse
    {
        public MizanFirmPanelRequestInitialModel InitialModel { get; set; }
        public string ResponseRedirectUrl { get; set; } = string.Empty;
    }
}
