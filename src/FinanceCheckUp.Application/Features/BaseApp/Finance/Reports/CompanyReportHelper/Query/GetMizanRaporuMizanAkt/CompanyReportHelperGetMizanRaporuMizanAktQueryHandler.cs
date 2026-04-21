using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporuMizanAkt;

public class CompanyReportHelperGetMizanRaporuMizanAktQueryHandler(
    ICompanyReportManager companyReportManager,
    ICompanyManager companyManager)
    : IRequestHandler<CompanyReportHelperGetMizanRaporuMizanAktQuery, GenericResult<CompanyReportHelperMizanRaporuMizanAktResponse>>
{
    public Task<GenericResult<CompanyReportHelperMizanRaporuMizanAktResponse>> Handle(
        CompanyReportHelperGetMizanRaporuMizanAktQuery request,
        CancellationToken cancellationToken)
    {
        var company = companyManager.Get_CompanyRow(request.Request.CompanyId);
        var payload = companyReportManager.BuildMizanRaporuMizanAktApiPayload(request.Request.Year, company);
        return Task.FromResult(GenericResult<CompanyReportHelperMizanRaporuMizanAktResponse>.Success(payload));
    }
}
