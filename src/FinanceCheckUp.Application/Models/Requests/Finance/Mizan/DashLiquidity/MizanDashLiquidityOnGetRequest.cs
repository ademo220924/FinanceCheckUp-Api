using FinanceCheckUp.Domain.Common;

using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity
{
    public class MizanDashLiquidityOnGetRequest : IUserIdAssignable
    {
        [JsonIgnore] public  string UserId { get; set; }
       
    }
}
