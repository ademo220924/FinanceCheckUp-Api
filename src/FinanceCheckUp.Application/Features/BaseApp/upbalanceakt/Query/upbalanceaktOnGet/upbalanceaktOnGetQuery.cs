using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalanceakt;
using FinanceCheckUp.Application.Models.Responses.upbalanceakt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalanceakt.Query.upbalanceaktOnGet;
public class upbalanceaktOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceaktOnGetResponse>>
{

    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceaktOnGetRequest Request { get; set; }

}