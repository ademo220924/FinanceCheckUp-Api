using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upcmconsole;
using FinanceCheckUp.Application.Models.Responses.upcmconsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.upcmconsole.Query.upcmconsoleOnGetSalerDate;
public class upcmconsoleOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager, IMainDashManager mainDashManager, IUploadMainManager uploadMainManager) : IRequestHandler<upcmconsoleOnGetSalerDateQuery, GenericResult<upcmconsoleOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upcmconsoleOnGetSalerDateResponse>> Handle(upcmconsoleOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upcmconsoleRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        List<int> chkErrormonthID = mainDashManager.DataViewerTaxError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => x.TRowCount == 0).Select(x => x.MainMonth).ToList();
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyConsole(responseModel.curcomID);
        return GenericResult<upcmconsoleOnGetSalerDateResponse>.Success(new upcmconsoleOnGetSalerDateResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options)) });
    }
}