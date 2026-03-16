using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetaild;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaild;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaild.Query.DashCrmDetaildOnGetGraphComp;
public class DashCrmDetaildOnGetGraphCompQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetaildOnGetGraphCompResponse>>
{

    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetaildOnGetGraphCompRequest Request { get; set; }

}