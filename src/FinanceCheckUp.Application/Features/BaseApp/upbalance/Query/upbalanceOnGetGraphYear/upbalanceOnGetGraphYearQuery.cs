using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalance;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetGraphYear;
public class upbalanceOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceOnGetGraphYearRequest Request { get; set; }

}