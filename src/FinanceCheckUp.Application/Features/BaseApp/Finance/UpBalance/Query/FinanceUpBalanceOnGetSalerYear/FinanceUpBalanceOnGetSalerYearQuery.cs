using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.UpBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerYear;
public class FinanceUpBalanceOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<FinanceUpBalanceOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceUpBalanceOnGetSalerYearRequest Request { get; set; }
}
