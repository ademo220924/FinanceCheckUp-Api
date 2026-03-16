using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetSalerComp;
public class upbalanceyOnGetSalerCompQueryHandler(ICompanyManager companyManager) : IRequestHandler<upbalanceyOnGetSalerCompQuery, GenericResult<upbalanceyOnGetSalerCompResponse>>
{

    public async Task<GenericResult<upbalanceyOnGetSalerCompResponse>> Handle(upbalanceyOnGetSalerCompQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var mreqListCompany = companyManager.Getby_User(UserID);
        return GenericResult<upbalanceyOnGetSalerCompResponse>.Success(new upbalanceyOnGetSalerCompResponse { Result = new JsonResult(DataSourceLoader.Load(mreqListCompany, request.Request.Options)) });
    }
}