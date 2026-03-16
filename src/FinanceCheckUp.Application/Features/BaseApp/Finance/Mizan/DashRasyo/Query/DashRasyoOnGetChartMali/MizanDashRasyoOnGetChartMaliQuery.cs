using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetChartMali;
public class MizanDashRasyoOnGetChartMaliQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashRasyoOnGetChartMaliResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashRasyoOnGetChartMaliRequest Request { get; set; }
}
