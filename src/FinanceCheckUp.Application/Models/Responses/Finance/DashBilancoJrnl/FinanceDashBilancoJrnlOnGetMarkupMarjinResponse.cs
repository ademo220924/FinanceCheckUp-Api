using FinanceCheckUp.Application.Models.Requests.Finance.DashBilancoJrnl;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashBilancoJrnl
{
    public class FinanceDashBilancoJrnlOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashBilancoJrnlRequestInitialModel InitialModel { get; set; }
    }
}
