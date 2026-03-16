using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCpmNew;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetChartMali;
public class DashCpmNewOnGetChartMaliQuery : IUserIdAssignable , IRequest<GenericResult<DashCpmNewOnGetChartMaliResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCpmNewOnGetChartMaliRequest Request { get; set; }

}