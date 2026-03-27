using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRasyo.Query.DashRasyoOnGetCasino;
public class MizanDashRasyoOnGetCasinoQueryHandler(IDashBoardManager dashBoardManager) : IRequestHandler<MizanDashRasyoOnGetCasinoQuery, GenericResult<MizanDashRasyoOnGetCasinoResponse>>
{
    public Task<GenericResult<MizanDashRasyoOnGetCasinoResponse>> Handle(MizanDashRasyoOnGetCasinoQuery request, CancellationToken cancellationToken)
    {
        var dash = dashBoardManager.Get_ErroorList();
                return Task.FromResult(GenericResult<MizanDashRasyoOnGetCasinoResponse>.Success(
            new MizanDashRasyoOnGetCasinoResponse
            {
                Response =  DataSourceLoader.Load(dash, request.Request.options)
            }));
    }
}
