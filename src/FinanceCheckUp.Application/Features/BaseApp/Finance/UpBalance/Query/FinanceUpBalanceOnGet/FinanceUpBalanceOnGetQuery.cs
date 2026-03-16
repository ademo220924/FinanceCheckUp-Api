using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGet;
public class FinanceUpBalanceOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpBalanceOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpBalanceOnGetRequest Request { get; set; }
}
