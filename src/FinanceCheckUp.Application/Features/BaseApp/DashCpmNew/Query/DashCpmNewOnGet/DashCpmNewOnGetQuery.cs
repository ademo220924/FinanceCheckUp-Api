using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCpmNew;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGet;
public class DashCpmNewOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashCpmNewOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCpmNewOnGetRequest Request { get; set; }

}