using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upreportmainy;
using FinanceCheckUp.Application.Models.Responses.upreportmainy;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upreportmainy.Query.upreportmainyOnGetSalerDate;
public class upreportmainyOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager, IMainDashManager mainDashManager, IUploadMainManager uploadMainManager) : IRequestHandler<upreportmainyOnGetSalerDateQuery, GenericResult<upreportmainyOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upreportmainyOnGetSalerDateResponse>> Handle(upreportmainyOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upreportmainyRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        var currentUploadM = uploadMainManager.Get_Data(responseModel.CurrentUser.SelectedYear, responseModel.curcomID);
                return GenericResult<upreportmainyOnGetSalerDateResponse>.Success(new upreportmainyOnGetSalerDateResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options) });
    }
}