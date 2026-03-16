using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetGraphComp;
public class DashLiquidityOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashLiquidityOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashLiquidityOnGetGraphCompRequest Request { get; set; }

}