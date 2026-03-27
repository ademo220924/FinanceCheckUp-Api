using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsolList;

public class MizanCompanyKonsolListOnGetKonListResponse
{
    public LoadResult Response { get; set; }
    public MizanCompanyKonsolListRequestInitialModel InitialModel { get; set; }
}
