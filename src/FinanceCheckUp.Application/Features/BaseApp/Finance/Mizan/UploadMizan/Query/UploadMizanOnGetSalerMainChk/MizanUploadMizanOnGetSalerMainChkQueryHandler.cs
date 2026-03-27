using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGetSalerMainChk
{
    public class MizanUploadMizanOnGetSalerMainChkQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager,
        IMainDashManager mainDashManager)
        : IRequestHandler<MizanUploadMizanOnGetSalerMainChkQuery, GenericResult<MizanUploadMizanOnGetSalerMainChkResponse>>
    {
        public Task<GenericResult<MizanUploadMizanOnGetSalerMainChkResponse>> Handle(
            MizanUploadMizanOnGetSalerMainChkQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = (int)userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);


            request.InitialModel.mrequestDataViewer = new DataViewerMain();
            if (request.Request.monthid < 1)
            {  
                                return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerMainChkResponse>.Success(new MizanUploadMizanOnGetSalerMainChkResponse
                {
                    InitialModel = request.InitialModel,
                    Response= DataSourceLoader.Load(request.InitialModel.mrequestDataViewer.EntryData, request.Request.options)
                }));
            }

            var curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

            request.InitialModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(request.InitialModel.CurrentUser.SelectedYear, curcomID, request.Request.monthid));
                        return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerMainChkResponse>.Success(new MizanUploadMizanOnGetSalerMainChkResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load(request.InitialModel.mrequestDataViewer.EntryData, request.Request.options)
            }));
        }
    }
}