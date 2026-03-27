using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrt.Query.FinanceFinanceHrtOnGetMarkupMarjinB;
public class FinanceFinanceHrtOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtOnGetMarkupMarjinBQuery, GenericResult<FinanceFinanceHrtOnGetMarkupMarjinBResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtOnGetMarkupMarjinBResponse>> Handle(FinanceFinanceHrtOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTB(request.InitialModel.CompID).Where(x => x.IsHidden == 0).OrderBy(x => x.CounterZone);

                return Task.FromResult(GenericResult<FinanceFinanceHrtOnGetMarkupMarjinBResponse>.Success(new FinanceFinanceHrtOnGetMarkupMarjinBResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options)
        }));

    }
}
