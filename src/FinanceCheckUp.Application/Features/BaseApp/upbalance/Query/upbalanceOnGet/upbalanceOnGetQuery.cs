using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGet;
public class upbalanceOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
}