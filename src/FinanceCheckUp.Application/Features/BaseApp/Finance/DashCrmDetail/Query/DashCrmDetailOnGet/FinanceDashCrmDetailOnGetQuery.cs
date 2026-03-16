using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrmDetail;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrmDetail.Query.DashCrmDetailOnGet;

public class FinanceDashCrmDetailOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmDetailOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashCrmDetailOnGetRequest Request { get; set; }
    public FinanceDashCrmDetailRequestInitialModel InitialModel { get; set; }
}
