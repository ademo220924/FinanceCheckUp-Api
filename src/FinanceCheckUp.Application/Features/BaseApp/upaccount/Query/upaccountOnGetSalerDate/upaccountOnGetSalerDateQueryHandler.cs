using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upaccount;
using FinanceCheckUp.Application.Models.Responses.upaccount;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upaccount.Query.upaccountOnGetSalerDate;
public class upaccountOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager, IUploadMainManager uploadMainManager) : IRequestHandler<upaccountOnGetSalerDateQuery, GenericResult<upaccountOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upaccountOnGetSalerDateResponse>> Handle(upaccountOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upaccountRequest();
        responseModel.UserID = UserID;
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(UserID);

        responseModel.curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        List<int> chkErrormonthID = mainDashManager.Get_DatabyError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => x.TErrorRowCount == 0).Select(x => x.MainMonth).ToList();
        var currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);

        currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
                return GenericResult<upaccountOnGetSalerDateResponse>.Success(new upaccountOnGetSalerDateResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(currentUploadM, request.Request.Options) });

    }
}