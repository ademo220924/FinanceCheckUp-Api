using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerDateMain;
public class FinanceUpPageAktarmaOnGetSalerDateMainQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IDashAktarmaSqlOperationManager dashAktarmaSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaOnGetSalerDateMainQuery, GenericResult<FinanceUpPageAktarmaOnGetSalerDateMainResponse>>
{

    public Task<GenericResult<FinanceUpPageAktarmaOnGetSalerDateMainResponse>> Handle(FinanceUpPageAktarmaOnGetSalerDateMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID); 
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        var currentUploadM1 = reportSetMainSqlOperationManager.Get_CompanyAktarmaResult(request.Request.nyear, request.InitialModel.curcomID);
        var currentUploadM = dashAktarmaSqlOperationManager.AddSMMM(currentUploadM1);
        var options = new DataSourceLoadOptions();
 
        
                  return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetSalerDateMainResponse>.Success(new FinanceUpPageAktarmaOnGetSalerDateMainResponse
                {
                    InitialModel = request.InitialModel,
                    Response = DataSourceLoader.Load(currentUploadM, options)
                }));
    }
}
