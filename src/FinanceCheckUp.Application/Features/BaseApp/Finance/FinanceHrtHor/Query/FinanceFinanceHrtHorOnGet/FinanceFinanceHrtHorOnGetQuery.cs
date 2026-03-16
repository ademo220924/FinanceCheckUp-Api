using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtHor;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGet;
public class FinanceFinanceHrtHorOnGetQuery : IUserIdAssignable , IRequest<GenericResult<FinanceFinanceHrtHorOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceFinanceHrtHorOnGetRequest Request { get; set; }
}
