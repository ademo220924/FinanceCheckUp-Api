using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.DashRasyo.Query.DashRasyoOnGetCasino;
public class FinanceDashRasyoOnGetCasinoQueryHandler(IDashBoardManager dashBoardManager) : IRequestHandler<FinanceDashRasyoOnGetCasinoQuery, GenericResult<FinanceDashRasyoOnGetCasinoResponse>>
{
    public Task<GenericResult<FinanceDashRasyoOnGetCasinoResponse>> Handle(FinanceDashRasyoOnGetCasinoQuery request, CancellationToken cancellationToken)
    {
        var userId = Convert.ToInt64(request.UserId);
        request.InitialModel.dash = dashBoardManager.Get_ErroorList();

                return Task.FromResult(GenericResult<FinanceDashRasyoOnGetCasinoResponse>.Success(new FinanceDashRasyoOnGetCasinoResponse
        {
            Response = DataSourceLoader.Load(request.InitialModel.dash, request.Request.options)
        }));

    }
}
