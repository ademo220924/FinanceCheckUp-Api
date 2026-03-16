using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancoakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetSalerMain;
public class dashbilancoaktOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancoaktOnGetSalerMainResponse>>
{

    public dashbilancoaktOnGetSalerMainRequest Request { get; set; }
    [JsonIgnore] public  string UserId { get; set; }
}