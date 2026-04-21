using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporu;

public class CompanyReportHelperGetMizanRaporuQuery : IRequest<GenericResult<CompanyReportHelperMizanRaporuResponse>>
{
    public CompanyReportHelperMizanRaporuRequest Request { get; set; }
}
