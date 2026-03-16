using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerComp;
public class upaccountOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upaccountOnGetSalerCompQuery, GenericResult<upaccountOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upaccountOnGetSalerCompResponse>> Handle(upaccountOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
        return GenericResult<upaccountOnGetSalerCompResponse>.Success(new upaccountOnGetSalerCompResponse { Result = new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.Options)) });
    }
}