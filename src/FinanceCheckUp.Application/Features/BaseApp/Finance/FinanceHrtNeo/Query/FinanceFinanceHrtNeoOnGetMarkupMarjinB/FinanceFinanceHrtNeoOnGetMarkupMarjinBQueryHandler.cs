using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGetMarkupMarjinB;
public class FinanceFinanceHrtNeoOnGetMarkupMarjinBQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtNeoOnGetMarkupMarjinBQuery, GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinBResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinBResponse>> Handle(FinanceFinanceHrtNeoOnGetMarkupMarjinBQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTANeo(request.InitialModel.CompID).Where(x => x.TypeID == 333).OrderBy(x => x.AccountMainID);

                return Task.FromResult(GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinBResponse>.Success(new FinanceFinanceHrtNeoOnGetMarkupMarjinBResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options)
        }));

    }
}
