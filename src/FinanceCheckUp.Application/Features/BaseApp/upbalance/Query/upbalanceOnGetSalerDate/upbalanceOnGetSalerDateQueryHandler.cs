using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upbalance;
using FinanceCheckUp.Application.Models.Responses.upbalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upbalance.Query.upbalanceOnGetSalerDate;
public class upbalanceOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<upbalanceOnGetSalerDateQuery, GenericResult<upbalanceOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upbalanceOnGetSalerDateResponse>> Handle(upbalanceOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {


        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upbalanceRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompany(responseModel.curcomID);
        return GenericResult<upbalanceOnGetSalerDateResponse>.Success(new upbalanceOnGetSalerDateResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options)) });
    }
}