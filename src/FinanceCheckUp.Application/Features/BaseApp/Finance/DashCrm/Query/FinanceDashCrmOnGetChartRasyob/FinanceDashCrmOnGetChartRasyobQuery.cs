using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetChartRasyob;
public class FinanceDashCrmOnGetChartRasyobQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmOnGetChartRasyobResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashCrmOnGetChartRasyobRequest Request { get; set; }
    public FinanceDashCrmRequestInitialModel InitialModel { get; set; }
}
