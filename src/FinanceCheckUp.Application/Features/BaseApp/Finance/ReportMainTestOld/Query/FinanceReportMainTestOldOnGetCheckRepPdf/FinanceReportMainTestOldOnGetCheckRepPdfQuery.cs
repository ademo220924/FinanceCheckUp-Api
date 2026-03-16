using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Finance.ReportMainTestOld;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetCheckRepPdf;
public class FinanceReportMainTestOldOnGetCheckRepPdfQuery : IUserIdAssignable , IRequest<GenericResult<FinanceReportMainTestOldOnGetCheckRepPdfResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public FinanceReportMainTestOldOnGetCheckRepPdfRequest Request { get; set; }
    public FinanceReportMainTestOldRequestInitialModel InitialModel { get; set; }
}
