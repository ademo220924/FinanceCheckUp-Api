using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashCrm.Query.FinanceDashCrmOnGetCasino;
public class FinanceDashCrmOnGetCasinoQuery : IUserIdAssignable , IRequest<GenericResult<FinanceDashCrmOnGetCasinoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceDashCrmOnGetCasinoRequest Request { get; set; }
    public FinanceDashCrmRequestInitialModel InitialModel { get; set; }
}
