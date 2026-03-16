using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartLikid;
public class DashCrmOnGetChartLikidQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmOnGetChartLikidResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmOnGetChartLikidRequest Request { get; set; }

}