using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetail;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGet;
public class DashCrmDetailOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetailOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetailOnGetRequest Request { get; set; }
}