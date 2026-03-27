using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtView;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtView.Query.FinanceFinanceHrtViewOnGetMarkupMarjin;
public class FinanceFinanceHrtViewOnGetMarkupMarjinQueryHandler(
    IHhvnUsersManager hhvnUsersManager,  
    IReportDashManager reportDashManager) : IRequestHandler<FinanceFinanceHrtViewOnGetMarkupMarjinQuery, GenericResult<FinanceFinanceHrtViewOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtViewOnGetMarkupMarjinResponse>> Handle(FinanceFinanceHrtViewOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.InitialModel.CompID, (int)userId))
        {
                        return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetMarkupMarjinResponse>.Success(new FinanceFinanceHrtViewOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        }

        IEnumerable<YearlyReportDashGraphic> mrequestResult_1 = reportDashManager.Get_Data_GrossProfitGraphic(request.Request.myear, request.InitialModel.CompID);

                return Task.FromResult(GenericResult<FinanceFinanceHrtViewOnGetMarkupMarjinResponse>.Success(new FinanceFinanceHrtViewOnGetMarkupMarjinResponse
        {
            Response = DataSourceLoader.Load(mrequestResult_1, request.Request.options)
        }));

    }
}
