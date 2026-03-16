using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGetGraphComp;
public class DashCrmOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmOnGetGraphCompRequest Request { get; set; }

}