using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRevenue.Query.DashRevenueOnGetChartRasyo;
public class DashRevenueOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<DashRevenueOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRevenueOnGetChartRasyoRequest Request { get; set; }

}