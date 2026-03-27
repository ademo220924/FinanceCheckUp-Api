using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.FinanceHrt;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.FinanceHrt.Query.FinanceFinanceHrtOnGetMarkupMarjin;
public class FinanceFinanceHrtOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<FinanceFinanceHrtOnGetMarkupMarjinQuery, GenericResult<FinanceFinanceHrtOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<FinanceFinanceHrtOnGetMarkupMarjinResponse>> Handle(FinanceFinanceHrtOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        List<DashBilancoViewMulti> chklist = new List<DashBilancoViewMulti>();
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiMainPIVOT(request.InitialModel.CompID).Where(x => x.IsHidden == 0);

                return Task.FromResult(GenericResult<FinanceFinanceHrtOnGetMarkupMarjinResponse>.Success(new FinanceFinanceHrtOnGetMarkupMarjinResponse
        {
            Response = DataSourceLoader.Load(chk, request.Request.options)
        }));

    }
}
