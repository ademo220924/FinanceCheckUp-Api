using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetKontrolRaporu;

public class CompanyReportHelperGetKontrolRaporuQueryHandler(ICompanyReportManager companyReportManager)
    : IRequestHandler<CompanyReportHelperGetKontrolRaporuQuery, GenericResult<CompanyReportHelperKontrolRaporuResponse>>
{
    public Task<GenericResult<CompanyReportHelperKontrolRaporuResponse>> Handle(
        CompanyReportHelperGetKontrolRaporuQuery request,
        CancellationToken cancellationToken)
    {
        var ncheck = companyReportManager.BuildKontrolDenetimNcheckList(request.Request.Ncheck);
        return Task.FromResult(GenericResult<CompanyReportHelperKontrolRaporuResponse>.Success(
            new CompanyReportHelperKontrolRaporuResponse { Ncheck = ncheck }));
    }
}
