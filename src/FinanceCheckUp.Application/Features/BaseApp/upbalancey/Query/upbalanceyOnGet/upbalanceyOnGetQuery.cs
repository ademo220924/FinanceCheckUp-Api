using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGet;
public class upbalanceyOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceyOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}