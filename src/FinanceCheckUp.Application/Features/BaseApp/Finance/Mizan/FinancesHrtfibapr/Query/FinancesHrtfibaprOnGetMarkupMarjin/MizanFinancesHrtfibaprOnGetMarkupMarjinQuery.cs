using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjin;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinancesHrtfibaprOnGetMarkupMarjinRequest Request { get; set; }
}
