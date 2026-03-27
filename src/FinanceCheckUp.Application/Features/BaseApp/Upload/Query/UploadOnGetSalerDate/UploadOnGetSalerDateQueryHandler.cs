using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Upload;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetSalerDate;
public class UploadOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IMainDashManager mainDashManager, IUploadMainManager uploadMainManager) : IRequestHandler<UploadOnGetSalerDateQuery, GenericResult<UploadOnGetSalerDateResponse>>
{

    public async Task<GenericResult<UploadOnGetSalerDateResponse>> Handle(UploadOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new UploadRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        List<int> chkErrormonthID = mainDashManager.DataViewerTaxError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => x.TRowCount == 0).Select(x => x.MainMonth).ToList();
        var currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);
        currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();


                return GenericResult<UploadOnGetSalerDateResponse>.Success(new UploadOnGetSalerDateResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options) });
    }
}