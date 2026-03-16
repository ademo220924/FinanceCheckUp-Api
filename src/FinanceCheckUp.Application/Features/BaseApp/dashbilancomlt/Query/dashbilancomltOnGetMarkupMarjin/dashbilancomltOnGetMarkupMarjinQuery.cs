using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancomlt;
using FinanceCheckUp.Application.Models.Responses.dashbilancomlt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomlt.Query.dashbilancomltOnGetMarkupMarjin;
public class dashbilancomltOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomltOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancomltOnGetMarkupMarjinRequest Request { get; set; }

}