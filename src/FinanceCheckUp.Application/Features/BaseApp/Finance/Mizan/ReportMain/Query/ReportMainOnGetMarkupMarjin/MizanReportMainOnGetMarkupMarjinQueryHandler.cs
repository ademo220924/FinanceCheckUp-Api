using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportMain;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportMain;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportMain.Query.ReportMainOnGetMarkupMarjin;
public class MizanReportMainOnGetMarkupMarjinQueryHandler(IReportDashMizanManager reportDashMizanManager,IHhvnUsersManager hhvnUsersManager) : IRequestHandler<MizanReportMainOnGetMarkupMarjinQuery, GenericResult<MizanReportMainOnGetMarkupMarjinResponse>>
{

    public Task<GenericResult<MizanReportMainOnGetMarkupMarjinResponse>> Handle(MizanReportMainOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);

        if (!hhvnUsersManager.CheckUser(request.Request.compid, (int)userId))
        {
                          return Task.FromResult(GenericResult<MizanReportMainOnGetMarkupMarjinResponse>.Success(new MizanReportMainOnGetMarkupMarjinResponse
            {
                Response = DataSourceLoader.Load(new List<YearlyReportDashMizan>(), request.Request.options)
            }));
        }


        IEnumerable<YearlyReportDashMizanGrap> mrequestResult1 = reportDashMizanManager.Get_Data_GrossProfitGraphic(request.Request.compid).OrderBy(x => x.Year);

                return Task.FromResult(GenericResult<MizanReportMainOnGetMarkupMarjinResponse>.Success(new MizanReportMainOnGetMarkupMarjinResponse
        {
            Response = DataSourceLoader.Load(mrequestResult1, request.Request.options)
        }));
    }
}
