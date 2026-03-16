using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaMzn;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaMzn.Query.FinanceUpPageAktarmaMznOnGetSalerDateMain;
public class FinanceUpPageAktarmaMznOnGetSalerDateMainQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IDashAktarmaSqlOperationManager dashAktarmaSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaMznOnGetSalerDateMainQuery, GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateMainResponse>>
{

    public Task<GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateMainResponse>> Handle(FinanceUpPageAktarmaMznOnGetSalerDateMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM1 = reportSetMainSqlOperationManager.Get_CompanyAktarmaResult(request.Request.nyear, request.InitialModel.curcomID);
        var currentUploadM = dashAktarmaSqlOperationManager.AddSMMM(currentUploadM1);
        
        return Task.FromResult(GenericResult<FinanceUpPageAktarmaMznOnGetSalerDateMainResponse>.Success(new FinanceUpPageAktarmaMznOnGetSalerDateMainResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult(DataSourceLoader.Load(currentUploadM, new DataSourceLoadOptions()))
        }));
    }
}
