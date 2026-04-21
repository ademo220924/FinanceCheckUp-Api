using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReportMizanFour;

public class FinanceReportCheckZoneMainGetReportMizanFourQuery : IRequest<GenericResult<FinancialReportZonePayloadResponse>>
{
    public ReportCheckZoneMainStandardRequest Request { get; set; }
}
