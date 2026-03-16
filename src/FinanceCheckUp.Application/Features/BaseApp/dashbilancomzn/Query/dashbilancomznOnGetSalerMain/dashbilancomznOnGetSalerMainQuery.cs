using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancomzn;
using FinanceCheckUp.Application.Models.Responses.dashbilancomzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancomzn.Query.dashbilancomznOnGetSalerMain;
public class dashbilancomznOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancomznOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancomznOnGetSalerMainRequest Request { get; set; }

}