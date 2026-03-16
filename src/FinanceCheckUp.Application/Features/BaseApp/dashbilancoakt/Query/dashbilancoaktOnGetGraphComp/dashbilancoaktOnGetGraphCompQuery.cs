using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancoakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetGraphComp;
public class dashbilancoaktOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancoaktOnGetGraphCompResponse>>
{

    public dashbilancoaktOnGetGraphCompRequest Request { get; set; }
    public dashbilancoaktRequest InitialModel { get; set; }
    [JsonIgnore] public  string UserId { get; set; }

}