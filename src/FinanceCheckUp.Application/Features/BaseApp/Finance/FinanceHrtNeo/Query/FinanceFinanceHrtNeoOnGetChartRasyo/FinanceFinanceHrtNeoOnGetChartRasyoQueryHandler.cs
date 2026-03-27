using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGetChartRasyo;
public class FinanceFinanceHrtNeoOnGetChartRasyoQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companiesManager, 
    IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtNeoOnGetChartRasyoQuery, GenericResult<FinanceFinanceHrtNeoOnGetChartRasyoResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtNeoOnGetChartRasyoResponse>> Handle(FinanceFinanceHrtNeoOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companiesManager.Getby_User(userId).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();

                return Task.FromResult(GenericResult<FinanceFinanceHrtNeoOnGetChartRasyoResponse>.Success(new FinanceFinanceHrtNeoOnGetChartRasyoResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.nRequestList, request.Request.options)
        }));


    }
}
