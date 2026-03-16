using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetail;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGetSalerMain;
public class DashCrmDetailOnGetSalerMainQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetailOnGetSalerMainResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetailOnGetSalerMainRequest Request { get; set; }

}