using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenue.Query.DashRevenueOnGet;
public class FinanceDashRevenueOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRevenueOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashRevenueOnGetRequest Request { get; set; }
}
