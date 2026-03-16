using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashCrmDetail;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashCrmDetail.Query.DashCrmDetailOnGetChartRasyo;
public class DashCrmDetailOnGetChartRasyoQuery : IUserIdAssignable , IRequest<GenericResult<DashCrmDetailOnGetChartRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashCrmDetailOnGetChartRasyoRequest Request { get; set; }

}