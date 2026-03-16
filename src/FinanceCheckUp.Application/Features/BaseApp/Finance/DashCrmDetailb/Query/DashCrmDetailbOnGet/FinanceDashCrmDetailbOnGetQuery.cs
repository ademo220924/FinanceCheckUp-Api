using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetailb;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetailb.Query.DashCrmDetailbOnGet;
public class FinanceDashCrmDetailbOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmDetailbOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashCrmDetailbOnGetRequest Request { get; set; }
    public FinanceDashCrmDetailbRequestInitialModel InitialModel { get; set; }
}
