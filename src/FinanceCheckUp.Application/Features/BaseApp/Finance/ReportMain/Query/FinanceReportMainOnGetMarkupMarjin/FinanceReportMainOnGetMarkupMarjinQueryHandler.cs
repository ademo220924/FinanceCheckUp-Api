using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetMarkupMarjin;
public class FinanceReportMainOnGetMarkupMarjinQueryHandler(
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetMarkupMarjinQuery, GenericResult<FinanceReportMainOnGetMarkupMarjinResponse>>
{

    public Task<GenericResult<FinanceReportMainOnGetMarkupMarjinResponse>> Handle(FinanceReportMainOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
                        return Task.FromResult(GenericResult<FinanceReportMainOnGetMarkupMarjinResponse>.Success(new FinanceReportMainOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        }

        var mrequestResult_1 = reportDashManager.Get_Data_GrossProfitGraphic(request.Request.myear, request.Request.compid);
                return Task.FromResult(GenericResult<FinanceReportMainOnGetMarkupMarjinResponse>.Success(new FinanceReportMainOnGetMarkupMarjinResponse
        {
            Response = DataSourceLoader.Load(mrequestResult_1, request.Request.options)
        }));
    }
}
