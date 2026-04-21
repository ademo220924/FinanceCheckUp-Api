using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporuMizan;

public class CompanyReportHelperGetMizanRaporuMizanQuery : IRequest<GenericResult<CompanyReportHelperMizanRaporuMizanResponse>>
{
    public CompanyReportHelperMizanRaporuMizanRequest Request { get; set; }
}
