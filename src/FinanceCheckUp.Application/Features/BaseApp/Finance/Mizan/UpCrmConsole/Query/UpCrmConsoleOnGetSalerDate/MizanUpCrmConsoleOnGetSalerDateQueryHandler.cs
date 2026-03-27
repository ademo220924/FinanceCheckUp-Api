using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpCrmConsole;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpCrmConsole.Query.UpCrmConsoleOnGetSalerDate
{
    public class MizanUpCrmConsoleOnGetSalerDateQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager) : IRequestHandler<MizanUpCrmConsoleOnGetSalerDateQuery, GenericResult<MizanUpCrmConsoleOnGetSalerDateResponse>>
    {
 

        public Task<GenericResult<MizanUpCrmConsoleOnGetSalerDateResponse>> Handle(MizanUpCrmConsoleOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanUpCrmConsoleRequestInitialModel
            {  
                UserID = userId
            };
            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.curcomID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

            var currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyConsoleM(responseModel.curcomID);

                        return Task.FromResult(GenericResult<MizanUpCrmConsoleOnGetSalerDateResponse>.Success(new MizanUpCrmConsoleOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
            }));
        }
    }
}
