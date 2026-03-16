using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportBalance;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportBalance.Query.ReportBalanceOnGet;
public class MizanReportBalanceOnGetQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportBalanceOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanReportBalanceOnGetRequest Request { get; set; }
}
