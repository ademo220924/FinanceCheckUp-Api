using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrt.Query.FinanceFinanceHrtOnGetMarkupMarjinA;
public class FinanceFinanceHrtOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtOnGetMarkupMarjinAQuery, GenericResult<FinanceFinanceHrtOnGetMarkupMarjinAResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtOnGetMarkupMarjinAResponse>> Handle(FinanceFinanceHrtOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTA(request.InitialModel.CompID).Where(x => x.IsHidden == 0).OrderBy(x => x.CounterZone);

                return Task.FromResult(GenericResult<FinanceFinanceHrtOnGetMarkupMarjinAResponse>.Success(new FinanceFinanceHrtOnGetMarkupMarjinAResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options)
        }));

    }
}
