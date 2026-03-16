using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetWorkingCapital;
public class MizanFinanceHrtViewOnGetWorkingCapitalQueryHandler(IReportDashManager reportDashManager,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetWorkingCapitalQuery, GenericResult<MizanFinanceHrtViewOnGetWorkingCapitalResponse>>
{
    public Task<GenericResult<MizanFinanceHrtViewOnGetWorkingCapitalResponse>> Handle(MizanFinanceHrtViewOnGetWorkingCapitalQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetWorkingCapitalResponse>.Success(
                new MizanFinanceHrtViewOnGetWorkingCapitalResponse
                {
                    Response = new  JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
                })); 
        }


        var chk = reportDashManager.Get_Data_WorkingCapital(request.Request.myear, request.Request.compid);
         var dashWorkingCapital = DashYearlyResultChart.SetResultMain(chk, request.Request.myear);
 
        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetWorkingCapitalResponse>.Success(
            new MizanFinanceHrtViewOnGetWorkingCapitalResponse
            {
                Response = new  JsonResult(DataSourceLoader.Load(dashWorkingCapital, request.Request.options))
            })); 
    }
}
