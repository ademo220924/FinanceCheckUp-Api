using FinanceCheckUp.Domain.Common;
using System.Text.Json.Serialization;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGet
{
    public class MizanUpBalanceOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpBalanceOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
    }
}
