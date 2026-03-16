using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGet;
public class MizanDashRevenueOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashRevenueOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashRevenueOnGetRequest Request { get; set; }
}