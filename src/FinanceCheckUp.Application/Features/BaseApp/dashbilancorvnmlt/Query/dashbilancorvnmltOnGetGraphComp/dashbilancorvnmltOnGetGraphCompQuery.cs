using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancorvnmlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGetGraphComp;
public class dashbilancorvnmltOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmltOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancorvnmltOnGetGraphCompRequest Request { get; set; }

}