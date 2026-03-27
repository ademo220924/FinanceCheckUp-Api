using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetChartRasyo
{
    public class FinanceDashRasyoOnGetChartRasyoQueryHandler(IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companiesManager, 
        IRasyoAnalizMainManager rasyoAnalizMainManager) : IRequestHandler<FinanceDashRasyoOnGetChartRasyoQuery, GenericResult<FinanceDashRasyoOnGetChartRasyoResponse>>
    {
        public Task<GenericResult<FinanceDashRasyoOnGetChartRasyoResponse>> Handle(FinanceDashRasyoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            var CurrentUser = hhvnUsersManager.GetRow_User(userId);
            var CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            var RasyoAnalizView = new DashYearlyResultChart();
            var RasyoAnaliz = rasyoAnalizMainManager.RasyoAnalizTOTALFinal(CurrentUser.SelectedYear, CompID);
            RasyoAnalizView.SetResult(RasyoAnaliz, CurrentUser.SelectedYear);

                        return Task.FromResult(GenericResult<FinanceDashRasyoOnGetChartRasyoResponse>.Success(new FinanceDashRasyoOnGetChartRasyoResponse
            {
                Response = DataSourceLoader.Load(RasyoAnalizView.nresult.Where(x => x.TypeID == 1), request.Request.options)
            }));

        }
    }
}
