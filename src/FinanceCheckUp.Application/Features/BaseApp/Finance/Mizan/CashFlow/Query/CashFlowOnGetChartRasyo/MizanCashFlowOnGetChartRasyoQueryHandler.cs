using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.CashFlow.Query.CashFlowOnGetChartRasyo;
public class MizanCashFlowOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanCashFlowOnGetChartRasyoQuery, GenericResult<MizanCashFlowOnGetChartRasyoResponse>>
{
    public Task<GenericResult<MizanCashFlowOnGetChartRasyoResponse>> Handle(MizanCashFlowOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new MizanCashFlowRequestInitialModel
        {
            UserID = userId,
            mreqListCompany = companyManager.Getby_User(userId)
        };
         
        responseModel. CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);

        responseModel.CompID = companyManager.Getby_User(responseModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        responseModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULT(responseModel.CurrentUser.SelectedYear, responseModel.CompID).Where(x => x.IsHidden == 0).ToList();
        //nRequestListTx = DashBilancoViewTx.setDashBilanco(nRequestList);

        var ncart = new DashYearlyBilancoChart();
        ncart.SetResult(responseModel.nRequestList, responseModel.CurrentUser.SelectedYear);

        return Task.FromResult(GenericResult<MizanCashFlowOnGetChartRasyoResponse>.Success(new MizanCashFlowOnGetChartRasyoResponse { InitialModel = responseModel }));
    }
}
