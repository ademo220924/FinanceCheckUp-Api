using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrm;
using FinanceCheckUp.Application.Models.Responses.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrm.Query.DashCrmOnGet;
public class DashCrmOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmOnGetRequest Request { get; set; }

}