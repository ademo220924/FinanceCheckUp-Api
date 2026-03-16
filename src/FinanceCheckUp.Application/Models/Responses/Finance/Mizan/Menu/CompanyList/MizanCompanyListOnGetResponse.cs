using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyList;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyList
{
    public class MizanCompanyListOnGetResponse
    {
        public MizanCompanyListRequestInitialModel InitialModel { get; set; }
        public string ResponseRedirectUrl { get; set; } = string.Empty;
    }
}
