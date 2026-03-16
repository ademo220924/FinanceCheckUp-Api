using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalancey;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetSalerDate;
public class upbalanceyOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceyOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceyOnGetSalerDateRequest Request { get; set; }

}