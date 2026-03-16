using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashBilanco;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilanco.Query.FinanceDashBilancoOnGet;
public class FinanceDashBilancoOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashBilancoOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashBilancoOnGetRequest Request { get; set; }
}
