using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetGrossProfit;
public class FinanceFinanceHrtViewOnGetGrossProfitQueryHandler(
    IHhvnUsersManager hhvnUsersManager, 
    IReportDashManager reportDashManager) : IRequestHandler<FinanceFinanceHrtViewOnGetGrossProfitQuery, GenericResult<FinanceFinanceHrtViewOnGetGrossProfitResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetGrossProfitResponse>> Handle(FinanceFinanceHrtViewOnGetGrossProfitQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (hhvnUsersManager.CheckUser(request.InitialModel.CompID, (int)userId))
        {
            var retval = reportDashManager.Get_Data_GrossProfit(request.Request.myear, request.InitialModel.CompID);

                        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetGrossProfitResponse>.Success(new FinanceFinanceHrtViewOnGetGrossProfitResponse
            {
                Response = DataSourceLoader.Load(retval, request.Request.options)
            }));

        }

                return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetGrossProfitResponse>.Success(new FinanceFinanceHrtViewOnGetGrossProfitResponse
        {
            Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
        }));

    }
}
