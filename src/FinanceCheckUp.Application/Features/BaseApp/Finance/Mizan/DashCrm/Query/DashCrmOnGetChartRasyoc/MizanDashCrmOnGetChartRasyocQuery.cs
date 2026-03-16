using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashCrm;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashCrm;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashCrm.Query.DashCrmOnGetChartRasyoc;
public class MizanDashCrmOnGetChartRasyocQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashCrmOnGetChartRasyocResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashCrmOnGetChartRasyocRequest Request { get; set; }
    public MizanDashCrmRequestInitialModel InitialModel { get; set; }
}
