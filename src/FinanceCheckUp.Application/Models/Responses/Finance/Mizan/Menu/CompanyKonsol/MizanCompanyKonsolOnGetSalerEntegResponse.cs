using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.CompanyKonsol;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.CompanyKonsol
{
    public class MizanCompanyKonsolOnGetSalerEntegResponse
    {
        public JsonResult Response { get; set; }
        public MizanCompanyKonsolRequestInitialModel InitialModel { get; set; }
    }
}
