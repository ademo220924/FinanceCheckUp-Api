using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancomlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetPrio;
public class dashbilancomltOnGetPrioQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomltOnGetPrioResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

    public dashbilancomltOnGetPrioRequest Request { get; set; }

}