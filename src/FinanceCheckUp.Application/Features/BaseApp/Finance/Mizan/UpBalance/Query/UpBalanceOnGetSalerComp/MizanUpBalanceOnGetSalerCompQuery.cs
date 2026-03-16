using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGetSalerComp
{
    public class MizanUpBalanceOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpBalanceOnGetSalerCompResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpBalanceOnGetSalerCompRequest Request { get; set; }
    }
}
