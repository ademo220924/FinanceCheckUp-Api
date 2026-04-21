using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReport;

public class FinanceReportCheckZoneMainGetReportQuery : IRequest<GenericResult<FinancialReportZonePayloadResponse>>
{
    public ReportCheckZoneMainWithYearListRequest Request { get; set; }
}
