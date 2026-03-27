using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGetSalerDateMain;
public class MizanUpPageAktarmaMizanOnGetSalerDateMainQueryHandler(IHhvnUsersManager hhvnUsersManager,
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IDashAktarmaSqlOperationManager dashAktarmaSqlOperationManager,
    ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaMizanOnGetSalerDateMainQuery, GenericResult<MizanUpPageAktarmaMizanOnGetSalerDateMainResponse>>
{

    public Task<GenericResult<MizanUpPageAktarmaMizanOnGetSalerDateMainResponse>> Handle(MizanUpPageAktarmaMizanOnGetSalerDateMainQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        var currentUploadM1 = reportSetMainSqlOperationManager.Get_CompanyAktarmaResult( request.Request.nyear,  request.InitialModel.curcomID);
        var currentUploadM = dashAktarmaSqlOperationManager.AddSMMM(currentUploadM1);
        var options = new DataSourceLoadOptions();

      
        
                return Task.FromResult(GenericResult<MizanUpPageAktarmaMizanOnGetSalerDateMainResponse>.Success(
            new MizanUpPageAktarmaMizanOnGetSalerDateMainResponse
            { 
                InitialModel =request.InitialModel,
                Response = DataSourceLoader.Load(currentUploadM, options)
            }));
    }
}
