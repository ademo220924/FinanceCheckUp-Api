using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.dashbilancoakt;
using FinanceCheckUp.Application.Models.Responses.dashbilancoakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.dashbilancoakt.Query.dashbilancoaktOnGetGraphYear;
public class dashbilancoaktOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<dashbilancoaktOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public dashbilancoaktOnGetGraphYearRequest Request { get; set; }

}