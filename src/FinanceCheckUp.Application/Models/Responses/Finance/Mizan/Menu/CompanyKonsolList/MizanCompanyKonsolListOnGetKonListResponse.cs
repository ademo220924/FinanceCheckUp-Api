using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsolList;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsolList;

public class MizanCompanyKonsolListOnGetKonListResponse
{
    public JsonResult Response { get; set; }
    public MizanCompanyKonsolListRequestInitialModel InitialModel { get; set; }
}
