using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGet;
public class dashbilancorvnaktOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnaktOnGetResponse>>
{

    public dashbilancorvnaktOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}