using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashLiquidity
{
    public class MizanDashLiquidityOnGetMarkupMarjinResponse
    {
        public JsonResult Response { get; set; }
        public MizanDashLiquidityRequestInitialModel InitialModel { get; set; }
    }
}
