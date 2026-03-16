using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmzn;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmzn.Query.dashbilancorvnmznOnGetGraphComp;
public class dashbilancorvnmznOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmznOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnmznOnGetGraphCompRequest Request { get; set; }

}