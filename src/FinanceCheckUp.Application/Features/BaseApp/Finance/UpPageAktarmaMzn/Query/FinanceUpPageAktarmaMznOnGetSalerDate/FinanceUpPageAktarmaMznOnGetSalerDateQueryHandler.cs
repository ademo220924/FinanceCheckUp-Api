using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGetSalerDate;
public class FinanceUpPageAktarmaMznOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaMznOnGetSalerDateQuery, GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateResponse>> Handle(FinanceUpPageAktarmaMznOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyAktarma(request.InitialModel.curcomID);
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateResponse>.Success(new FinanceUpPageAktarmaMznOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        }));
    }
}
