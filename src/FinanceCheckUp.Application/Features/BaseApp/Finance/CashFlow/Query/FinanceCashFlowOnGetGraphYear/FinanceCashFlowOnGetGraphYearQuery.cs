using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.CashFlow;
using FinanceCheckUp.Application.Models.Responses.Finance.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetGraphYear;
public class FinanceCashFlowOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<FinanceCashFlowOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceCashFlowOnGetGraphYearRequest Request { get; set; }
    public FinanceCashFlowRequestInitialModel InitialModel { get; set; }
}
