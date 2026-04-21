using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Mapper;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReport;

public class FinanceReportCheckZoneMainGetReportQueryHandler(
    IReportCheckZoneManager reportCheckZoneManager,
    ICompanyManager companyManager)
    : IRequestHandler<FinanceReportCheckZoneMainGetReportQuery, GenericResult<FinancialReportZonePayloadResponse>>
{
    public Task<GenericResult<FinancialReportZonePayloadResponse>> Handle(
        FinanceReportCheckZoneMainGetReportQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var payload = ReportCheckZoneFinancialPayloadOrchestrator.BuildFromGetReport(
                reportCheckZoneManager,
                companyManager,
                request.Request);
            return Task.FromResult(GenericResult<FinancialReportZonePayloadResponse>.Success(payload));
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinancialReportZonePayloadResponse>.Fail(ex.Message));
        }
    }
}
