using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.CashFlow.Query.CashFlowOnGet
{
    public class MizanCashFlowOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanCashFlowOnGetResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCashFlowOnGetRequest Request { get; set; }
    }
}
