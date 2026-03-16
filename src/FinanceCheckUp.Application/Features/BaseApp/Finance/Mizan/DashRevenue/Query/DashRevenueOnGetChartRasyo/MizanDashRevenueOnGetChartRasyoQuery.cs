using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGetChartRasyo;
public class MizanDashRevenueOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashRevenueOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashRevenueOnGetChartRasyoRequest Request { get; set; }
    public MizanDashRevenueRequestInitialMopdel InitialModel { get; set; }
}
