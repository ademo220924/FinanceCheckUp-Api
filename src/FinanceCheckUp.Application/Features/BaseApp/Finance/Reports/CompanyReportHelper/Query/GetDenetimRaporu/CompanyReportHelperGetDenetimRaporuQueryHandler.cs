using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetDenetimRaporu;

public class CompanyReportHelperGetDenetimRaporuQueryHandler(ICompanyReportManager companyReportManager)
    : IRequestHandler<CompanyReportHelperGetDenetimRaporuQuery, GenericResult<CompanyReportHelperDenetimRaporuResponse>>
{
    public Task<GenericResult<CompanyReportHelperDenetimRaporuResponse>> Handle(
        CompanyReportHelperGetDenetimRaporuQuery request,
        CancellationToken cancellationToken)
    {
        var ncheck = companyReportManager.BuildKontrolDenetimNcheckList(request.Request.Ncheck);
        return Task.FromResult(GenericResult<CompanyReportHelperDenetimRaporuResponse>.Success(
            new CompanyReportHelperDenetimRaporuResponse { Ncheck = ncheck }));
    }
}
