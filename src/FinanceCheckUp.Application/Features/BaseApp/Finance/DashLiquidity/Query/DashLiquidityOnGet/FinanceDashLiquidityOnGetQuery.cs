using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashLiquidity;
using FinanceCheckUp.Application.Models.Responses.Finance.DashLiquidity;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashLiquidity.Query.DashLiquidityOnGet
{
    public class FinanceDashLiquidityOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashLiquidityOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public FinanceDashLiquidityOnGetRequest Request { get; set; }
        public FinanceDashLiquidityRequestInitialModel InitialModel { get; set; }
    }
}
