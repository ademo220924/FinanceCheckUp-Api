using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMainTestMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMainTestMizan.Query.ReportMainTestMizanOnGetCheckUrl;
public class MizanReportMainTestMizanOnGetCheckUrlQueryHandler(ICompanyReportManager companyReportManager) 
    : IRequestHandler<MizanReportMainTestMizanOnGetCheckUrlQuery, GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>>
{
    public Task<GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>> Handle(MizanReportMainTestMizanOnGetCheckUrlQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var nlist = companyReportManager.Get_CompanyReport(request.Request.fileID);
            var fileDocz = "FileContent/" + nlist.ReportName;
            return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>.Success(new MizanReportMainTestMizanOnGetCheckUrlResponse
            {
                Response = new JsonResult(fileDocz)
            }));
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MizanReportMainTestMizanOnGetCheckUrlResponse>.Fail(ex.ToString()));
        }
    }
}
