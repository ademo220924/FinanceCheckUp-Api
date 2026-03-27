using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.UpPageAktarmaJrnl;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.UpPageAktarmaJrnl.Query.FinanceUpPageAktarmaJrnlOnGetSalerDate;
public class FinanceUpPageAktarmaJrnlOnGetSalerDateQueryHandler(
    IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
    IHhvnUsersManager hhvnUsersManager,
    ICompanyManager companyManager) : IRequestHandler<FinanceUpPageAktarmaJrnlOnGetSalerDateQuery, GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateResponse>>
{
    public Task<GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateResponse>> Handle(FinanceUpPageAktarmaJrnlOnGetSalerDateQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
        request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        var currentUploadM = reportSetMainSqlOperationManager.Get_StatbyCompanyAktarma(request.InitialModel.curcomID);
  
                return Task.FromResult(GenericResult<FinanceUpPageAktarmaJrnlOnGetSalerDateResponse>.Success(new FinanceUpPageAktarmaJrnlOnGetSalerDateResponse
        {
            InitialModel = request.InitialModel,
            Response =  DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
        }));
    }
}
