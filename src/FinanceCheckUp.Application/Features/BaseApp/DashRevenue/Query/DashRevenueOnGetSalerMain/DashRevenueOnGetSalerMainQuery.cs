using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetSalerMain;
public class DashRevenueOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueOnGetSalerMainRequest Request { get; set; }

}