using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashBilanco.Query.FinanceDashBilancoOnGetChartRasyo;
public class FinanceDashBilancoOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosu,
    IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<FinanceDashBilancoOnGetChartRasyoQuery, GenericResult<FinanceDashBilancoOnGetChartRasyoResponse>>
{
    public Task<GenericResult<FinanceDashBilancoOnGetChartRasyoResponse>> Handle(FinanceDashBilancoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosu.Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();
        request.InitialModel.ncart.SetResult(request.InitialModel.nRequestList, request.InitialModel.CurrentUser.SelectedYear);

                return Task.FromResult(GenericResult<FinanceDashBilancoOnGetChartRasyoResponse>.Success(new FinanceDashBilancoOnGetChartRasyoResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.ncart.nresult, request.Request.options),
            InitialModel = request.InitialModel,
        }));

    }
}
