using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtNeo;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGetMarkupMarjinA;
public class FinanceFinanceHrtNeoOnGetMarkupMarjinAQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinAResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtNeoOnGetMarkupMarjinARequest Request { get; set; }
    public FinanceFinanceHrtNeoRequestInitialModel InitialModel { get; set; }
}
