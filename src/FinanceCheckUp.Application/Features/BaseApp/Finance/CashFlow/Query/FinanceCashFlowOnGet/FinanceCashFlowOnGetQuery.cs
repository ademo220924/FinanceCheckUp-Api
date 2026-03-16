using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.CashFlow;
using FinanceCheckUp.Application.Models.Responses.Finance.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGet;

public class FinanceCashFlowOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceCashFlowOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceCashFlowOnGetRequest Request { get; set; }
}