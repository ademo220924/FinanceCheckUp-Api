using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetChartRasyo;
public class MizanFinancesHrtfibaprOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinancesHrtfibaprOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinancesHrtfibaprOnGetChartRasyoRequest Request { get; set; }
    public MizanFinancesHrtfibaprRequestInitialModel InitialModel { get; set; }
}
