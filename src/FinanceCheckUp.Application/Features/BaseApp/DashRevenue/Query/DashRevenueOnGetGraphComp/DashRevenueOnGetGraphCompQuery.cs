using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetGraphComp;
public class DashRevenueOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueOnGetGraphCompRequest Request { get; set; }

}