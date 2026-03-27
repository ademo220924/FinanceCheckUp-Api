using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerMainZeta;
public class FinanceUploadMainOnGetSalerMainZetaQueryHandler(
    IMainDashManager mainDashManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUploadMainOnGetSalerMainZetaQuery, GenericResult<FinanceUploadMainOnGetSalerMainZetaResponse>>
{
    public Task<GenericResult<FinanceUploadMainOnGetSalerMainZetaResponse>> Handle(FinanceUploadMainOnGetSalerMainZetaQuery request, CancellationToken cancellationToken)
    {
        var mrequestDataViewer = new DataViewerMain();
        if (request.Request.monthid < 1)
        { 
                        return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerMainZetaResponse>.Success(new FinanceUploadMainOnGetSalerMainZetaResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(mrequestDataViewer.EntryData, request.Request.options)
            }));
        }

        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        mrequestDataViewer.SetDataViewer(mainDashManager.DataViewerMainMonth(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID, request.Request.monthid));
 
                return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerMainZetaResponse>.Success(new FinanceUploadMainOnGetSalerMainZetaResponse
        {
            InitialModel = request.InitialModel,
            Response =DataSourceLoader.Load(mrequestDataViewer.EntryData, request.Request.options)
        }));
    }
}
