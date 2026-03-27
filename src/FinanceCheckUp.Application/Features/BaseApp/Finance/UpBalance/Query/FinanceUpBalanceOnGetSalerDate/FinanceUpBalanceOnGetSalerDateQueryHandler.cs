using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpBalance.Query.FinanceUpBalanceOnGetSalerDate;
public class FinanceUpBalanceOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpBalanceOnGetSalerDateQuery, GenericResult<FinanceUpBalanceOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceUpBalanceOnGetSalerDateResponse>> Handle(FinanceUpBalanceOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompany(request.InitialModel.curcomID);
 
                return Task.FromResult(GenericResult<FinanceUpBalanceOnGetSalerDateResponse>.Success(new FinanceUpBalanceOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        }));
    }
}
