using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity;
using DevExtreme.AspNet.Data.ResponseModel;

namespace FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashLiquidity
{
    public class MizanDashLiquidityOnGetMarkupMarjinResponse
    {
        public LoadResult Response { get; set; }
        public MizanDashLiquidityRequestInitialModel InitialModel { get; set; }
    }
}
