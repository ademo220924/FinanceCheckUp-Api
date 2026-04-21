using FinanceCheckUp.Application.Models.Requests.Finance.Reports;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Reports.CompanyReportHelper.Query.GetMizanRaporuMizanAkt;

public class CompanyReportHelperGetMizanRaporuMizanAktQuery : IRequest<GenericResult<CompanyReportHelperMizanRaporuMizanAktResponse>>
{
    public CompanyReportHelperMizanRaporuMizanAktRequest Request { get; set; }
}
