using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetGetRep;
public class upreportqnbOnGetGetRepQueryHandler(ICompanyQnbReportManager companyQnbReportManager) : IRequestHandler<upreportqnbOnGetGetRepQuery, GenericResult<upreportqnbOnGetGetRepResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetGetRepResponse>> Handle(upreportqnbOnGetGetRepQuery request, CancellationToken cancellationToken)
    {
        var NewRepName = companyQnbReportManager.Get_CompanyReport(request.Request.reportID).ReportName;
        var FileDocz = "/UploadFiles/Documents/" + NewRepName;
        return GenericResult<upreportqnbOnGetGetRepResponse>.Success(new upreportqnbOnGetGetRepResponse { Result = new JsonResult(FileDocz) });

    }
}