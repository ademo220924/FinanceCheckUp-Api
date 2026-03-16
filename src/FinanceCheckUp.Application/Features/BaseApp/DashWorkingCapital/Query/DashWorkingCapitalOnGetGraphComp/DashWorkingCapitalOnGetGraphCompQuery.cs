using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashWorkingCapital.Query.DashWorkingCapitalOnGetGraphComp;
public class DashWorkingCapitalOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashWorkingCapitalOnGetGraphCompResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashWorkingCapitalOnGetGraphCompRequest Request { get; set; }

}