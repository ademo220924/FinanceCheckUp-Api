using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetGraphYear;
public class DashRevenueOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueOnGetGraphYearRequest Request { get; set; }

}