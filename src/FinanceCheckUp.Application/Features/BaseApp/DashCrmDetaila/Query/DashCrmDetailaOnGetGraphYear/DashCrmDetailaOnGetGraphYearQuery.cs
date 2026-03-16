using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetaila;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetaila;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetaila.Query.DashCrmDetailaOnGetGraphYear;
public class DashCrmDetailaOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetailaOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetailaOnGetGraphYearRequest Request { get; set; }

}