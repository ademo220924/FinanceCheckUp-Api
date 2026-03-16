using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo
{
    public class FinanceDashRasyoOnGetCasinoResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashRasyoRequestInitialModel InitialModel { get; set; }
    }
}
