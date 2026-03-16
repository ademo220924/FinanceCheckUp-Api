using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalancemzn;
using FinanceCheckUp.Application.Models.Responses.upbalancemzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancemzn.Query.upbalancemznOnGet;
public class upbalancemznOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upbalancemznOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalancemznOnGetRequest Request { get; set; }

}