using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetEbitMarjin;
public class FinanceReportMainOnGetEbitMarjinQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainOnGetEbitMarjinResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainOnGetEbitMarjinRequest Request { get; set; }
}
