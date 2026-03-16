using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Aktarma.DashRevenue;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Aktarma.DashRevenue.Query.AktarmaDashRevenueOnGetMarkupMarjin;
public class AktarmaDashRevenueOnGetMarkupMarjinQueryHandler(IDashGelirTablosuManager dashGelirTablosuManager) 
    : IRequestHandler<AktarmaDashRevenueOnGetMarkupMarjinQuery, GenericResult<AktarmaDashRevenueOnGetMarkupMarjinResponse>>
{
    public Task<GenericResult<AktarmaDashRevenueOnGetMarkupMarjinResponse>> Handle(AktarmaDashRevenueOnGetMarkupMarjinQuery request, CancellationToken cancellationToken)
    {
        if (request.Request.compid < 1)
        {
            return Task.FromResult(GenericResult<AktarmaDashRevenueOnGetMarkupMarjinResponse>.Success(
                new AktarmaDashRevenueOnGetMarkupMarjinResponse
                {
                    Response = new JsonResult(DataSourceLoader.Load(new List<DashBilancoViewMulti>(), request.Request.options)),
                    InitialModel = request.InitialModel
                }));
        }


        var nRequestList = dashGelirTablosuManager.Get_MAINRevenueMznAktMulti(request.Request.compid);

        request.InitialModel.nRequestList = nRequestList;
        
        return Task.FromResult(GenericResult<AktarmaDashRevenueOnGetMarkupMarjinResponse>.Success(
            new AktarmaDashRevenueOnGetMarkupMarjinResponse
            {
                Response = new JsonResult(DataSourceLoader.Load(nRequestList.Where(x => x.IsHidden == 0), request.Request.options)),
                InitialModel = request.InitialModel
            }));
        
    }
}
