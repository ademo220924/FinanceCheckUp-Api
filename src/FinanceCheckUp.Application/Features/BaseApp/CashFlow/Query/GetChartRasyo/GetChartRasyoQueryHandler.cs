using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.CashFlow.Query.GetChartRasyo
{
    public class GetChartRasyoQueryHandle(
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companiesManager,
        IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<GetChartRasyoQuery, GenericResult<GetChartRasyoResponseModel>>
    {
        public async Task<GenericResult<GetChartRasyoResponseModel>> Handle(GetChartRasyoQuery request, CancellationToken cancellationToken)
        {
           
            var UserID = int.Parse(request.UserId);
            var CurrentUser = hhvnUsersManager.GetRow_User(UserID);

            var CompID = companiesManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault()!.Id;
            var nRequestList = dashGelirTablosuManager.Get_MAINRESULT(CurrentUser.SelectedYear, CompID).Where(x => x.IsHidden == 0).ToList();

            var ncart = new DashYearlyBilancoChart();
            ncart.SetResult(nRequestList, CurrentUser.SelectedYear);

            return GenericResult<GetChartRasyoResponseModel>.Success(new GetChartRasyoResponseModel { Response = new JsonResult(DataSourceLoader.Load(ncart.nresult, request.RequestModel.DataSourceLoadOptions)) });

        }
    }
}
