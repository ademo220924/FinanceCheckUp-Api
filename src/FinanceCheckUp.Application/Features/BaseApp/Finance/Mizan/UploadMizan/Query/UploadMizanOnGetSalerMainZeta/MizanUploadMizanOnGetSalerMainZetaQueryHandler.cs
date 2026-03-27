using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGetSalerMainZeta
{
    public class MizanUploadMizanOnGetSalerMainZetaQueryHandler(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager,
        IMainDashManager mainDashManager) : IRequestHandler<MizanUploadMizanOnGetSalerMainZetaQuery, GenericResult<MizanUploadMizanOnGetSalerMainZetaResponse>>
    {
      
        public Task<GenericResult<MizanUploadMizanOnGetSalerMainZetaResponse>> Handle(MizanUploadMizanOnGetSalerMainZetaQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = (int)userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            
            var mrequestDataViewer = new DataViewerMain();
            if (request.Request.monthid < 1)
            {
                                return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerMainZetaResponse>.Success(new MizanUploadMizanOnGetSalerMainZetaResponse
                {
                    InitialModel = request.InitialModel,
                    Response= DataSourceLoader.Load(mrequestDataViewer.EntryData, request.Request.options)
                }));
            }

            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID, request.Request.monthid));
           
                        return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerMainZetaResponse>.Success(new MizanUploadMizanOnGetSalerMainZetaResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load(mrequestDataViewer.EntryData, request.Request.options)
            }));
        }
    }
}
