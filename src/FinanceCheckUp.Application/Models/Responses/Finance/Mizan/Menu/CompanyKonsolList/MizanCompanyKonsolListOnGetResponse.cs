using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsolList;

public class MizanCompanyKonsolListOnGetResponse
{
    public MizanCompanyKonsolListRequestInitialModel InitialModel { get; set; }
    public string ResponseRedirectUrl { get; set; } = string.Empty;
}
