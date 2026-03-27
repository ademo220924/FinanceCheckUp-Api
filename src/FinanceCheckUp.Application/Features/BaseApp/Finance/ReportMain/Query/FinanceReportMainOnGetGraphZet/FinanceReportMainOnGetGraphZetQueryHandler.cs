using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetGraphZet;
public class FinanceReportMainOnGetGraphZetQueryHandler(
    IMainDashManager mainDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetGraphZetQuery, GenericResult<FinanceReportMainOnGetGraphZetResponse>>
{

    public Task<GenericResult<FinanceReportMainOnGetGraphZetResponse>> Handle(FinanceReportMainOnGetGraphZetQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int) userId))
        { 
                        return Task.FromResult(GenericResult<FinanceReportMainOnGetGraphZetResponse>.Success(new FinanceReportMainOnGetGraphZetResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            }));
        }

        var retval = mainDashManager.Get_Data(request.Request.myear, request.Request.compid);
      
                return Task.FromResult(GenericResult<FinanceReportMainOnGetGraphZetResponse>.Success(new FinanceReportMainOnGetGraphZetResponse
        {
            Response = DataSourceLoader.Load(retval, request.Request.options)
        }));
    }
}
