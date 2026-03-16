using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyob;
public class DashCrmOnGetChartRasyobQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmOnGetChartRasyobResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmOnGetChartRasyobRequest Request { get; set; }

}