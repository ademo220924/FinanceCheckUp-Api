using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetWorkingCapital;
public class FinanceReportMainOnGetWorkingCapitalQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainOnGetWorkingCapitalResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainOnGetWorkingCapitalRequest Request { get; set; }
    public FinanceReportMainRequestInitialModel InitialModel { get; set; }
}
