using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upaccounty;
using FinanceCheckUp.Application.Models.Responses.upaccounty;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upaccounty.Query.upaccountyOnGetSalerDate;
public class upaccountyOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, IMainDashManager mainDashManager, ICompanyManager companyManager, IUploadMainManager uploadMainManager) : IRequestHandler<upaccountyOnGetSalerDateQuery, GenericResult<upaccountyOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upaccountyOnGetSalerDateResponse>> Handle(upaccountyOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upaccountyRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),

            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };
        List<int> chkErrormonthID = mainDashManager.Get_DatabyError(responseModel.CurrentUser.SelectedYear, responseModel.curcomID).Where(x => x.TErrorRowCount == 0).Select(x => x.MainMonth).ToList();
        var currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);

        currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c => { c.ErrorCount = -1; return c; }).OrderBy(x => x.MainMonth).ToList();
                return GenericResult<upaccountyOnGetSalerDateResponse>.Success(new upaccountyOnGetSalerDateResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(currentUploadM, request.Request.Options) });
    }
}