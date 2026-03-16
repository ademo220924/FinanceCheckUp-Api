using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjinB;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinBQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinBResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinancesHrtfibaprOnGetMarkupMarjinBRequest Request { get; set; }
}
