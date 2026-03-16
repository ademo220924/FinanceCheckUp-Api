using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyList;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyList
{
    public class CompanyListOnGetResponse
    {
        public CompanyListInitialModel InitialModel { get; set; }
        public string RedirecrUrl { get; set; }
    }
}
