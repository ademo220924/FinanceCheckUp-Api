using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetChartRasyoa;
public class MizanDashRasyoOnGetChartRasyoaQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashRasyoOnGetChartRasyoaResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashRasyoOnGetChartRasyoaRequest Request { get; set; }
}
