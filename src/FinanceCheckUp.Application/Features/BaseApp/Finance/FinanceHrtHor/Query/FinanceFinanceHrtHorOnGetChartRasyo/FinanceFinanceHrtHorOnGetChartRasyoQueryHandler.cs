using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.FinanceHrtHor;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtHor;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtHor.Query.FinanceFinanceHrtHorOnGetChartRasyo;
public class FinanceFinanceHrtHorOnGetChartRasyoQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtHorOnGetChartRasyoQuery, GenericResult<FinanceFinanceHrtHorOnGetChartRasyoResponse>>
{
    public FinanceFinanceHrtHorRequestInitialModel responseModel = new();

    public Task<GenericResult<FinanceFinanceHrtHorOnGetChartRasyoResponse>> Handle(FinanceFinanceHrtHorOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();

        return Task.FromResult(GenericResult<FinanceFinanceHrtHorOnGetChartRasyoResponse>.Success(new FinanceFinanceHrtHorOnGetChartRasyoResponse
        {
            Response = new JsonResult(DataSourceLoader.Load(request.InitialModel.nRequestList, request.Request.options))
        }));

    }
}
