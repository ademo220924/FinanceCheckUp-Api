using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMznOldYedek;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMznOldYedek.Query.UploadMznOldYedekOnGetSalerDate
{
    public class MizanUploadMznOldYedekOnGetSalerDateQueryHandler(
        IReportSetMainSqlOperationManager setMainSqlOperationManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager) : IRequestHandler<MizanUploadMznOldYedekOnGetSalerDateQuery, GenericResult<MizanUploadMznOldYedekOnGetSalerDateResponse>>
    {
        public Task<GenericResult<MizanUploadMznOldYedekOnGetSalerDateResponse>> Handle(MizanUploadMznOldYedekOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            var currentUploadM = setMainSqlOperationManager.Get_StatbyCompanyExcel(request.InitialModel.curcomID);

                        return Task.FromResult(GenericResult<MizanUploadMznOldYedekOnGetSalerDateResponse>.Success(new MizanUploadMznOldYedekOnGetSalerDateResponse
            {
                InitialModel = request.InitialModel,
                Response= DataSourceLoader.Load(currentUploadM.OrderBy(x => x.MainMonth).ToList(), request.Request.options)
            }));
        }
    }
}
