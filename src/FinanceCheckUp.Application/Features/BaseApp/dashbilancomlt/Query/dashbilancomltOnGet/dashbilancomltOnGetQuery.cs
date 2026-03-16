using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancomlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGet;
public class dashbilancomltOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomltOnGetResponse>>
{

    public dashbilancomltOnGetRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}