using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetChartRasyoc;
public class DashCrmOnGetChartRasyocQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmOnGetChartRasyocResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmOnGetChartRasyocRequest Request { get; set; }

}