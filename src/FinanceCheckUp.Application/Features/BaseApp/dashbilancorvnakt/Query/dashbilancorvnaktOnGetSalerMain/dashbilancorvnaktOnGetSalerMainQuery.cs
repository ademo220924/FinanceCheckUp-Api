using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnakt.Query.dashbilancorvnaktOnGetSalerMain;
public class dashbilancorvnaktOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnaktOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnaktOnGetSalerMainRequest Request { get; set; }

}