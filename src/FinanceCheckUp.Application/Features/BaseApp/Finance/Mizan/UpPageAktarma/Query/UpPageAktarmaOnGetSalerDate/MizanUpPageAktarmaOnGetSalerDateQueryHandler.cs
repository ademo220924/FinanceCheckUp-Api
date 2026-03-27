using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UpPageAktarma;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UpPageAktarma.Query.UpPageAktarmaOnGetSalerDate
{
    public class MizanUpPageAktarmaOnGetSalerDateQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager) : IRequestHandler<MizanUpPageAktarmaOnGetSalerDateQuery, GenericResult<MizanUpPageAktarmaOnGetSalerDateResponse>>
    {
        public Task<GenericResult<MizanUpPageAktarmaOnGetSalerDateResponse>> Handle(MizanUpPageAktarmaOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            var currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyAktarmaMZN(request.InitialModel.curcomID);
 
                        return Task.FromResult(GenericResult<MizanUpPageAktarmaOnGetSalerDateResponse>.Success(new MizanUpPageAktarmaOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
            }));
        }
    }
}
