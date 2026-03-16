using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenueJrnl;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashRevenueJrnl
{
    public class FinanceDashRevenueJrnlOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public FinanceDashRevenueJrnlRequestInitialModel InitialModel { get; set; }
    }
}
