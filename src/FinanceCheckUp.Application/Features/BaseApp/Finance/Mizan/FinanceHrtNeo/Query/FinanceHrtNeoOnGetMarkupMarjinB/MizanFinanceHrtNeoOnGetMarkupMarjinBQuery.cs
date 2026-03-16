using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtNeo.Query.FinanceHrtNeoOnGetMarkupMarjinB;
public class MizanFinanceHrtNeoOnGetMarkupMarjinBQuery : IUserIdAssignable , IRequest<GenericResult<MizanFinanceHrtNeoOnGetMarkupMarjinBResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanFinanceHrtNeoOnGetMarkupMarjinBRequest Request { get; set; }
}
