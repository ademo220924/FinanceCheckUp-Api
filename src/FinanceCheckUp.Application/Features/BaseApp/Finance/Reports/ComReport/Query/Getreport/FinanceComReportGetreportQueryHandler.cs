using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Managers.StaticManagers;
using FinanceCheckUp.Application.Mapper;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.ComReport.Query.Getreport;

public class FinanceComReportGetreportQueryHandler(
    IComReportManager comReportManager,
    ICompanyManager companyManager)
    : IRequestHandler<FinanceComReportGetreportQuery, GenericResult<FinancialReportZonePayloadResponse>>
{
    public Task<GenericResult<FinancialReportZonePayloadResponse>> Handle(
        FinanceComReportGetreportQuery request,
        CancellationToken cancellationToken)
    {
        var company = companyManager.Get_CompanyRow(request.Request.CompanyId);
        var model = comReportManager.BuildComReportModel(request.Request.Year, company);
        var payload = ComReportToFinancialReportZonePayloadMapper.Map(model);
        return Task.FromResult(GenericResult<FinancialReportZonePayloadResponse>.Success(payload));
    }
}
