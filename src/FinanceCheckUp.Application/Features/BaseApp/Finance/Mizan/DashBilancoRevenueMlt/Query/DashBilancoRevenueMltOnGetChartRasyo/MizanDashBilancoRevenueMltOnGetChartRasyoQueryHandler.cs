using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashBilancoRevenueMlt;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashBilancoRevenueMlt.Query.DashBilancoRevenueMltOnGetChartRasyo;

public class MizanDashBilancoRevenueMltOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) 
    : IRequestHandler<MizanDashBilancoRevenueMltOnGetChartRasyoQuery, GenericResult<MizanDashBilancoRevenueMltOnGetChartRasyoResponse>>
{
    
    public Task<GenericResult<MizanDashBilancoRevenueMltOnGetChartRasyoResponse>> Handle(MizanDashBilancoRevenueMltOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.UserID = userId;
         request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);
         request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
         request.InitialModel.nRequestList = dashGelirTablosuManager
             .Get_MAINRESULT(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.CompID)
             .Where(x => x.IsHidden == 0)
             .ToList();
        var ncart = new DashYearlyBilancoChart();
        ncart.SetResult(request.InitialModel.nRequestList, request.InitialModel.CurrentUser.SelectedYear);
       
                return Task.FromResult(GenericResult<MizanDashBilancoRevenueMltOnGetChartRasyoResponse>.Success(
            new MizanDashBilancoRevenueMltOnGetChartRasyoResponse
            {
                InitialModel = request.InitialModel,
                Response = DataSourceLoader.Load(ncart.nresult, request.Request.options)
            }));
    }
}
