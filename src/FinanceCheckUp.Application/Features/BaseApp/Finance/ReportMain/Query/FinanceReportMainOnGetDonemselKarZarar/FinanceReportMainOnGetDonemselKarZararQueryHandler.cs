using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.ReportMain;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using FinanceCheckUp.Application.Models;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.ReportMain.Query.FinanceReportMainOnGetDonemselKarZarar;
public class FinanceReportMainOnGetDonemselKarZararQueryHandler(
    IReportDashManager reportDashManager,
    IHhvnUsersManager hhvnUsersManager) : IRequestHandler<FinanceReportMainOnGetDonemselKarZararQuery, GenericResult<FinanceReportMainOnGetDonemselKarZararResponse>>
{

    public Task<GenericResult<FinanceReportMainOnGetDonemselKarZararResponse>> Handle(FinanceReportMainOnGetDonemselKarZararQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);


        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        { 
                        return Task.FromResult(GenericResult<FinanceReportMainOnGetDonemselKarZararResponse>.Success(new FinanceReportMainOnGetDonemselKarZararResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportMarkupMarjin>(), request.Request.options)
            })); 
        }

        var retval = reportDashManager.Get_Data_DonemselKarzarar(request.Request.myear, request.Request.compid);
       
                return Task.FromResult(GenericResult<FinanceReportMainOnGetDonemselKarZararResponse>.Success(new FinanceReportMainOnGetDonemselKarZararResponse
        {
            Response = DataSourceLoader.Load(retval, request.Request.options)
        })); 
    }
}
