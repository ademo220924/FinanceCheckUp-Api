using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.upaccounty;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;




namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerMainChk;
public class upaccountyOnGetSalerMainChkQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager) : IRequestHandler<upaccountyOnGetSalerMainChkQuery, GenericResult<upaccountyOnGetSalerMainChkResponse>>
{

    public async Task<GenericResult<upaccountyOnGetSalerMainChkResponse>> Handle(upaccountyOnGetSalerMainChkQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upaccountyRequest();


        responseModel.mrequestDataViewer = new DataViewerMain();

        if (request.Request.monthid < 1)
            return GenericResult<upaccountyOnGetSalerMainChkResponse>.Success(new upaccountyOnGetSalerMainChkResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options)) });


        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(responseModel.CurrentUser.SelectedYear, responseModel.curcomID, request.Request.monthid));

        return GenericResult<upaccountyOnGetSalerMainChkResponse>.Success(new upaccountyOnGetSalerMainChkResponse { InitialModel = responseModel, Result = new JsonResult(DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options)) });
    }
}