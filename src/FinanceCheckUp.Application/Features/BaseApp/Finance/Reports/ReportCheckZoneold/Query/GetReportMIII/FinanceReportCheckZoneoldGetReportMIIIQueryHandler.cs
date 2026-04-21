using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Mapper;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ReportCheckZoneold.Query.GetReportMIII;

public class FinanceReportCheckZoneoldGetReportMIIIQueryHandler(
    IReportCheckZoneManager reportCheckZoneManager,
    ICompanyManager companyManager)
    : IRequestHandler<FinanceReportCheckZoneoldGetReportMIIIQuery, GenericResult<FinancialReportZonePayloadResponse>>
{
    public Task<GenericResult<FinancialReportZonePayloadResponse>> Handle(
        FinanceReportCheckZoneoldGetReportMIIIQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var years = request.Request.NyearChkList ?? new List<int>();
            var payload = ReportCheckZoneFinancialPayloadOrchestrator.BuildFromGetReportA(
                reportCheckZoneManager,
                companyManager,
                years,
                years,
                request.Request.Nacceco,
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
