using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrtNeo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrtNeo.Query.FinanceFinanceHrtNeoOnGetMarkupMarjinA;
public class FinanceFinanceHrtNeoOnGetMarkupMarjinAQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtNeoOnGetMarkupMarjinAQuery, GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinAResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinAResponse>> Handle(FinanceFinanceHrtNeoOnGetMarkupMarjinAQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOTANeo(request.InitialModel.CompID).Where(x => x.TypeID == 111).OrderBy(x => x.AccountMainID);

                return Task.FromResult(GenericResult<FinanceFinanceHrtNeoOnGetMarkupMarjinAResponse>.Success(new FinanceFinanceHrtNeoOnGetMarkupMarjinAResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options)
        }));

    }
}
