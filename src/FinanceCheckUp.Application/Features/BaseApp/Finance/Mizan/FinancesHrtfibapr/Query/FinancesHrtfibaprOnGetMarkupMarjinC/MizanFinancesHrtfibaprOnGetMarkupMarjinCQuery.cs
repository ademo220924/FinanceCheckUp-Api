using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjinC;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinCQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinCResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinancesHrtfibaprOnGetMarkupMarjinCRequest Request { get; set; }
}
