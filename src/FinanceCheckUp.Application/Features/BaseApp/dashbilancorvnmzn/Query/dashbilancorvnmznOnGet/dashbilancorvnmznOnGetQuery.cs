using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmzn;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGet;
public class dashbilancorvnmznOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmznOnGetResponse>>
{

    public dashbilancorvnmznOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}