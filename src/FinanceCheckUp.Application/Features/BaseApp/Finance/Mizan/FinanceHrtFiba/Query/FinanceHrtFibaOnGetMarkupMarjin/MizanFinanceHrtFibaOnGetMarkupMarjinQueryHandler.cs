using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.FinanceHrtFiba;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using DevExtreme.AspNet.Data;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.FinanceHrtFiba.Query.FinanceHrtFibaOnGetMarkupMarjin;
public class MizanFinanceHrtFibaOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanFinanceHrtFibaOnGetMarkupMarjinQuery, GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinResponse>> Handle(MizanFinanceHrtFibaOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.Request.compid).Where(x => x.IsHidden == 0);
                return Task.FromResult(GenericResult<MizanFinanceHrtFibaOnGetMarkupMarjinResponse>.Success(
            new MizanFinanceHrtFibaOnGetMarkupMarjinResponse
            {
                Response =  DataSourceLoader.Load(chk, request.Request.options)
            }));
    }
}