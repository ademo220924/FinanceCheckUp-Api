using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetPrio;
public class DashLiquidityOnGetPrioQuery : IUserIdAssignable , IRequest<GenericResult<DashLiquidityOnGetPrioResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashLiquidityOnGetPrioRequest Request { get; set; }

}