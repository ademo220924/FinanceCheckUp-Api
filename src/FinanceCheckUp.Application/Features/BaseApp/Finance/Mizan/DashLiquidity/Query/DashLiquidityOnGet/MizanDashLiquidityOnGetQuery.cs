using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashLiquidity.Query.DashLiquidityOnGet;

public class MizanDashLiquidityOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashLiquidityOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
   
}
