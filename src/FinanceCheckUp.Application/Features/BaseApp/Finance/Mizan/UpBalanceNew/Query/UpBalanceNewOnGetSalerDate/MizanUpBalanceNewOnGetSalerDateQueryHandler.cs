using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalanceNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalanceNew.Query.UpBalanceNewOnGetSalerDate;
public class MizanUpBalanceNewOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager setMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<MizanUpBalanceNewOnGetSalerDateQuery, GenericResult<MizanUpBalanceNewOnGetSalerDateResponse>>
{

    public Task<GenericResult<MizanUpBalanceNewOnGetSalerDateResponse>> Handle(MizanUpBalanceNewOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = setMainSqlOperationManager.Get_StatbyCompany(request.InitialModel.curcomID);

        return Task.FromResult(GenericResult<MizanUpBalanceNewOnGetSalerDateResponse>.Success(new MizanUpBalanceNewOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response= DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        })); 
    }
}
