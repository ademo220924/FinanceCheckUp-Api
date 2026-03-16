using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGetMarkupMarjinA;
public class MizanFinanceHrtNeoOnGetMarkupMarjinAQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinAResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtNeoOnGetMarkupMarjinARequest Request { get; set; }
}
