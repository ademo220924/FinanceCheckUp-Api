using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerComp;
public class upcmconsoleOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upcmconsoleOnGetSalerCompQuery, GenericResult<upcmconsoleOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upcmconsoleOnGetSalerCompResponse>> Handle(upcmconsoleOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
        return GenericResult<upcmconsoleOnGetSalerCompResponse>.Success(new upcmconsoleOnGetSalerCompResponse { Result = new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.Options)) });
    }
}