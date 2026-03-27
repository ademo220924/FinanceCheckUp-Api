using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Jrnl.UpPageAktarmaMizan;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using System.Security.Claims;
using MediatR;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Jrnl.UpPageAktarmaMizan.Query.UpPageAktarmaMizanOnGetSalerDate;
public class MizanUpPageAktarmaMizanOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanUpPageAktarmaMizanOnGetSalerDateQuery, GenericResult<MizanUpPageAktarmaMizanOnGetSalerDateResponse>>
{
    public MizanUpPageAktarmaMizanRequestInitialModel responseModel = new();

    public Task<GenericResult<MizanUpPageAktarmaMizanOnGetSalerDateResponse>> Handle(MizanUpPageAktarmaMizanOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt32(request.UserId);
 
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companiesManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyAktarma(request.InitialModel.curcomID);
        
                return Task.FromResult(GenericResult<MizanUpPageAktarmaMizanOnGetSalerDateResponse>.Success(
            new MizanUpPageAktarmaMizanOnGetSalerDateResponse
            { 
                InitialModel =request.InitialModel,
                Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
            }));
    }
}
