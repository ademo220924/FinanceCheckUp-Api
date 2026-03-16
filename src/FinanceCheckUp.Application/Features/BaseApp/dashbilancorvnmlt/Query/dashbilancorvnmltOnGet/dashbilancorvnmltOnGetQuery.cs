using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.dashbilancorvnmlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancorvnmlt.Query.dashbilancorvnmltOnGet;
public class dashbilancorvnmltOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancorvnmltOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
}