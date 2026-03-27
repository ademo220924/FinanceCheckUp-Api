using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpBalance;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpBalance.Query.UpBalanceOnGetSalerDate
{
    public class MizanUpBalanceOnGetSalerDateQueryHandler(
        IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager) : IRequestHandler<MizanUpBalanceOnGetSalerDateQuery, GenericResult<MizanUpBalanceOnGetSalerDateResponse>>
    {
        
        public Task<GenericResult<MizanUpBalanceOnGetSalerDateResponse>> Handle(MizanUpBalanceOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId); 
            request.InitialModel.UserID = userId; 
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId); 
            request.InitialModel.curcomID = companyManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

            var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyExcel( request.InitialModel.curcomID);

                        return Task.FromResult(GenericResult<MizanUpBalanceOnGetSalerDateResponse>.Success(new MizanUpBalanceOnGetSalerDateResponse
            {
                Response = DataSourceLoader.Load(currentUploadM.OrderByDescending(x => x.MainYear).ToList(), request.Request.options),
                InitialModel = request.InitialModel
            }));
        }
    }
}
