using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTest.Query.FinanceReportMainTestOnGetCheckUrl;
public class FinanceReportMainTestOnGetCheckUrlQueryHandler(
    ICompanyReportManager companyReportManager) : IRequestHandler<FinanceReportMainTestOnGetCheckUrlQuery, GenericResult<FinanceReportMainTestOnGetCheckUrlResponse>>
{

    public Task<GenericResult<FinanceReportMainTestOnGetCheckUrlResponse>> Handle(FinanceReportMainTestOnGetCheckUrlQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var nlist = companyReportManager.Get_CompanyReport(request.Request.fileID);
            var fileDocz = "FileContent/" + nlist.ReportName;
            return Task.FromResult(GenericResult<FinanceReportMainTestOnGetCheckUrlResponse>.Success(new FinanceReportMainTestOnGetCheckUrlResponse
            {
                Response =new JsonResult(fileDocz)
            }));
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<FinanceReportMainTestOnGetCheckUrlResponse>.Success(new FinanceReportMainTestOnGetCheckUrlResponse
            {
                Response =new JsonResult(ex.Message)
            }));
        }
    }
}
