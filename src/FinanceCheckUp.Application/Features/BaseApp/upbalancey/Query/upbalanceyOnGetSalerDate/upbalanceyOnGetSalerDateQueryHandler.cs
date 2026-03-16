using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upbalancey;
using FinanceCheckUp.Application.Models.Responses.upbalancey;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalancey.Query.upbalanceyOnGetSalerDate;
public class upbalanceyOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<upbalanceyOnGetSalerDateQuery, GenericResult<upbalanceyOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upbalanceyOnGetSalerDateResponse>> Handle(upbalanceyOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upbalanceyRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        responseModel.curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompany(responseModel.curcomID);

        return GenericResult<upbalanceyOnGetSalerDateResponse>.Success(new upbalanceyOnGetSalerDateResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options)) });
    }
}