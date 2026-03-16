using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGet;
public class DashRevenueOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueOnGetRequest Request { get; set; }

}