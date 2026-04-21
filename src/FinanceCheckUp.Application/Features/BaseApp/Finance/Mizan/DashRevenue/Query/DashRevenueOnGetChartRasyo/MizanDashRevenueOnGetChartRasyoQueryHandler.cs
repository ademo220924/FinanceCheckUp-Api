using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.DashRevenue;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGetChartRasyo;
public class MizanDashRevenueOnGetChartRasyoQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanDashRevenueOnGetChartRasyoQuery, GenericResult<MizanDashRevenueOnGetChartRasyoResponse>>
{
  
    public Task<GenericResult<MizanDashRevenueOnGetChartRasyoResponse>> Handle(MizanDashRevenueOnGetChartRasyoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        request.InitialModel.UserID = userId;
        request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        request.InitialModel.CompID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
        request.InitialModel.nRequestList = dashGelirTablosuManager.Get_MAINRESULTMultiMain(request.InitialModel.CompID).Where(x => x.IsHidden == 0).ToList();
        request.InitialModel.ncart = new DashYearlyBilancoChart();

        var data = new MizanDashRevenueOnGetChartRasyoResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.nRequestList, request.Request.options),
            InitialModel = request.InitialModel
        };
        return Task.FromResult(GenericResult<MizanDashRevenueOnGetChartRasyoResponse>.Success(
            data));
    }
}

