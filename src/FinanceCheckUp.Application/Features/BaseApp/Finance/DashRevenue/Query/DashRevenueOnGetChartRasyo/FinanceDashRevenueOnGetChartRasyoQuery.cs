using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRevenue;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRevenue.Query.DashRevenueOnGetChartRasyo;
public class FinanceDashRevenueOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRevenueOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashRevenueOnGetChartRasyoRequest Request { get; set; }
    public FinanceDashRevenueRequestInitialModel InitialModel { get; set; }
}
