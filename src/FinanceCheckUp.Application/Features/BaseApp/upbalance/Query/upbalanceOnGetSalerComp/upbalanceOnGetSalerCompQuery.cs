using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalance;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetSalerComp;
public class upbalanceOnGetSalerCompQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceOnGetSalerCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceOnGetSalerCompRequest Request { get; set; }

}