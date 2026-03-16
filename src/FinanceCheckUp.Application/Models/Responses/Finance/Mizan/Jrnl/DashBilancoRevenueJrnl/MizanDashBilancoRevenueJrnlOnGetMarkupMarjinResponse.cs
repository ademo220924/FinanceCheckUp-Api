using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoRevenueJrnl
{
    public class MizanDashBilancoRevenueJrnlOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashBilancoRevenueJrnlRequestInitialModel InitialModel { get; set; }
    }
}
