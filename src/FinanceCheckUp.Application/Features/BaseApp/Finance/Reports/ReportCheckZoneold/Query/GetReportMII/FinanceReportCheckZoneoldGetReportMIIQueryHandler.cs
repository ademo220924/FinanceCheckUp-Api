using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Mapper;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMII;

public class FinanceReportCheckZoneoldGetReportMIIQueryHandler(
    IReportCheckZoneManager reportCheckZoneManager,
    ICompanyManager companyManager)
    : IRequestHandler<FinanceReportCheckZoneoldGetReportMIIQuery, GenericResult<FinancialReportZonePayloadResponse>>
{
    public Task<GenericResult<FinancialReportZonePayloadResponse>> Handle(
        FinanceReportCheckZoneoldGetReportMIIQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var payload = ReportCheckZoneFinancialPayloadOrchestrator.BuildFromGetReportOldMII(
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
