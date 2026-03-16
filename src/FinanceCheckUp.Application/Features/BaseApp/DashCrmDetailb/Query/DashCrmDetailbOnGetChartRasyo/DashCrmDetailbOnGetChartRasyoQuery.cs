using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetailb;
using FinanceCheckUp.Application.Models.Responses.DashCrmDetailb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetailb.Query.DashCrmDetailbOnGetChartRasyo;
public class DashCrmDetailaOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetailaOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetailbOnGetChartRasyoRequest Request { get; set; }

}