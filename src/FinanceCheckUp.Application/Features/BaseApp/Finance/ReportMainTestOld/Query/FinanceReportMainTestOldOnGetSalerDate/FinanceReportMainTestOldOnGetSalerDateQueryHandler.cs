using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMainTestOld;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMainTestOld.Query.FinanceReportMainTestOldOnGetSalerDate;
public class FinanceReportMainTestOldOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceReportMainTestOldOnGetSalerDateQuery, GenericResult<FinanceReportMainTestOldOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceReportMainTestOldOnGetSalerDateResponse>> Handle(FinanceReportMainTestOldOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyMain(request.InitialModel.curcomID);
 
                return Task.FromResult(GenericResult<FinanceReportMainTestOldOnGetSalerDateResponse>.Success(new FinanceReportMainTestOldOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        }));
    }
}
