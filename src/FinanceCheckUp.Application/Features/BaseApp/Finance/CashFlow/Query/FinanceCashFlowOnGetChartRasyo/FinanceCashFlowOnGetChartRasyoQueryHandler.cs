using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.CashFlow;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.CashFlow.Query.FinanceCashFlowOnGetChartRasyo;
public class FinanceCashFlowOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosu,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager) : IRequestHandler<FinanceCashFlowOnGetChartRasyoQuery, GenericResult<FinanceCashFlowOnGetChartRasyoResponse>>
{
    public Task<GenericResult<FinanceCashFlowOnGetChartRasyoResponse>> Handle(FinanceCashFlowOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosu.Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();
        request.InitialModel.ncart.SetResult(request.InitialModel.nRequestList, request.InitialModel.CurrentUser.SelectedYear);

        return Task.FromResult(GenericResult<FinanceCashFlowOnGetChartRasyoResponse>.Success(new FinanceCashFlowOnGetChartRasyoResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.ncart.nresult, request.Request.options)),
            InitialModel = request.InitialModel
        }));

    }
}