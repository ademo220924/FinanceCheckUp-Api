using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzan.Query.UploadMzanOnGetSalerMainChk
{
    public class MizanUploadMzanOnGetSalerMainChkQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        IMainDashManager mainDashManager,
        ICompanyManager companyManager)
        : IRequestHandler<MizanUploadMzanOnGetSalerMainChkQuery, GenericResult<MizanUploadMzanOnGetSalerMainChkResponse>>
    {
        public Task<GenericResult<MizanUploadMzanOnGetSalerMainChkResponse>> Handle(MizanUploadMzanOnGetSalerMainChkQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            
            var mrequestDataViewer = new DataViewerMain();
            if (request.Request.monthid < 1)
            {
                return Task.FromResult(GenericResult<MizanUploadMzanOnGetSalerMainChkResponse>.Success(
                    new MizanUploadMzanOnGetSalerMainChkResponse
                    {
                        InitialModel = request.InitialModel,
                        Response = new JsonResult(DataSourceLoader.Load(mrequestDataViewer.EntryData,
                            request.Request.options))
                    }));
            }

            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

            mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID, request.Request.monthid));

            return Task.FromResult(GenericResult<MizanUploadMzanOnGetSalerMainChkResponse>.Success(
                new MizanUploadMzanOnGetSalerMainChkResponse
                {
                    InitialModel = request.InitialModel,
                    Response = new JsonResult(DataSourceLoader.Load(mrequestDataViewer.EntryData,
                        request.Request.options))
                }));
        }
    }
}