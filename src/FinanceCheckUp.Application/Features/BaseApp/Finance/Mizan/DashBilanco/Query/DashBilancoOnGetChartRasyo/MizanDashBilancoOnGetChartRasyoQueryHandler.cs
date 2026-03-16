using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilanco.Query.DashBilancoOnGetChartRasyo
{
    public class MizanDashBilancoOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) 
        : IRequestHandler<MizanDashBilancoOnGetChartRasyoQuery, GenericResult<MizanDashBilancoOnGetChartRasyoResponse>>
    {
        public Task<GenericResult<MizanDashBilancoOnGetChartRasyoResponse>> Handle(MizanDashBilancoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);

            request.InitialModel.CompID = companyManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            var nRequestList = dashGelirTablosuManager.Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID ).Where(x => x.IsHidden == 0).ToList();
             
            var ncart = new DashYearlyBilancoChart();
            ncart.SetResult(nRequestList, request.InitialModel.CurrentUser.SelectedYear);
 
            return Task.FromResult(GenericResult<MizanDashBilancoOnGetChartRasyoResponse>.Success(
                new MizanDashBilancoOnGetChartRasyoResponse
                {
                    InitialModel = request.InitialModel,
                    Response = new JsonResult(DataSourceLoader.Load(ncart.nresult, request.Request.options))
                }));
        }
    }
}
