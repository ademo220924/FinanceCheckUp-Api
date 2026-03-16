using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashLiquidity.Query.DashLiquidityOnGetGraphYear;
public class DashLiquidityOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashLiquidityOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashLiquidityOnGetGraphYearRequest Request { get; set; }

}