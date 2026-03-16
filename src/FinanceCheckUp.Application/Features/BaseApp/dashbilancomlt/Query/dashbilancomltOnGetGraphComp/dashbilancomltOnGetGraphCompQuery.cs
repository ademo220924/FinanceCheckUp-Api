using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancomlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetGraphComp;
public class dashbilancomltOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomltOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancomltOnGetGraphCompRequest Request { get; set; }

}