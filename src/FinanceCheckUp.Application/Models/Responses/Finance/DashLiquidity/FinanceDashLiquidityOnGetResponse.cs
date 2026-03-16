using FinanceCheckUp.Application.Models.Requests.Finance.DashLiquidity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Models.Responses.Finance.DashLiquidity
{
    public class FinanceDashLiquidityOnGetResponse
    {
        public FinanceDashLiquidityRequestInitialModel InitialModel { get; set; }
        public JsonResult Response { get; set; }
    }
}
