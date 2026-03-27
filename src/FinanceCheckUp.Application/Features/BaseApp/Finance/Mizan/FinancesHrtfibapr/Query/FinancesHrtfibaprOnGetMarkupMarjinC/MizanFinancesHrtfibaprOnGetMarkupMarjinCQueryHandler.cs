using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinancesHrtfibapr;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinancesHrtfibapr.Query.FinancesHrtfibaprOnGetMarkupMarjinC;
public class MizanFinancesHrtfibaprOnGetMarkupMarjinCQueryHandler(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<MizanFinancesHrtfibaprOnGetMarkupMarjinCQuery, GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinCResponse>>
{
    
    public Task<GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinCResponse>> Handle(MizanFinancesHrtfibaprOnGetMarkupMarjinCQuery request, CancellationToken cancellationToken)
    {
        var chk = reportSetMainSqlOperationManager.Get_ReportSetFiba(request.Request.compid).OrderBy(x => x.AccountMainID);
       
                return Task.FromResult(GenericResult<MizanFinancesHrtfibaprOnGetMarkupMarjinCResponse>.Success(
            new MizanFinancesHrtfibaprOnGetMarkupMarjinCResponse
            { 
               Response = DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
