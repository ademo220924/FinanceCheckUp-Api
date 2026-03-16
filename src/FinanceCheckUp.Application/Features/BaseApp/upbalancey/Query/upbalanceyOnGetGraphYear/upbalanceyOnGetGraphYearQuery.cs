using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalancey;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetGraphYear;
public class upbalanceyOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceyOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceyOnGetGraphYearRequest Request { get; set; }

}