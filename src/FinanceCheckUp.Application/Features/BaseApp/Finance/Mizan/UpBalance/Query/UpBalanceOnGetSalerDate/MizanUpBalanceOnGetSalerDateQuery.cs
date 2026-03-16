using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGetSalerDate
{
    public class MizanUpBalanceOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<MizanUpBalanceOnGetSalerDateResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanUpBalanceOnGetSalerDateRequest Request { get; set; }
        public MizanUpBalanceRequestInitialModel InitialModel { get; set; }
    }
}
