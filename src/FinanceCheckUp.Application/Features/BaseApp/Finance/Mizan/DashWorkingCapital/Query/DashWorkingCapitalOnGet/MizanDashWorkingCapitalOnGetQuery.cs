using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashWorkingCapital;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashWorkingCapital.Query.DashWorkingCapitalOnGet;
public class MizanDashWorkingCapitalOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanDashWorkingCapitalOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
}
