using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashLiquidity.Query.DashLiquidityOnGetMarkupMarjin;
public class MizanDashLiquidityOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashLiquidityOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashLiquidityOnGetMarkupMarjinRequest Request { get; set; }
    public MizanDashLiquidityRequestInitialModel InitialModel { get; set; }
}
