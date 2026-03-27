using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.Upload;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetSalerMainZeta;
public class UploadOnGetSalerMainZetaQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager) : IRequestHandler<UploadOnGetSalerMainZetaQuery, GenericResult<UploadOnGetSalerMainZetaResponse>>
{
    public async Task<GenericResult<UploadOnGetSalerMainZetaResponse>> Handle(UploadOnGetSalerMainZetaQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new UploadRequest
        {
            mrequestDataViewer = new DataViewerMain(),
            UserID = UserID
        };

        if (request.Request.monthid < 1)
                        return GenericResult<UploadOnGetSalerMainZetaResponse>.Success(new UploadOnGetSalerMainZetaResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options) });

        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);
        responseModel.curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(responseModel.CurrentUser.SelectedYear, responseModel.curcomID, request.Request.monthid));
                return GenericResult<UploadOnGetSalerMainZetaResponse>.Success(new UploadOnGetSalerMainZetaResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(responseModel.mrequestDataViewer.EntryData, request.Request.Options) });
    }
}