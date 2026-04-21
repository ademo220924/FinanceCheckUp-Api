using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporuMizan;

public class CompanyReportHelperGetMizanRaporuMizanQueryHandler(
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager)
    : IRequestHandler<CompanyReportHelperGetMizanRaporuMizanQuery, GenericResult<CompanyReportHelperMizanRaporuMizanResponse>>
{
    public Task<GenericResult<CompanyReportHelperMizanRaporuMizanResponse>> Handle(
        CompanyReportHelperGetMizanRaporuMizanQuery request,
        CancellationToken cancellationToken)
    {
        var company = companyManager.Get_CompanyRow(request.Request.CompanyId);
        var payload = companyReportManager.BuildMizanRaporuMizanApiPayload(request.Request.Year, company);
        return Task.FromResult(GenericResult<CompanyReportHelperMizanRaporuMizanResponse>.Success(payload));
    }
}
