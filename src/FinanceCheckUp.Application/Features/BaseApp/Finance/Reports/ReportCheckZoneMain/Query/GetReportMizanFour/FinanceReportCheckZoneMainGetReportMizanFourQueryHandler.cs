using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Mapper;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneMain.Query.GetReportMizanFour;

public class FinanceReportCheckZoneMainGetReportMizanFourQueryHandler(
    IReportCheckZoneManager reportCheckZoneManager)
    : IRequestHandler<FinanceReportCheckZoneMainGetReportMizanFourQuery, GenericResult<FinancialReportZonePayloadResponse>>
{
    public Task<GenericResult<FinancialReportZonePayloadResponse>> Handle(
        FinanceReportCheckZoneMainGetReportMizanFourQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var years = request.Request.NyearChkList ?? new List<int>();
            var payload = ReportCheckZoneFinancialPayloadOrchestrator.BuildFromGetReportMizanFour(
                reportCheckZoneManager,
                years,
                request.Request.Nacceco,
                request.Request.Ncccode ?? string.Empty,
                request.Request.CompanyId,
                request.Request.UserId);
            return Task.FromResult(GenericResult<FinancialReportZonePayloadResponse>.Success(payload));
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinancialReportZonePayloadResponse>.Fail(ex.Message));
        }
    }
}
