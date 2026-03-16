using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGetGraphComp;
public class dashbilancorvnaktOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnaktOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnaktOnGetGraphCompRequest Request { get; set; }

}