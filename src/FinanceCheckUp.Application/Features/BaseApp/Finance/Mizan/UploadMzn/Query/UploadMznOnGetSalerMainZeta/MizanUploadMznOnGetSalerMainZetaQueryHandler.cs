using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMzn.Query.UploadMznOnGetSalerMainZeta
{
    public class MizanUploadMznOnGetSalerMainZetaQueryHandler(
        IMainDashManager mainDashManager,
        HhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager) : IRequestHandler<MizanUploadMznOnGetSalerMainZetaQuery, GenericResult<MizanUploadMznOnGetSalerMainZetaResponse>>
    {
      
        public Task<GenericResult<MizanUploadMznOnGetSalerMainZetaResponse>> Handle(MizanUploadMznOnGetSalerMainZetaQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
             
            request.InitialModel.mrequestDataViewer = new DataViewerMain();
            if (request.Request.monthid < 1)
            { 
                                return Task.FromResult(GenericResult<MizanUploadMznOnGetSalerMainZetaResponse>.Success(new MizanUploadMznOnGetSalerMainZetaResponse
                {
                    InitialModel = request.InitialModel,
                    Response= DataSourceLoader.Load( request.InitialModel.mrequestDataViewer.EntryData, request.Request.options)
                }));
            }
 
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;


            request.InitialModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth( request.InitialModel.CurrentUser.SelectedYear,  request.InitialModel.curcomID, request.Request.monthid));
                        return Task.FromResult(GenericResult<MizanUploadMznOnGetSalerMainZetaResponse>.Success(new MizanUploadMznOnGetSalerMainZetaResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load( request.InitialModel.mrequestDataViewer.EntryData, request.Request.options)
            }));
        }
    }
}
