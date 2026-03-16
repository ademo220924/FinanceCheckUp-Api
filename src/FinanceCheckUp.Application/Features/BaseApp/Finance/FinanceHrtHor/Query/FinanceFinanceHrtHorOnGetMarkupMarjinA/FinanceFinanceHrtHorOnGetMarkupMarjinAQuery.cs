using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtHor;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetMarkupMarjinA;
public class FinanceFinanceHrtHorOnGetMarkupMarjinAQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtHorOnGetMarkupMarjinAResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtHorOnGetMarkupMarjinARequest Request { get; set; }
    public FinanceFinanceHrtHorRequestInitialModel InitialModel { get; set; }
}
