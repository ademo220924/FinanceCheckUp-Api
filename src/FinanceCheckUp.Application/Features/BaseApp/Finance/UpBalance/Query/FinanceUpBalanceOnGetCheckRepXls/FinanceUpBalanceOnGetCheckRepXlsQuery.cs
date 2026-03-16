using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetCheckRepXls;
public class FinanceUpBalanceOnGetCheckRepXlsQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpBalanceOnGetCheckRepXlsResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpBalanceOnGetCheckRepXlsRequest Request { get; set; }
    public FinanceUpBalanceRequestInitialModel InitialModel { get; set; }
}
