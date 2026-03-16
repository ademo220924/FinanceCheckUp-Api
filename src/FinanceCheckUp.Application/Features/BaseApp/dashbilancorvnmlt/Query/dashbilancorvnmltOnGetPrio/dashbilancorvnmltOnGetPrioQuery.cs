using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetPrio;
public class dashbilancorvnmltOnGetPrioQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmltOnGetPrioResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnmltOnGetPrioRequest Request { get; set; }

}