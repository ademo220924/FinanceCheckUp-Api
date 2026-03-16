using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtNeo;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGet;
public class FinanceFinanceHrtNeoOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtNeoOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtNeoOnGetRequest Request { get; set; }
}
