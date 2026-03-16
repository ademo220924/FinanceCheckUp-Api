using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetGrossProfit;
public class MizanReportMainOnGetGrossProfitQuery : IUserIdAssignable , IRequest<GenericResult<MizanReportMainOnGetGrossProfitResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public MizanReportMainOnGetGrossProfitRequest Request { get; set; }
}
