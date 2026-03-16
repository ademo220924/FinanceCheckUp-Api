using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMain.Query.UploadMainOnGetSalerMainZeta
{
    public class MizanUploadMainOnGetSalerMainZetaQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager,
        IMainDashManager mainDashManager)
        : IRequestHandler<MizanUploadMainOnGetSalerMainZetaQuery, GenericResult<MizanUploadMainOnGetSalerMainZetaResponse>>
    {
        public Task<GenericResult<MizanUploadMainOnGetSalerMainZetaResponse>> Handle(MizanUploadMainOnGetSalerMainZetaQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;

            var mrequestDataViewer = new DataViewerMain();
            if (request.Request.monthid < 1)
            { 
                return Task.FromResult(GenericResult<MizanUploadMainOnGetSalerMainZetaResponse>.Success(new MizanUploadMainOnGetSalerMainZetaResponse
                {
                    InitialModel = request.InitialModel,
                    Response= new JsonResult(DataSourceLoader.Load(mrequestDataViewer.EntryData, request.Request.options))
                }));
            }


            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).FirstOrDefault(x => x.IsDefault == 1).Id;
            mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(
                request.InitialModel.CurrentUser.SelectedYear,
                request.InitialModel.curcomID, 
                request.Request.monthid));

            return Task.FromResult(GenericResult<MizanUploadMainOnGetSalerMainZetaResponse>.Success(new MizanUploadMainOnGetSalerMainZetaResponse
            {
                InitialModel = request.InitialModel,
                Response= new JsonResult(DataSourceLoader.Load(mrequestDataViewer.EntryData, request.Request.options))
            }));
             
        }
    }
}