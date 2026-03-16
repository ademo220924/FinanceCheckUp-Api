using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetChartLikid;
public class FinanceDashRasyoOnGetChartLikidQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashRasyoOnGetChartLikidResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashRasyoOnGetChartLikidRequest Request { get; set; }
    public FinanceDashRasyoRequestInitialModel InitialModel { get; set; }
}
