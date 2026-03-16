using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upchecky;
using FinanceCheckUp.Application.Models.Responses.upchecky;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upchecky.Query.upcheckyOnGetSalerDate;
public class upcheckyOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager, IMainDashManager mainDashManager, IUploadMainManager uploadMainManager) : IRequestHandler<upcheckyOnGetSalerDateQuery, GenericResult<upcheckyOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upcheckyOnGetSalerDateResponse>> Handle(upcheckyOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upcheckyRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        List<int> chkErrormonthID = mainDashManager.DataViewerTaxError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => x.TRowCount == 0).Select(x => x.MainMonth).ToList();
        var currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);
        currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();


        return GenericResult<upcheckyOnGetSalerDateResponse>.Success(new upcheckyOnGetSalerDateResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options)) });
    }
}