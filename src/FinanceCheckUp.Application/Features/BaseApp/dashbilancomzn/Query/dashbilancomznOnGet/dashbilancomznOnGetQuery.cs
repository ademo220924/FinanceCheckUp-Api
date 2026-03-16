using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.dashbilancomzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGet;
public class dashbilancomznOnGetQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomznOnGetResponse>>
{
    public int myear { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}