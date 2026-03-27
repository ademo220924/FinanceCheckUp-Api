using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upreportqnb;
using FinanceCheckUp.Application.Models.Responses.upreportqnb;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnb.Query.upreportqnbOnGetSalerDate;
public class upreportqnbOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<upreportqnbOnGetSalerDateQuery, GenericResult<upreportqnbOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upreportqnbOnGetSalerDateResponse>> Handle(upreportqnbOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upreportqnbRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyMainQNB(responseModel.curcomID);
                return GenericResult<upreportqnbOnGetSalerDateResponse>.Success(new upreportqnbOnGetSalerDateResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options) });
    }
}