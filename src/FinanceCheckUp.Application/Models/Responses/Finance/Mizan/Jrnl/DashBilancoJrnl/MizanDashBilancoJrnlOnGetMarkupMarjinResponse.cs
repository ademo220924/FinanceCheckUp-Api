using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.DashBilancoJrnl;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.DashBilancoJrnl
{
    public class MizanDashBilancoJrnlOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashBilancoJrnlRequestInitialModel InitialModel { get; set; }
    }
}
