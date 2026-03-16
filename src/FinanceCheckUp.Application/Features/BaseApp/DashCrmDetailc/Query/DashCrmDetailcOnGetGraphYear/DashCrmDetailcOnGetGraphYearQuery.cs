using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetailc;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailc;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailc.Query.DashCrmDetailcOnGetGraphYear;
public class DashCrmDetailcOnGetGraphYearQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetailcOnGetGraphYearResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetailcOnGetGraphYearRequest Request { get; set; }

}