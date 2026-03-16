using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetGetRep;
public class upreportqnbtestOnGetGetRepQueryHandler(ICompanyQnbReportManager companyQnbReportManager) : IRequestHandler<upreportqnbtestOnGetGetRepQuery, GenericResult<upreportqnbtestOnGetGetRepResponse>>
{

    public async Task<GenericResult<upreportqnbtestOnGetGetRepResponse>> Handle(upreportqnbtestOnGetGetRepQuery request, CancellationToken cancellationToken)
    {
        var NewRepName = companyQnbReportManager.Get_CompanyReport(request.Request.reportID).ReportName;
        var FileDocz = "/UploadFiles/Documents/" + NewRepName;
        return GenericResult<upreportqnbtestOnGetGetRepResponse>.Success(new upreportqnbtestOnGetGetRepResponse { Result = new JsonResult(FileDocz) });
    }
}