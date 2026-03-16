using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancoakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGet;
public class dashbilancoaktOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancoaktOnGetResponse>>
{

    public dashbilancoaktOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}