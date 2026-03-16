using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.CashFlow.Query.CashFlowOnGetChartRasyo
{
    public class MizanCashFlowOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<MizanCashFlowOnGetChartRasyoResponse>>
    {
        [JsonIgnore] public  string UserId { get; set; }
        public MizanCashFlowOnGetChartRasyoRequest Request { get; set; }
    }
}
