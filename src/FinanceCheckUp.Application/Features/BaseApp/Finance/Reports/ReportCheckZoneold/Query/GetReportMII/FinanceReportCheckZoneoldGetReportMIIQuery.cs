using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMII;

public class FinanceReportCheckZoneoldGetReportMIIQuery : IRequest<GenericResult<FinancialReportZonePayloadResponse>>
{
    public ReportCheckZoneoldStandardRequest Request { get; set; }
}
