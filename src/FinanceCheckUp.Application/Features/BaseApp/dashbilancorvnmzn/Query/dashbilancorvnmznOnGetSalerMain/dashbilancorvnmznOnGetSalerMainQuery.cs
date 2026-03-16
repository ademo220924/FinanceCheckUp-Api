using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmzn;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGetSalerMain;
public class dashbilancorvnmznOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmznOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnmznOnGetSalerMainRequest Request { get; set; }

}