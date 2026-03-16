using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrt;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrt.Query.FinanceFinanceHrtOnGet;
public class FinanceFinanceHrtOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtOnGetRequest Request { get; set; }
}
