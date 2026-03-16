using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtView.Query.FinanceHrtViewOnGetRevenue;
public class MizanFinanceHrtViewOnGetRevenueQueryHandler(IReportDashManager reportDashManger,IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<MizanFinanceHrtViewOnGetRevenueQuery, GenericResult<MizanFinanceHrtViewOnGetRevenueResponse>>
{
 

    public Task<GenericResult<MizanFinanceHrtViewOnGetRevenueResponse>> Handle(MizanFinanceHrtViewOnGetRevenueQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);


        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
            return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetRevenueResponse>.Success(
                new MizanFinanceHrtViewOnGetRevenueResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
                })); 
        }

        var retval = reportDashManger.Get_Data_RevenueMizan(request.Request.compid).Where(x => x.Amount > 5).OrderBy(x => x.Year);
         
        return Task.FromResult(GenericResult<MizanFinanceHrtViewOnGetRevenueResponse>.Success(
            new MizanFinanceHrtViewOnGetRevenueResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options))
            })); 
    }
}
