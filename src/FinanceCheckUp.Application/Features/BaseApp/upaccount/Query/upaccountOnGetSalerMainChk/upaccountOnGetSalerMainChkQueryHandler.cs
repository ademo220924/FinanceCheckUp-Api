using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerMainChk;
public class upaccountOnGetSalerMainChkQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager) : IRequestHandler<upaccountOnGetSalerMainChkQuery, GenericResult<upaccountOnGetSalerMainChkResponse>>
{

    public async Task<GenericResult<upaccountOnGetSalerMainChkResponse>> Handle(upaccountOnGetSalerMainChkQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upaccountRequest();

        responseModel.mrequestDataViewer = new DataViewerMain();
        if (request.Request.monthid < 1)
            return GenericResult<upaccountOnGetSalerMainChkResponse>.Success(new upaccountOnGetSalerMainChkResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options)) });

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(responseModel.CurrentUser.SelectedYear, responseModel.curcomID, request.Request.monthid));

        return GenericResult<upaccountOnGetSalerMainChkResponse>.Success(new upaccountOnGetSalerMainChkResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options)) });
    }
}