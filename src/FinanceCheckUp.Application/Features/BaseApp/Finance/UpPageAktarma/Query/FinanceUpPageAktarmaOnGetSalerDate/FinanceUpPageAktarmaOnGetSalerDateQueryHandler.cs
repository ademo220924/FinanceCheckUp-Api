using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarma.Query.FinanceUpPageAktarmaOnGetSalerDate;
public class FinanceUpPageAktarmaOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaOnGetSalerDateQuery, GenericResult<FinanceUpPageAktarmaOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaOnGetSalerDateResponse>> Handle(FinanceUpPageAktarmaOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;

        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyAktarma( request.InitialModel.curcomID);
        
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaOnGetSalerDateResponse>.Success(new FinanceUpPageAktarmaOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response = DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        }));
    }
}
