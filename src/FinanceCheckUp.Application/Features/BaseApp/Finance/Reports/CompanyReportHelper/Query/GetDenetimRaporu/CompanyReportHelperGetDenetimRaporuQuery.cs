using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetDenetimRaporu;

public class CompanyReportHelperGetDenetimRaporuQuery : IRequest<GenericResult<CompanyReportHelperDenetimRaporuResponse>>
{
    public CompanyReportHelperDenetimRaporuRequest Request { get; set; }
}
