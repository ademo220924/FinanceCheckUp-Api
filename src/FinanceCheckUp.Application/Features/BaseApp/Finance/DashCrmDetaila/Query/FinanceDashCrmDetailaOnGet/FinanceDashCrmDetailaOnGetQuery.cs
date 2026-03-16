using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetaila;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetaila.Query.FinanceDashCrmDetailaOnGet;
public class FinanceDashCrmDetailaOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmDetailaOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashCrmDetailaOnGetRequest Request { get; set; }
    public FinanceDashCrmDetailaRequestInitialModel InitialModel { get; set; }
}
