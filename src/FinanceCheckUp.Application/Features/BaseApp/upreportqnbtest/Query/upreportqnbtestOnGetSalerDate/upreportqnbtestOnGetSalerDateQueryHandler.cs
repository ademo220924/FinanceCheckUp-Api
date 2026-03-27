using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.upreportqnbtest;
using FinanceCheckUp.Application.Models.Responses.upreportqnbtest;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.upreportqnbtest.Query.upreportqnbtestOnGetSalerDate;
public class upreportqnbtestOnGetSalerDateQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager, IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<upreportqnbtestOnGetSalerDateQuery, GenericResult<upreportqnbtestOnGetSalerDateResponse>>
{

    public async Task<GenericResult<upreportqnbtestOnGetSalerDateResponse>> Handle(upreportqnbtestOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {

        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new upreportqnbtestRequest
        {
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyMainQNB(responseModel.curcomID);
                return GenericResult<upreportqnbtestOnGetSalerDateResponse>.Success(new upreportqnbtestOnGetSalerDateResponse { InitialModel = responseModel, Result = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.Options) });
    }
}