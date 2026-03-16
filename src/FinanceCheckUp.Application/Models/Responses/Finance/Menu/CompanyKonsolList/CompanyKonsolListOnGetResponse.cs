using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyKonsolList;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyKonsolList
{
    public class CompanyKonsolListOnGetResponse
    {
        public CompanyKonsolListInitialModel InitialModel { get; set; }
        public string RedirectUrl { get; set; }
    }
}