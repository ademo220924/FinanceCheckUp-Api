using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCpmNew;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetChartRasyo;
public class DashCpmNewOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<DashCpmNewOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

    public DashCpmNewOnGetChartRasyoRequest Request { get; set; }

}