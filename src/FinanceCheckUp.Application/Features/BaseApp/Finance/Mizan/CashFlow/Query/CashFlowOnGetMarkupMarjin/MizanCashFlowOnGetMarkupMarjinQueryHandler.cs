using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.CashFlow;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.CashFlow.Query.CashFlowOnGetMarkupMarjin;

public class MizanCashFlowOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanCashFlowOnGetMarkupMarjinQuery, GenericResult<MizanCashFlowOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanCashFlowOnGetMarkupMarjinResponse>> Handle(MizanCashFlowOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiCashFlow(request.Request.compid);
        return chk.Count < 1
            ? Task.FromResult(GenericResult<MizanCashFlowOnGetMarkupMarjinResponse>.Success(
                new MizanCashFlowOnGetMarkupMarjinResponse
                {
                    Response = DataSourceLoader.Load(new List<DashBilancoViewMulti>(), request.Request.options)
                }))
            : Task.FromResult(GenericResult<MizanCashFlowOnGetMarkupMarjinResponse>.Success(
                new MizanCashFlowOnGetMarkupMarjinResponse
                {
                    Response = DataSourceLoader.Load(chk, request.Request.options)
                }));
    }
}
