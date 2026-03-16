using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.upbalancey;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetSalerYear;
public class upbalanceyOnGetSalerYearQuery : IUserIdAssignable , IRequest<GenericResult<upbalanceyOnGetSalerYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public upbalanceyOnGetSalerYearRequest Request { get; set; }

}