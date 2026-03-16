using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashWorkingCapital.Query.DashWorkingCapitalOnGetMarkupMarjin;
public class MizanDashWorkingCapitalOnGetMarkupMarjinQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashWorkingCapitalOnGetMarkupMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanDashWorkingCapitalOnGetMarkupMarjinRequest Request { get; set; }
    public MizanDashWorkingCapitalRequestInitialModel InitialModel { get; set; }
}
