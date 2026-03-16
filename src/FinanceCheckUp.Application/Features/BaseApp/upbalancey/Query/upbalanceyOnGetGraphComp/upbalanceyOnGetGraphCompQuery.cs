using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalancey;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetGraphComp;
public class upbalanceyOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceyOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceyOnGetGraphCompRequest Request { get; set; }

}