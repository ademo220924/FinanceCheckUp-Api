using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ComReport.Query.Getreport;

public class FinanceComReportGetreportQuery : IRequest<GenericResult<FinancialReportZonePayloadResponse>>
{
    public ComReportGetreportRequest Request { get; set; }
}
