using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity
{
    public class MizanDashLiquidityOnGetMarkupMarjinRequest
    {
        public DataSourceLoadOptions options { get; set; }
        public long compid { get; set; }
    }
}
