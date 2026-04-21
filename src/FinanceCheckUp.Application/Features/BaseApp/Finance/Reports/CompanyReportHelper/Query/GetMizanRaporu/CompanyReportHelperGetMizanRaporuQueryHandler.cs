using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporu;

public class CompanyReportHelperGetMizanRaporuQueryHandler(
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager)
    : IRequestHandler<CompanyReportHelperGetMizanRaporuQuery, GenericResult<CompanyReportHelperMizanRaporuResponse>>
{
    public Task<GenericResult<CompanyReportHelperMizanRaporuResponse>> Handle(
        CompanyReportHelperGetMizanRaporuQuery request,
        CancellationToken cancellationToken)
    {
        var company = companyManager.Get_CompanyRow(request.Request.CompanyId);
        var payload = companyReportManager.BuildMizanRaporuApiPayload(request.Request.Year, company);
        return Task.FromResult(GenericResult<CompanyReportHelperMizanRaporuResponse>.Success(payload));
    }
}
