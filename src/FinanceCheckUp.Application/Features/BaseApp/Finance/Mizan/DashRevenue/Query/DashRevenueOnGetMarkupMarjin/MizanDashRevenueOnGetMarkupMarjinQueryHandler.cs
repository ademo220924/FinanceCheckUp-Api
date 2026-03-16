using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.DashRevenue.Query.DashRevenueOnGetMarkupMarjin;
public class MizanDashRevenueOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) : IRequestHandler<MizanDashRevenueOnGetMarkupMarjinQuery, GenericResult<MizanDashRevenueOnGetMarkupMarjinResponse>>
{
   
    public Task<GenericResult<MizanDashRevenueOnGetMarkupMarjinResponse>> Handle(MizanDashRevenueOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        var chk = dashGelirTablosuManager.Get_MAINRESULTMultiRVNMain(request.Request.compid).Where(x => x.IsHidden == 0);
        
        return Task.FromResult(GenericResult<MizanDashRevenueOnGetMarkupMarjinResponse>.Success(
            new MizanDashRevenueOnGetMarkupMarjinResponse
            {
                Response =  new JsonResult(DataSourceLoader.Load(chk, request.Request.options))
            }));
    }
}
