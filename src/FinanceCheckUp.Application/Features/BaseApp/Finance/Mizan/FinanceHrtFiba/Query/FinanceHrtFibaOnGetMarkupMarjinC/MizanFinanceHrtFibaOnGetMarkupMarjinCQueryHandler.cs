using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGetMarkupMarjinC;
public class MizanFinanceHrtFibaOnGetMarkupMarjinCQueryHandler(IReportSetMainSqlOperationManager reportSetMainSqlOperationManager) : IRequestHandler<MizanFinanceHrtFibaOnGetMarkupMarjinCQuery, GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinCResponse>>
{
    public Task<GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinCResponse>> Handle(MizanFinanceHrtFibaOnGetMarkupMarjinCQuery request, CancellationToken cancellationToken)
    {
        var chk = reportSetMainSqlOperationManager.Get_ReportSetFiba(request.Request.compid).OrderBy(x => x.AccountMainID);
                return Task.FromResult(GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinCResponse>.Success(
            new MizanFinanceHrtFibaOnGetMarkupMarjinCResponse
            {
                Response =  DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}
